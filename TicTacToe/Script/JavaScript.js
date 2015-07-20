//Global Variables
var painted;
var content;
var winningCombinations;
var turn = 0;
var theCanvas;
var element;
var context;
var squaresFilled = 0;
var playAgainCheck;

//Instanciate Arrays
window.onload = function () {

    painted = new Array();
    content = new Array();
    winningCombinations = [[0, 1, 2], [3, 4, 5], [6, 7, 8], [0, 3, 6], [1, 4, 7], [2, 5, 8], [0, 4, 8], [2, 4, 6]];

    for (var l = 0; l <= 8; l++) {
        painted[l] = false;
        content[l] = '';
    }
}

//Game methods
function canvasClicked(canvasNumber) {
    theCanvas = "canvas" + canvasNumber;
    element = document.getElementById(theCanvas);
    context = element.getContext("2d");

    if (painted[canvasNumber - 1] == false) {
        if (turn % 2 == 0) {
            context.beginPath();
            context.moveTo(10, 10);
            context.lineTo(40, 40);
            context.moveTo(40, 10);
            context.lineTo(10, 40);
            context.stroke();
            context.closePath();
            content[canvasNumber - 1] = 'X';
        }

        else {
            context.beginPath();
            context.arc(25, 25, 20, 0, Math.PI * 2, true);
            context.stroke();
            context.closePath();
            content[canvasNumber - 1] = 'O';
        }

        turn++;
        painted[canvasNumber - 1] = true;
        squaresFilled++;
        checkForWinners(content[canvasNumber - 1]);

        if (squaresFilled == 9) {
            alert("THE GAME IS OVER!");
            location.reload(true);
        }

    }
    else {
        alert("THAT SPACE IS ALREADY OCCUPIED ");
    }

}
function checkForWinners(symbol) {

    for (var a = 0; a < winningCombinations.length; a++) {
        if (content[winningCombinations[a][0]] == symbol && content[winningCombinations[a][1]] == symbol && content[winningCombinations[a][2]] == symbol) {
            alert(symbol + " WON!");
            playAgain();
        }
    }

}
function playAgain() {
    playAgainCheck = confirm("PLAY AGAIN?");
    if (playAgainCheck == true) {
        location.reload(true);
    }

}
