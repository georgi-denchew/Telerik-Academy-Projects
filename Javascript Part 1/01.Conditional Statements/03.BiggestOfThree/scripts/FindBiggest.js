function FindBiggest() {
    var first = jsConsole.readInteger("#first-number");
    var second = jsConsole.readInteger("#second-number");
    var third = jsConsole.readInteger("#third-number");

    if (first > second) {
        if (first > third) {
            jsConsole.writeLine("The biggest number is: " + first);
        }
        else {
            jsConsole.writeLine("The biggest number is: " + third);
        }
    }
    else {
        if (second > third) {
            jsConsole.writeLine("The biggest number is: " + second);
        }
        else {
            jsConsole.writeLine("The biggest number is: " + third);
        }
    }
}