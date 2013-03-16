function CalculateAreaButtonClick() {
    var a = jsConsole.readInteger("#a");
    var b = jsConsole.readInteger("#b");
    var h = jsConsole.readInteger("#h");
    var area = (a + b) * h / 2;
    jsConsole.writeLine("The trapezoid's area is: " + area);
}