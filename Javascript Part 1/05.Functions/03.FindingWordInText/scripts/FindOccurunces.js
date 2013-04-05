function FindWord() {

    var text = "For though they may be parted, there is still a chance that they will see There will be an answer, let it be Let it be, let it be, let it be, let it be There will be an answer, let it be";
    var word = "Let";
    var caseSensitive = false;

    OccurnceWord(text, word, caseSensitive);

    function OccurnceWord(text, word, caseSensitive) {

        var count = 0;
        if (caseSensitive) {

            jsConsole.writeLine(count);
            var array = text.split();

            for (var str in array) {
                count++;
            }
            jsConsole.writeLine("Count of word occurunces: " + count);
        }
        else {

            var index = text.indexOf(word, 0);

            while (index != -1) {
                count++;
                index += word.length;
                index = text.indexOf(word, index + 1);
            }
            jsConsole.writeLine("Count of case sensitive word occurunces: " + count);
        }
    }
}