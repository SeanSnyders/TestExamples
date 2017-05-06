using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System.IO;
using System.Runtime.InteropServices;

public class Startup
{
    public async Task<object> TestMe_Edge(dynamic input)
    {
        int answer = 0;
        try
        {
            answer = SS.MyNetCoreLib.TestNetCore.TestMe();
        }
        catch (Exception ex)
        {
            Console.WriteLine("[MyNetCore Error] unhandled exception initialising bridge:\n" + ex.ToString());
        }
        Console.WriteLine("TestMe answer=" + answer);

        return answer;
    }

}
