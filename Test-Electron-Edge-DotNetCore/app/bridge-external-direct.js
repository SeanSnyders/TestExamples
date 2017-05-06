// requires
let theedge = require('./require-edge.js');

// bridge file locations
let sourceDir = __dirname + '/';
let bridgeBinDir = __dirname + '/mynetcorelib/bin/x64/Release/';

console.log("bridge-external sourceDir=", sourceDir);
console.log("bridge-external bridgeBinDir=", bridgeBinDir);

// function definitions
// --------------------

try {
    var testMe = theedge.edge.func({
        methodName: 'TestMe',
        assemblyFile: bridgeBinDir + 'MyNetCoreLib.dll',
        typeName: 'SS.MyNetCoreLib.TestNetCore_EdgeWrapper'
    });
} catch (e) {
    //window.alert(e)
    console.log("exception occurred: ", e);
    throw (e);
}

module.exports = {
    testMe
}