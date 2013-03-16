function FindGreatestButtonClick() {
    var first = jsConsole.readInteger("#first");
    var second = jsConsole.readInteger("#second");
    var third = jsConsole.readInteger("#third");
    var fourth = jsConsole.readInteger("#fourth");
    var fifth = jsConsole.readInteger("#fifth");

    if (first >= second && first >= third && first >= fourth && first >= fifth) {
        jsConsole.writeLine("The greatest number is: " + first);
    }

    if (second > first && second >= third && second >= fourth && second >= fifth) {
        jsConsole.writeLine("The greatest number is: " + second);
    }

    if (third > first && third > second && third >= fourth && third >= fifth) {
        jsConsole.writeLine("The greatest number is: " + third);
    }

    if (fourth > first && fourth > second && fourth > third && fourth >= fifth) {
        jsConsole.writeLine("The greatest number is: " + fourth);
    }

    if (fifth > first && fifth > second && fifth > third && fifth > fourth) {
        jsConsole.writeLine("The greatest number is: " + fifth);
    }
}