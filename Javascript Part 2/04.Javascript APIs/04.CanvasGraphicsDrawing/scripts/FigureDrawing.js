(function () {
    var canvas = document.getElementById("main-canvas"),
    ctx = canvas.getContext("2d");

    // DRAWING THE BIKE

    // drawing wheels
    ctx.lineWidth = 2;
    ctx.beginPath();
    ctx.fillStyle = "#90CAD7";
    ctx.strokeStyle = "#358194";
    ctx.arc(150, 550, 50, 0, Math.PI * 2, false);
    ctx.fill();
    ctx.stroke();

    ctx.beginPath();
    ctx.arc(400, 550, 50, 0, Math.PI * 2, false);
    ctx.fill();
    ctx.stroke();

    // Drawing pedals, seat, handle-bar and everything else
    ctx.moveTo(150, 550);
    ctx.lineTo(240, 550);
    ctx.lineTo(190, 450);
    ctx.moveTo(160, 450);
    ctx.lineTo(220, 450);
    ctx.moveTo(150, 550);
    ctx.lineTo(210, 490);
    ctx.lineTo(390, 490);
    ctx.moveTo(400, 550);
    ctx.lineTo(380, 430);
    ctx.lineTo(410, 400);
    ctx.moveTo(380, 430);
    ctx.lineTo(330, 440);
    ctx.moveTo(240, 550);
    ctx.lineTo(390, 490);
    ctx.stroke();

    // Drawing pedals
    ctx.beginPath();
    ctx.arc(240, 550, 20, 0, 2 * Math.PI, false);
    ctx.stroke();

    ctx.moveTo(225, 535);
    ctx.lineTo(215, 525);
    ctx.moveTo(255, 565);
    ctx.lineTo(265, 575);
    ctx.stroke();

    // DRAWING THE HEAD
    ctx.beginPath();
    ctx.arc(230, 320, 60, 0, 2 * Math.PI, false);
    ctx.fill();
    ctx.stroke();

    // drawing the eyes
    ctx.beginPath();
    ctx.moveTo(185, 300);
    ctx.bezierCurveTo(187, 292, 203, 292, 205, 300);

    ctx.moveTo(185, 300);
    ctx.bezierCurveTo(187, 308, 203, 308, 205, 300);
    ctx.stroke();

    ctx.beginPath();
    ctx.fillStyle = "#20525D";
    ctx.lineWidth = 0;
    ctx.moveTo(190, 295);
    ctx.bezierCurveTo(187, 295, 187, 304, 190, 304);
    ctx.moveTo(190, 295);
    ctx.bezierCurveTo(193, 295, 193, 304, 190, 304);
    ctx.fill();

    ctx.beginPath();
    ctx.moveTo(235, 300);
    ctx.bezierCurveTo(237, 292, 253, 292, 255, 300);

    ctx.moveTo(235, 300);
    ctx.bezierCurveTo(237, 308, 253, 308, 255, 300);
    ctx.stroke();

    ctx.beginPath();
    ctx.fillStyle = "#20525D";
    ctx.moveTo(240, 295);
    ctx.bezierCurveTo(237, 295, 237, 304, 240, 304);
    ctx.moveTo(240, 295);
    ctx.bezierCurveTo(243, 295, 243, 304, 240, 304);
    ctx.fill();

    // drawing the nose
    ctx.beginPath();
    ctx.moveTo(220, 300);
    ctx.lineTo(205, 330);
    ctx.lineTo(220, 330);
    ctx.stroke();

    // drawing the mouth
    ctx.beginPath();
    ctx.moveTo(195, 345);
    ctx.bezierCurveTo(200, 338, 240, 350, 235, 355);

    ctx.moveTo(195, 345);
    ctx.bezierCurveTo(200, 355, 235, 358, 235, 355);
    ctx.stroke();

    // drawing the hat
    ctx.beginPath();
    ctx.strokeStyle = "#000";
    ctx.fillStyle = "#396693";

    ctx.moveTo(175, 265);
    ctx.bezierCurveTo(175, 285, 285, 285, 285, 265);
    ctx.moveTo(175, 265);
    ctx.bezierCurveTo(175, 245, 285, 245, 285, 265);
    ctx.fill();
    ctx.stroke();

    ctx.beginPath();
    ctx.moveTo(195, 255);
    ctx.bezierCurveTo(205, 265, 265, 265, 265, 255);
    ctx.moveTo(195, 255);
    ctx.lineTo(195, 190);
    ctx.moveTo(265, 255);
    ctx.lineTo(265, 190);

    // The following two lines are made only because they are necessary for the filling
    ctx.lineTo(195, 190);
    ctx.lineTo(195, 255);
    ctx.fill();
    ctx.stroke();

    ctx.beginPath();
    ctx.moveTo(195, 190);
    ctx.bezierCurveTo(205, 200, 265, 200, 265, 190);
    ctx.moveTo(195, 190);
    ctx.bezierCurveTo(205, 180, 265, 180, 265, 190);
    ctx.fill();
    ctx.stroke();

    // DRAWING THE HOUSE
    ctx.beginPath();
    ctx.fillStyle = "#975B5B";

    ctx.moveTo(600, 600);
    ctx.lineTo(1100, 600);
    ctx.lineTo(1100, 300);
    ctx.lineTo(600, 300);
    ctx.lineTo(600, 600);
    ctx.fill();
    ctx.stroke();

    // rooftop
    ctx.moveTo(600, 300);
    ctx.lineTo(850, 100);
    ctx.lineTo(1100, 300);
    ctx.fill();
    ctx.stroke();

    // chimney
    ctx.beginPath();
    ctx.moveTo(980, 260);
    ctx.lineTo(980, 150);
    ctx.lineTo(1010, 150);
    ctx.lineTo(1010, 260);
    ctx.fill();
    ctx.stroke();

    ctx.beginPath();
    ctx.moveTo(980, 150);
    ctx.bezierCurveTo(980, 155, 1010, 155, 1010, 150);
    ctx.moveTo(980, 150);
    ctx.bezierCurveTo(980, 145, 1010, 145, 1010, 150);
    ctx.fill();
    ctx.stroke();

    // drawing the door
    ctx.beginPath();
    ctx.moveTo(690, 600);
    ctx.arcTo(690, 500, 700, 500, 50);
    ctx.stroke();
    ctx.moveTo(780, 600);
    ctx.arcTo(780, 500, 770, 500, 50);

    ctx.moveTo(735, 600);
    ctx.lineTo(735, 500);
    ctx.stroke();

    ctx.beginPath();
    ctx.arc(725, 570, 5, 0, 2 * Math.PI, false);
    ctx.stroke();
    ctx.beginPath();
    ctx.arc(745, 570, 5, 0, 2 * Math.PI, false);
    ctx.stroke();

    // drawing the windows
    ctx.beginPath();
    ctx.fillStyle = "#000";
    ctx.strokeStyle = "#975B5B";
    ctx.moveTo(650, 320);
    ctx.lineTo(820, 320);
    ctx.lineTo(820, 420);
    ctx.lineTo(650, 420);
    ctx.lineTo(650, 320);
    ctx.fill();
    ctx.moveTo(735, 420);
    ctx.lineTo(735, 320);
    ctx.moveTo(650, 370);
    ctx.lineTo(820, 370);
    ctx.stroke();

    ctx.moveTo(850, 320);
    ctx.lineTo(1020, 320);
    ctx.lineTo(1020, 420);
    ctx.lineTo(850, 420);
    ctx.lineTo(850, 320);
    ctx.fill();
    ctx.moveTo(935, 420);
    ctx.lineTo(935, 320);
    ctx.moveTo(850, 370);
    ctx.lineTo(1020, 370);
    ctx.stroke();

    ctx.moveTo(850, 470);
    ctx.lineTo(1020, 470);
    ctx.lineTo(1020, 570);
    ctx.lineTo(850, 570);
    ctx.lineTo(850, 470);
    ctx.fill();
    ctx.moveTo(935, 570);
    ctx.lineTo(935, 470);
    ctx.moveTo(850, 520);
    ctx.lineTo(1020, 520);
    ctx.stroke();

    console.log('hi');
})();