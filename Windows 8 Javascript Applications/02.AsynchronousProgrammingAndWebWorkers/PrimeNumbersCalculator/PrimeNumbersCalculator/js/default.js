// For an introduction to the Blank template, see the following documentation:
// http://go.microsoft.com/fwlink/?LinkId=232509
(function () {
    "use strict";

    WinJS.Binding.optimizeBindingReferences = true;

    var app = WinJS.Application;
    var activation = Windows.ApplicationModel.Activation;

    app.onactivated = function (args) {
        primesFirstWorker = new Worker("/js/primesFirstWorker.js");
        primesFirstWorker.onmessage = function (event) {
            var primesPar = document.createElement("p");
            primesPar.innerText = event.data.join(", ");
            document.body.appendChild(primesPar);
        }

        var calculatePrimesInRangeButton = document.getElementById("calculate-primes-in-range");
        var primesFirstInput = document.getElementById("primes-first");
        var primesLastInput = document.getElementById("primes-last");

        calculatePrimesInRangeButton.addEventListener("click", function () {
            primesWorker.postMessage(
                {
                    calculationType: "inRange",
                    firstNumber: primesFirstInput.value,
                    lastNumber: primesLastInput.value
                });
        });
    };

    app.oncheckpoint = function (args) {
        // TODO: This application is about to be suspended. Save any state
        // that needs to persist across suspensions here. You might use the
        // WinJS.Application.sessionState object, which is automatically
        // saved and restored across suspension. If you need to complete an
        // asynchronous operation before your application is suspended, call
        // args.setPromise().
    };

    app.start();
})();
