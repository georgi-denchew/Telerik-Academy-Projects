/// <reference group="Dedicated Worker" />

var isPrime = function (number) {
    for (var i = 2; i < number; i++) {
        if (number % i == 0) {
            return false;
        }
    }
    return true;
}

var calculateInRangePrimes = function (fromNumber, toNumber) {
    var primesList = [];

    for (var num = fromNumber; num <= toNumber; num++) {
        if (isPrime(num)) {
            primesList.push(num);
        }
    }

    return primesList;
}

var calculateUpToPrimes = function (toNumber) {
    var primesList = [];

    for (var num = 0; num <= toNumber; num++) {
        if (isPrime(num)) {
            primesList.push(num);
        }
    }

    return primesList;
}

var calculateFirstPrimes = function (count) {
    var primesList = [];
    var num = 0;
    var primesCount = 0;

    while (true) {

        if (primesCount === count) {
            break;
        }

        if (isPrime(num)) {
            primesList.push(num);
            primesCount += 1;
        }
    }

    for (var num = 0; num <= toNumber; num++) {
        if (isPrime(num)) {
            primesList.push(num);
        }
    }

    return primesList;
}

onmessage = function (event) {
    var type = event.calculationType;

    if (type === "inRange") {
        var firstNumber = event.firstNumber;
        var lastNumber = event.lastNumber;
    }
}
