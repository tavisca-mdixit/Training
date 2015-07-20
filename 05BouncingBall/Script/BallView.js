window.ball = window.ball || {
    previousX: 0,
    previousY: 0,
    gradientX: 20,
    gradientY: 20,    
}
window.ball.moveBall = function () {  
    window.ball.boundaryCheck();
    ball.previousX += ball.gradientX;
    ball.previousY += ball.gradientY;
  
    var element = document.getElementById('Ball');
    element.style.left = ball.previousX + "px";
    element.style.top = ball.previousY + "px";
   
}
window.ball.start =function() {
    setInterval(window.ball.moveBall, 20);
}