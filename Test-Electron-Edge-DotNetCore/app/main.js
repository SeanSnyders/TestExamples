var edge = require('electron-edge');

let bridge = require('./bridge-external.js');


var helloWorld = edge.func(function () {/*
    async (input) => { 
        return ".NET Welcomes " + input.ToString(); 
    }
*/});

helloWorld('JavaScript', function (error, result) {
    if (error) throw error;
    console.log(result);
});



// Testing DotNet Core
// -------------------
try {
    // payload for this function call
    let payload = {};
    // call test me function
    bridge.testMe(payload, function(error, result) {
        if (error) throw error;
        console.log("The answer is: ", result);
    });
} catch (e) {
    //window.alert(e);
    throw (e);
}

