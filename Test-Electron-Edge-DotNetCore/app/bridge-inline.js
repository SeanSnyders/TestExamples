// requires
let theedge = require('./require-edge.js');

// function definitions
// --------------------

/*
 * payload: {}
 * return: int
 */
try {
    var testMe = theedge.edge.func(function() {/*
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