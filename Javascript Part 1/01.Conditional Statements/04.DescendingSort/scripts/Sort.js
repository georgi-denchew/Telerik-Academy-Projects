function Sort() {
    var first = jsConsole.read("#first-number");
    var second = jsConsole.read("#second-number");
    var third = jsConsole.read("#third-number");

    if (first > second && first > third) {
        jsConsole.writeLine(first);

        if (second > third) {
            jsConsole.writeLine(second);
            jsConsole.writeLine(third);
        }
        else {
            jsConsole.writeLine(third);
            jsConsole.writeLine(second);
        }
    }

    else if (second > first && second > third) {
        jsConsole.writeLine(second);

        if (first > third) {
            jsConsole.writeLine(first);
            jsConsole.writeLine(third);
        }
        else {
            jsConsole.writeLine(third);
            jsConsole.writeLine(first);
        }
    }

    else if (third > first && third > second) {
        jsConsole.writeLine(third);

        if (first > second) {
            jsConsole.writeLine(first);
            jsConsole.writeLine(second);
        }
        else {
            jsConsole.writeLine(second);
            jsConsole.writeLine(first);
        }
    }
}