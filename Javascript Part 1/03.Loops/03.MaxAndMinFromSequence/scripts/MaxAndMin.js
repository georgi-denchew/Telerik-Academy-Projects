function MaxAndMin() {
    var numbers = [10, 2, 3, 4, 1, 60, 7, 8, 9];
    var min = numbers[0];
    var max = numbers[0];
    var i = 0

    for (i; i < numbers.length; i++) {
        if (max < numbers[i]) {
            max = numbers[i]
        }
        else if (min > numbers[i]) {
            min = numbers[i];
        }
    }
    jsConsole.writeLine("Max number: " + max);
    jsConsole.writeLine("Min number: " + min);
}