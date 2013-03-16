function ConvertToText() {
    var number = jsConsole.readInteger("#number");
    var str = number.toString();
    var i = 0;
    //jsConsole.writeLine(str.length);
    //jsConsole.writeLine(str[i]);
    if (str == "0") {
        jsConsole.writeLine("Zero");
    }

    if (str.length > 2) {
        switch (str[i]) {
            case "1": jsConsole.write("One hundred"); break;
            case "2": jsConsole.write("Two hundred"); break;
            case "3": jsConsole.write("Three hundred"); break;
            case "4": jsConsole.write("Four hundred"); break;
            case "5": jsConsole.write("Five hundred"); break;
            case "6": jsConsole.write("Six hundred"); break;
            case "7": jsConsole.write("Seven hundred"); break;
            case "8": jsConsole.write("Eight hundred"); break;
            case "9": jsConsole.write("Nine hundred"); break;
        }
        i++;
    }
    if (str.length > 2 && str[1] != "0") {
        jsConsole.write(" and ");
    }
    var isOne = false;

    if (str.length > 1) {
        switch (str[i]) {
            case "0":
                if (str[i + 1] != "0") {
                    jsConsole.write(" and ");
                }
                break;
            case "1":
                isOne = true;
                switch (str[i + 1]) {
                    case "0": jsConsole.writeLine("ten"); break;
                    case "1": jsConsole.writeLine("eleven"); break;
                    case "2": jsConsole.writeLine("twelve"); break;
                    case "3": jsConsole.writeLine("thirteen"); break;
                    case "4": jsConsole.writeLine("fourteen"); break;
                    case "5": jsConsole.writeLine("fifteen"); break;
                    case "6": jsConsole.writeLine("sixteen"); break;
                    case "7": jsConsole.writeLine("seventeen"); break;
                    case "8": jsConsole.writeLine("eighteen"); break;
                    case "9": jsConsole.writeLine("nineteen"); break;
                } break;
            case "2": jsConsole.write("twenty "); break;
            case "3": jsConsole.write("thirty "); break;
            case "4": jsConsole.write("forty "); break;
            case "5": jsConsole.write("fifty "); break;
            case "6": jsConsole.write("sixty "); break;
            case "7": jsConsole.write("seventy "); break;
            case "8": jsConsole.write("eighty "); break;
            case "9": jsConsole.write("ninety "); break;
        }
        i++;
    }

    if (!isOne) {
        switch (str[i]) {
            case "0": jsConsole.writeLine(); break;
            case "1": jsConsole.writeLine("one"); break;
            case "2": jsConsole.writeLine("two"); break;
            case "3": jsConsole.writeLine("three"); break;
            case "4": jsConsole.writeLine("four"); break;
            case "5": jsConsole.writeLine("five"); break;
            case "6": jsConsole.writeLine("six"); break;
            case "7": jsConsole.writeLine("seven"); break;
            case "8": jsConsole.writeLine("eight"); break;
            case "9": jsConsole.writeLine("nine"); break;
        }
    }

}