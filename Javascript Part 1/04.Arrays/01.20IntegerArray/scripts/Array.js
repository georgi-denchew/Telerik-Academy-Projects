function IntegerArrayButtonClick() {
    var arr = new Array(20);
    var i = 0;

    for (i; i < arr.length; i++) {
        arr[i] = i * 5;
        jsConsole.write(arr[i]);
        if (i != arr.length - 1) {
            jsConsole.write(", ");
        }
    }
}