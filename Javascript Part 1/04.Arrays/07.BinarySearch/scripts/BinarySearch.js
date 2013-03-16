function BinarySearchButtonClick() {

    var number = 3;
    var arr = [1, 3, 4, 10, 2, 6, 22, 5, 7, 8, 9];
    var middle = Math.floor(arr.length / 2);
    var start = 0;
    var end = arr.length - 1;
    var i = 0
    function orderBy(a, b) {
        return (a == b) ? 0 : (a > b) ? 1 : -1
    };

    arr.sort(orderBy);
    jsConsole.writeLine("The array is:");
    for (i = 0; i < arr.length; i++) {
        jsConsole.write(arr[i] + " ");
    }

    jsConsole.writeLine();
    jsConsole.writeLine("The number of the index we are looking for (can be changed from the file) : " + number);

    while (arr[middle] != number) {
        if (arr[middle] > number) {
            end = middle;
            middle = Math.floor((start + end) / 2);
        }
        else {
            start = middle;
            middle = Math.round((start + end) / 2);
        }

    }
    jsConsole.writeLine("The index of the number is: " + middle);

}