function CalculateAreaButtonClick()
{
    var width = jsConsole.readInteger("#width");
    var height = jsConsole.readInteger("#height");
    var area = width * height;

    jsConsole.writeLine("The rectangle's area is " + area);
}