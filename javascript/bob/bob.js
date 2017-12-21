//
// This is only a SKELETON file for the "Bob" exercise. It's been provided as a
// convenience to get you started writing code faster.
//

var Bob = function() {};

Bob.prototype.hey = function(input) {
    if (input.trim() === '') {
        return 'Fine. Be that way!';
    }

    if (input.toUpperCase() === input && input.toUpperCase() != input.toLowerCase()) {
        return 'Whoa, chill out!';
    }

    if (input.indexOf('?') == input.length - 1) {
        return 'Sure.';
    }

    return 'Whatever.';
};

module.exports = Bob;
