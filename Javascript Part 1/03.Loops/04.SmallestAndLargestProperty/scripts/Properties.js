
function PrintProperty() {
    var count = 0;
    var minDoc;
    var maxDoc;
    var prop
    var minWin;
    var maxWin;
    var propWin
    var minNav;
    var maxNav;
    var propNav;

    for (prop in document) {
        if (count == 0) {
            maxDoc = document[prop];
            minDoc = document[prop];
            count++;
        }
        else {
            if (maxDoc < document[prop]) {
                maxDoc = document[prop];
            }
            else if (minDoc > document[prop]) {
                minDoc = document[prop];
            }
        }
    }
    jsConsole.writeLine("Smallest property in document is: " + minDoc);
    jsConsole.writeLine("Largest prperty in documnet is: " + maxDoc);

    count = 0;
    for (propWin in window) {
        if (count == 0) {
            minWin = window[propWin];
            maxWin = window[propWin];
            count++;
        }
        else {
            if (minWin > window[propWin]) {
                minWin = window[propWin];
            }
            else if (maxWin < window[propWin]) {
                maxWin = window[propWin];
            }
        }
    }

    jsConsole.writeLine("Smallest property in window is: " + minWin);
    jsConsole.writeLine("Largest prperty in window is: " + maxWin);

    count = 0;
    for (propNav in navigator) {
        if (count == 0) {
            maxNav = navigator[propNav];
            minNav = navigator[propNav];
            count++;
        }
        else {
            if (maxNav < navigator[propNav]) {
                maxNav = navigator[propNav];
            }
            else if (minNav > navigator[propNav]) {
                minNav = navigator[propNav];
            }
        }
    }
    jsConsole.writeLine("Smallest property in navigator is: " + minNav);
    jsConsole.writeLine("Largest property in navigator is: " + maxNav);
}