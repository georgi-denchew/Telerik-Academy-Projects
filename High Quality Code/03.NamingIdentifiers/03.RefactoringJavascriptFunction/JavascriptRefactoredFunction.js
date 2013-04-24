function buttonClick(event, arguments) {
    var myWindow = window;
    var browserType = myWindow.navigator.appCodeName;
    var isMozilla = function() {
        return browserType === "Mozilla";
    }

    if (isMozilla) {
        alert("Yes");
    }
    else {
        alert("No");
    }
    console.log(isMozilla);
}
