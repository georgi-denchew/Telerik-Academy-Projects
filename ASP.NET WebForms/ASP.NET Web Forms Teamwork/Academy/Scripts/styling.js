/// <reference path="_references.js" />
$(document).ready(function () {
    var menuDiv = $("#MenuSiteMap");
    menuDiv.children("ul").addClass("nav nav-pills nav-stacked");

    var divToRemove = menuDiv.next();
    divToRemove.remove();

    $("table > input").text = "hi";
    console.log("i am here");
});