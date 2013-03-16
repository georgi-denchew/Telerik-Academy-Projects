function WithinCircleButtonClick() {
    var x = jsConsole.readInteger("#x");
    var y = jsConsole.readInteger("#y");

    var isWithinCircle = (x - 0) * (x - 0) + (y - 5) * (y - 5) < Math.PI * 5 * 5

    if (isWithinCircle)
    {
        jsConsole.writeLine("The point is within the circle.");
    }
    else
    {
        jsConsole.writeLine("The point is outside the circle.");
    }
}