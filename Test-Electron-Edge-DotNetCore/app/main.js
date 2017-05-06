require('./helloworld.js');

let bridge = require('./bridge-external-direct.js');

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
