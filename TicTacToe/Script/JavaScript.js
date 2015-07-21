//Globally defined Variables
var painted;
var content;
var winningCombinations;
var turn = 0;
var theCanvas;
var c;
var cxt;
var squaresFilled = 0;
var w;
var y;

//creating two arrays to check for filled and empty TicTacToe boxes
window.onload = function () {

    painted = new Array();
    content = new Array();
    winningCombinations = [[0, 1, 2], [3, 4, 5], [6, 7, 8], [0, 3, 6], [1, 4, 7], [2, 5, 8], [0, 4, 8], [2, 4, 6]];

    for (var l = 0; l <= 8; l++) {
        painted[l] = false;
        content[l] = '';
    }
}

//Checking the box clicked and then creating id of that particular to take action. 
//Used beginpath,lineTo,moveTo,arc,stroke to draw X and O on the TicTacToe Boxes.
function canvasClicked(canvasNumber) {
    theCanvas = "canvas" + canvasNumber;
    c = document.getElementById(theCanvas);
    cxt = c.getContext("2d");

    if (painted[canvasNumber - 1] == false) {
        if (turn % 2 == 0) {
            cxt.beginPath();
            cxt.moveTo(10, 10);
            cxt.lineTo(40, 40);
            cxt.moveTo(40, 10);
            cxt.lineTo(10, 40);
            cxt.stroke();
            cxt.closePath();
            content[canvasNumber - 1] = 'X';
        }

        else {
            cxt.beginPath();
            cxt.arc(25, 25, 20, 0, Math.PI * 2, true);
            cxt.stroke();
            cxt.closePath();
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

//checking for winnner through the list of winning conditions created.
//Taking list of lists to define winning condition
function checkForWinners(symbol) {

    for (var a = 0; a < winningCombinations.length; a++) {
        if (content[winningCombinations[a][0]] == symbol && content[winningCombinations[a][1]] == symbol && content[winningCombinations[a][2]] == symbol) {
            alert(symbol + " WON!");
            playAgain();
        }
    }

}
//Prompting user to play again
//If user wants to play ,, reloading the location
function playAgain() {
    y = confirm("PLAY AGAIN?");
    if (y == true) {
        location.reload(true);
    }

}
