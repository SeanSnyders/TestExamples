using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Threading;
using System.Net.WebSockets;

namespace WebSocketTestClient
{
    using System.IO;
    using System.Threading.Tasks;

    public class Program
    {
        private static string _hostURL = "";
        private static ClientWebSocket _socket;
        private static byte[] _buffer = new byte[8*1024];
        private static ArraySegment<byte> _segment = new ArraySegment<byte>(_buffer);

        private static async Task SendMessage(string message)
        {
            try
            {
                if (_socket.State == WebSocketState.Open)
                {
                    var bytes = System.Text.Encoding.UTF8.GetBytes(message);
                    var outgoing = new ArraySegment<byte>(bytes, 0, bytes.Length);
                    await _socket.SendAsync(outgoing, WebSocketMessageType.Text, true, CancellationToken.None);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception sending message to ws server: {e.ToString()}");
            }
        }

        private static async Task connectToServer(Uri uri, CancellationToken token)
        {
            await _socket.ConnectAsync(uri: uri, cancellationToken: CancellationToken.None);
            await HandleMessage(_socket);
        }

        private static async Task HandleInput()
        {
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    try
                    {
                        var key = Console.ReadKey(true).Key;
                        Console.WriteLine($"Pressed key: {key}");
                        string msgToSend = null;
                        if (key == ConsoleKey.C)
                        {
                            msgToSend = "_ctrl_handshake:hello";
                        }
                        else if (key == ConsoleKey.D)
                        {
                            msgToSend = "_ctrl_handshake:bye";
                        }
                        else if (key == ConsoleKey.E)
                        {
                            msgToSend = "";
                        }
                        else if (key == ConsoleKey.Escape)
                        {
                            Console.WriteLine("esc pressed...");
                            Console.WriteLine("closing ws...");
                            await _socket.CloseAsync(WebSocketCloseStatus.NormalClosure, "client requested close", CancellationToken.None);                            
                            return;
                        }
                        else
                        {
                            Console.WriteLine($"Unsupported key: {key}");
                        }
                        if (msgToSend != null)
                        {
                            Console.WriteLine($">> sending msg '{msgToSend}'...");
                            await SendMessage(msgToSend);
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"Unhandled exception running WebSocketTestClient: {e}");
                    }
                }
                else
                {
                    if ((_socket.State == WebSocketState.Open) || (_socket.State == WebSocketState.Connecting))
                    {
                        await Task.Delay(250);
                    }
                    else
                    {
                        Console.WriteLine($"_socket.State: {_socket.State}");
                        return;
                    }
                }
            }
        }

        private static async Task HandleMessage(ClientWebSocket socket)
        {
            try
            {
                while (socket.State == WebSocketState.Open)
                {
                    Console.WriteLine("waiting for server mesages...");
                    var incoming = await socket.ReceiveAsync(_segment, CancellationToken.None);
                    if (incoming.MessageType == WebSocketMessageType.Close)
                    {
                        if (!incoming.CloseStatus.HasValue)
                        {
                            Console.WriteLine($"incoming.CloseStatus: {incoming.CloseStatus}");
                            Console.WriteLine("server socket is closed, closing our side...");
                            await socket.CloseAsync(incoming.CloseStatus.Value, string.Empty,
                                CancellationToken.None);
                        }
                    }
                    else
                    {
                        Console.WriteLine("socket is open, reading message...");
                        string wholeMessage = System.Text.Encoding.UTF8.GetString(_buffer, 0, incoming.Count);

                        while (!incoming.EndOfMessage)
                        {
                            Console.WriteLine("msg not done, reading more of message...");
                            incoming = await socket.ReceiveAsync(_segment, CancellationToken.None);
                            wholeMessage += (System.Text.Encoding.UTF8.GetString(_buffer, 0, incoming.Count));
                        }

                        Console.WriteLine($"<<<<<< server reply: '{wholeMessage}'");
                        if (wholeMessage.Length > 0)
                        {
                            // do something with message
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception handling message: {e.ToString()}");
            }
        }


        public static void Main(string[] args)
        {
            _hostURL = args[0];
            Console.WriteLine($"Starting WebSocketTestClient on {_hostURL}...");
            _socket = new ClientWebSocket();
            CancellationToken token = new CancellationToken();
            var uri = new Uri(uriString: _hostURL);

            Console.WriteLine("Press Esc to stop and exit,\nPress Ctrl-c to mimic client crash,\nPress c for hello\nPress d to bye\nPress e to send empty message");
            var allDone = Task.WhenAll(connectToServer(uri, token), HandleInput());
            allDone.Wait();
            
            Environment.Exit(exitCode: 0);
        }
    }
}
