function OddOrEvenButtonClick() {
    var number = jsConsole.readInteger("#number");
    if (number % 2 == 0) {
        jsConsole.writeLine("The number is even");
    }
    else {
        jsConsole.writeLine("The number is odd");
    }
}