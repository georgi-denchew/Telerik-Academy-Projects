function MostFrequentNumberButtonClick() {
    var arr = [4, 1, 1, 4, 1, 1, 4, 4, 1, 1, 4, 9, 3];
    var checkArr = new Array(arr.length);
    var checked = false;
    var i = 0;
    var j = 0;
    var count = 0;
    var maxCount = 0;
    var number;

    for (i; i < arr.length; i++) {

        checked = false;

        for (j; j < checkArr.length; j++) {
            if (checkArr[j] == arr[i]) {
                checked = true;
                break;
            }
        }

        if (!checked) {
            for (j = 0; j < arr.length; j++) {
                if (arr[i] == arr[j]) {
                    count++;
                    if (maxCount < count) {
                        maxCount = count;
                        number = arr[i];
                    }
                }
            }
            count = 0;
        }
    }
    jsConsole.writeLine(number + "(" + maxCount + " times)");
}