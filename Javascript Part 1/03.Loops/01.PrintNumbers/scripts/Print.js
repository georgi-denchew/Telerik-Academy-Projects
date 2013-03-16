function PrintButtonClick() {
    var number = jsConsole.readInteger("#N");
    var i = 0;

    for (i = 1; i <= number; i++) {
        jsConsole.write(i)
        if (i != number) {
            jsConsole.write(", ")
        }
    }
}