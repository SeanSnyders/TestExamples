# Sample WebSocket Client and Server using .Net Core

This illustrates the basic functionality of WebSocket client-server interactions using .Net Core in two separate console applications.

The server is almost verbatim from the ASPNetCore documentation [example](https://github.com/aspnet/Docs/tree/master/aspnetcore/fundamentals/websockets/samples/2.x/WebSocketsSample) with additions of setting up metrics and health-check endpoints using 3rd party library [app-metrics.io](https://www.app-metrics.io/).

The client application will allow messages to be sent to the server using specific key-presses, which the server will then echo back to the client.

## Installs
 1. Install [.Net Core 2.2](https://dotnet.microsoft.com/download/dotnet-core/2.2)
 
## Builds and Running

Both client and server build using typical .Net Core procedures of `dotnet restore`, `dotnet build`, and `dotnet run`.

Use two terminals, one for client and one for server.

### Server
In server terminal:
1. `<repo>/TestExamples/WebSocketTest-DotNetCore/Server> dotnet restore`
2. `<repo>/TestExamples/WebSocketTest-DotNetCore/Server> dotnet build`
3. `<repo>/TestExamples/WebSocketTest-DotNetCore/Server> dotnet run http://localhost:5000`

`Ctrl-c` exits the server.

The server hosts its health-check at `http://localhost:5000/health` and metrics at `http://localhost:5000/metrics`. Both of these are not implemented, thus do not return anything useful.

### Client
In client terminal:
1. `<repo>/TestExamples/WebSocketTest-DotNetCore/Client> dotnet restore`
2. `<repo>/TestExamples/WebSocketTest-DotNetCore/Client> dotnet build`
3. `<repo>/TestExamples/WebSocketTest-DotNetCore/Client> dotnet run ws://localhost:5000/ws`

Press `Esc` to exit the client gracefully. Using `Crtl-c` will exit the client ungracefully.

The client has an implementation to continue to read data from the socket until all data has been received from the server for a specific message. This is to make sure all the data has been read if the receive buffer is smaller than the overall message.

Note that the server implementation does not do this.

## Creating self-contained published applications

To create self-contained applications of the client or server, you need to publish the dotnet project for a specific runtime (see https://docs.microsoft.com/en-us/dotnet/core/rid-catalog). In the below example we publish the server for a generic `linux-x64` runtime (e.g. can be used on AWS linux instances):
`<repo>/TestExamples/WebSocketTest-DotNetCore/Server> dotnet publish -c Release -r linux-x64`

