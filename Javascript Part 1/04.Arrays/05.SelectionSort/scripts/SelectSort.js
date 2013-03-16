function SelectionSort() {
    var arr = [10, 2, 1, 1, 7, 45, 4, 6, 4];
    var sortedArr = new Array(arr.length);
    var i = 0;
    var j = 0;
    var smallest = arr[0];
    var arrPosition = 0;
    var smallestPosition;


    for (i; i < sortedArr.length; i++) {
        smallest = 9007199254740992;
        for (j = 0; j < arr.length; j++) {
            if (smallest >= arr[j]) {
                smallest = arr[j];
                arrPosition = j;
            }
        }
        sortedArr[i] = smallest;
        arr[arrPosition] = 9007199254740992;
        jsConsole.write(sortedArr[i])
        if (i != sortedArr.length - 1) {
            jsConsole.write(", ");
        }
    }
}