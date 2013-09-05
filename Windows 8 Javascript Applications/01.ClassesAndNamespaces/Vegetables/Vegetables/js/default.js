// For an introduction to the Blank template, see the following documentation:
// http://go.microsoft.com/fwlink/?LinkId=232509
(function () {

    WinJS.Binding.optimizeBindingReferences = true;

    var app = WinJS.Application;
    var activation = Windows.ApplicationModel.Activation;

    app.onactivated = function (args) {

        console = new DomLogger(document.getElementById("output"));
        
        var vegetable = new Plants.Vegetable("black", 10, true);
        console.log("vegetable color: " + vegetable.color);
        console.log("vegetable directly eatable: " + vegetable.directlyEatable);
        console.log("---");

        var cucumber = new Plants.GMO.CucumberGmo(5);
        console.log("cucumber color: " + cucumber.color);
        console.log("cucumber directly eatable: " + cucumber.directlyEatable);
        console.log("cucumber length: " + cucumber.length);
        cucumber.grow(5);
        console.log("cucumber length after growth: " + cucumber.length);

        console.log("---");

        var tomato = new Plants.GMO.TomatoGmo(4);
        console.log("tomato color: " + tomato.color);
        console.log("tomato directly eatable: " + tomato.directlyEatable);
        console.log("tomato radius: " + tomato.radius);
        tomato.grow(10);
        console.log("tomato radius after growth: " + tomato.radius);
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
