// requires
let edge = require('electron-edge');

// function definitions
// --------------------

/*
 * payload: {}
 * return: int
 */
try {
    var testMe = edge.func(function() {/*
		using System;
		using System.Threading.Tasks;

		public class Startup
		{
		    public async Task<object> Invoke(dynamic input)
		    {
		        //Console.WriteLine("Version: {0}", Environment.Version.ToString());


		        int answer = 0;
		        try
		        {
		            answer = 16;//SS.MyNetCoreLib.TestNetCore.TestMe();
		        }
		        catch (Exception ex)
		        {
		            //Console.WriteLine("[MyNetCore Error] unhandled exception initialising bridge:\n" + ex.ToString());
		        }
		        //Console.WriteLine("TestMe answer=" + answer);

		        return answer;
		    }

		}
    */});
} catch (e) {
    //window.alert(e)
    throw (e);
}

module.exports = {
    testMe
}