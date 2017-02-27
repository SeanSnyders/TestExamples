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
        async (input) => {
            return 62;
        }
    */});
} catch (e) {
    //window.alert(e)
    throw (e);
}

module.exports = {
    testMe
}