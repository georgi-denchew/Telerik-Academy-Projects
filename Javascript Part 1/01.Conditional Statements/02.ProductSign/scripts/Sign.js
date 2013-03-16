function Sign() {
    var first = jsConsole.readInteger("#first-number");
    var second = jsConsole.readInteger("#second-number");
    var third = jsConsole.readInteger("#third-number");
    var isPlus = true;

    if (first < 0) {
        isPlus = false;
    }

    if (second < 0) {
        if (isPlus) {
            isPlus = false;
        }
        else {
            isPlus = true;
        }
    }

    if (third < 0) {
        if (isPlus) {
            isPlus = false;
        }
        else {
            isPlus = true;
        }
    }
    jsConsole.writeLine(isPlus ? "The sign of the product is: +" : "The sign of the product is: -");
}