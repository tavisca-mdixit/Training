window.ball = window.ball || {

};

var increment=10;
window.ball.boundaryCheck = function () {

    ball.height = (window.innerHeight - 50);
    ball.width = (window.innerWidth - 50);

    if (ball.previousY >= ball.height) {
        ball.gradientY = -increment;
    }
    if (ball.previousX >= ball.width) {
        ball.gradientX = -increment;
    }
    if (ball.previousY <= 0) {
        ball.gradientY = increment;
    }
    if (ball.previousX <= 0) {
        ball.gradientX = increment;
    }
}