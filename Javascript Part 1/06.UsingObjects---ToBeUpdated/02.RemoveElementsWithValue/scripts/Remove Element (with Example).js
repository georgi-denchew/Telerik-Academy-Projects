var arr = [1, 2, 3, 1, 3, 2, 1];

if (Array.prototype.remove == null) {
    Array.prototype.remove = function (number) {

        var newArr = new Array();


        for (var i = 0; i < this.length; i++) {
            if (this[i] != number) {
                newArr.push(this[i]);
            }
        }
        return newArr;
    }

}

var newArr = arr.remove(1);
jsConsole.writeLine(newArr);