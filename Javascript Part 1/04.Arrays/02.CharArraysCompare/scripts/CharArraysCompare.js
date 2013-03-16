function CharArraysCompare() {
    var arr1 = new Array('a', 'b', 'c', 'd', 'e');
    var arr2 = new Array('a', 'c', 'a', 'd', 'e');
    var i = 0;

    for (i; i < arr1.length; i++) {
        if (arr1[i] > arr2[i]) {
            jsConsole.writeLine(arr1[i] + " > " + arr2[i]);
        }
        else if (arr1[i] == arr2[i]) {
            jsConsole.writeLine(arr1[i] + " = " + arr2[i]);
        }
        else {
            jsConsole.writeLine(arr1[i] + " < " + arr2[i]);
        }
    }
}