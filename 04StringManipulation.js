
String.prototype.Concat = function (stringTwo) {

    if (stringTwo === null) {
        return this + 'null';
    }
    if (stringTwo === undefined) {
        return this + 'undefined';
    }
    var concatenatedString = this;
    for (var index = 0; index < stringTwo.length; index++) {
        concatenatedString += stringTwo.charAt(index);
    }
    return concatenatedString;


};

String.prototype.Substring = function (numOne, numTwo) {
    if (numOne < 0 || numTwo < 0) {
        document.write("Invalid arguements entered");
        return;
    }
    var subStr = "";
    for (var index = numOne ; index < numTwo; index++)
        subStr += this[index];
    return subStr;

};

