function IsPrimeButtonClick() {
    var number = jsConsole.readInteger("#number");

    if (number % 2 == 0) {
        if (number == 2) {
            jsConsole.writeLine("The number is prime.");
            return;
        }
        else {
            jsConsole.writeLine("The number isn't prime.");
            return;
        }
    }

    else {
        for (var i = 3; i <= Math.sqrt(number) ; i++) {
            if (number % i == 0) {
                jsConsole.writeLine("The number isn't prime.");
                return;
            }
        }
        jsConsole.writeLine("The number is prime.");
        return;
    }
}