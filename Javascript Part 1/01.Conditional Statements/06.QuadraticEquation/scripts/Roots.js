function RootsButtonClick() {
    jsConsole.writeLine("This program finds the roots to the quadratic equation: ax^2 + bx + c = 0");
    jsConsole.writeLine();
    var a = jsConsole.readInteger("#a");
    var b = jsConsole.readInteger("#b");
    var c = jsConsole.readInteger("#c");
    var D = (b * b) - (4 * a * c);
    if (D < 0) {
        jsConsole.writeLine("The equation has no real roots.");
    }
    else if (D == 0) {
        var x = (-b) / (2 * a);
        jsConsole.writeLine("The only real root of the equations is " + x);
    }

    else if (D > 0) {
        var x1 = -b + Math.sqrt(D);
        var x2 = -b - Math.sqrt(D);
        jsConsole.writeLine("The roots of the equation are: " + x1 + " and " + x2);
    }
}