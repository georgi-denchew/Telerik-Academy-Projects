function ThirdDigit7ButtonClick() {
    var number = jsConsole.readInteger("#number");
    var number = number / 100;
    if (Math.floor(number) % 10 == 7) {
        jsConsole.writeLine("The third digit of the number is 7");
    }
    else {
        jsConsole.writeLine("The third digit of the number is different than 7");
    }
}