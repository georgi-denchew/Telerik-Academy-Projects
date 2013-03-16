function Check() {
    var x = jsConsole.readInteger("#first-number");
    var y = jsConsole.readInteger("#second-number");

    if (x > y) {
        var z = x;
        x = y;
        y = z;
    }
    jsConsole.writeLine("First number: " + x);
    jsConsole.writeLine("Second number: " + y);
}