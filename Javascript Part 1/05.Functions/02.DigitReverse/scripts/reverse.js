function ReverseNumber() {
    var number = jsConsole.readInteger("#number");
    var strNumber = number.toString();
    var reversed = "";

    for (var i = (strNumber.length - 1) ; i >= 0; i--) {

        reversed += strNumber[i];
    }

    jsConsole.writeLine(reversed);
}