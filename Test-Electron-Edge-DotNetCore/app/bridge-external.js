// requires
let edge = require('electron-edge');

// bridge file locations
let sourceDir = __dirname + '\\';
let bridgeBinDir = __dirname + '\\mynetcorelib\\bin\\x64\\Release\\';

console.log("bridge-external sourceDir=", sourceDir);
console.log("bridge-external bridgeBinDir=", bridgeBinDir);

// function definitions
// --------------------

/*
 * payload: {}
 * return: int
 */
try {
    var testMe = edge.func({
        source: sourceDir + 'mynetcore_edge.cs',
        references: [
            bridgeBinDir + 'MyNetCoreLib.dll'
        ],
        methodName: 'TestMe_Edge'
    });
} catch (e) {
    //window.alert(e)
    console.log("exception occurred: ", e);
    throw (e);
}

module.exports = {
    testMe
}