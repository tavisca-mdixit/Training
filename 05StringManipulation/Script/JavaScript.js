
String.prototype.Concat = function () {

    var concatenatedString = this;
    for (var index = 0; index < arguments.length; index++) {
        if (arguments[index] === null) {
            concatenatedString += 'null';
        }
        else if (arguments[index] === undefined) {
            concatenatedString += 'undefined';
        }

        else {
            concatenatedString += arguments[index];
        }
    }
    return concatenatedString;


};

String.prototype.Substring = function (numOne, numTwo) {

    var subStr = "";

    if (numOne < 0 || numOne === null || numOne === undefined) {
        for (var index = 0 ; index < numTwo; index++)
            subStr += this[index];

    }
    else if (numTwo < 0 || numTwo === null || numTwo === undefined) {
        for (var index = 0 ; index < numOne; index++)
            subStr += this[index];

    }
    else if (numOne > numTwo) {
        for (var index = numTwo ; index < numOne; index++)
            subStr += this[index];

    }
    else {
        for (var index = numOne ; index < numTwo; index++)
            subStr += this[index];
    }
    return subStr;

};

