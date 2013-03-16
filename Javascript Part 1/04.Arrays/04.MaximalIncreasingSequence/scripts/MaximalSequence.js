function MaximalSequence() {
    var numbers = [1, 2, 3, 4, 6, 8, 7, 8, 9, 10, 11, 12, 14, 16];
    var count = 1;
    var maxCount = 1;
    var last;
    var i = 1;
    var j;

    for (i; i < numbers.length; i++) {


        if (numbers[i] == numbers[i - 1] + 1) {
            count++;
            if (maxCount < count) {
                maxCount = count;
                last = numbers[i];
            }
        }
        else {
            count = 1;
        }
    }
    for (j = last - maxCount + 1; j <= last; j++) {
        jsConsole.write(j);
        if (j != last) {
            jsConsole.write(", ");
        }
        
    }
    jsConsole.writeLine();
}