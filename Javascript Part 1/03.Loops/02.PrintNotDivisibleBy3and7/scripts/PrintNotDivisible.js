function PrintNotDivisibleButtonClick() {
    var number = jsConsole.readInteger("#N");
    var i = 1;

    for (i = 1; i <= number; i++) {
        if (i % 3 != 0 && i % 7 != 0) {
            jsConsole.write(i);

            if (i != number) {
                jsConsole.write(", ");
            }
        }
    }
}