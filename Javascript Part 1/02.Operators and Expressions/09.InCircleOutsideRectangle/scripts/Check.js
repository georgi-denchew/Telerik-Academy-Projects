function CheckButtonClick() {
    var xPoint = jsConsole.readInteger("#x");
    var yPoint = jsConsole.readInteger("#y");
    var xCircle = 1;
    var yCircle = 1;
    var radius = 3;



    if (((xPoint - xCircle) * (xPoint - xCircle) + (yPoint - yCircle) * (yPoint - yCircle)) <= radius * radius) {
        jsConsole.writeLine("The point is in the circle.");

        if (xPoint < -1 || (xPoint > 5) || (yPoint > 1) || (yPoint < -1)) {
            jsConsole.writeLine("The point is out of the rectangle.");
        }
        else {
            jsConsole.writeLine("The point is in the rectangle.");
        }
    }
    else {
        jsConsole.writeLine("The point is out of the circle.");

        if (xPoint < -1 || (xPoint > 5) || (yPoint > 1) || (yPoint < -1)) {
            jsConsole.writeLine("The point is out of the rectangle.");
        }
        else {
            jsConsole.writeLine("The point is in the rectangle.");
        }

    }
}