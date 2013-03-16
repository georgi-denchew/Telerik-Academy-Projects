function BitThreeButtonClick() {
    var number = jsConsole.readInteger("#number");
    var result = number & (1 << 3);
    result = result >> 3;
    var bool = result == 1 ? "The bit at position three is 1." : "The bit at position three is 0.";
    jsConsole.writeLine(bool);
}