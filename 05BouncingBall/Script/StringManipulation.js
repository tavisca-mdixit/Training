
var previousX = 0;
var previousY = 0;
var dX = 20;
var dY = 20;

function startBouncing() {
    setInterval(rollBall, 20);

}
function rollBall() {
    var height = (window.innerHeight - 50);
    var width = (window.innerWidth - 50);
    previousX += dX;
    previousY += dY;
    var element = document.getElementById('Ball');
    element.style.background = "cyan";
    element.style.left = previousX + "px";
    element.style.top = previousY + "px";


    if (previousY >= height) {
        dY = -10;
        return;
    }
    if (previousX >= width) {
        dX = -10;
        return;
    }
    if (previousY <= 0) {
        dY = 10;
        return;
    }
    if (previousX <= 0) {
        dX = 10;
        return;
    }

}
