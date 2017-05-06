using System;
using System.Dynamic;
using System.Threading.Tasks;

namespace SS.MyNetCoreLib
{
    public static class TestNetCore
    {
        public static int TestMe()
        {
        	return 42;
        }
    }

    public class TestNetCore_EdgeWrapper
    {
        public async Task<object> TestMe(dynamic input)
        {
            int answer = 0;
            try
            {
                answer = SS.MyNetCoreLib.TestNetCore.TestMe();
            }
            catch (Exception ex)
            {
                Console.WriteLine("[MyNetCore Error] unhandled exception calling c# function from edge task wrapper:\n" + ex.ToString());
            }

            return answer;
        }

    }

}