/// <reference path="require.js" />
/// <reference path="mustache.js" />
/// <reference path="data-persister.js" />
/// <reference path="http-requester.js" />

require.config({
    paths: {
        jquery: "jquery-2.0.3",
        rsvp: "rsvp.min",
        httpRequester: "http-requester",
        mustache: "mustache",
        controls: "controls"
    }
});

require(["jquery", "mustache", "data-persister", "controls"], function ($, mustache, data, controls) {
    debugger;
    data.students()
    .then(function (students) {

        var studentsTemplateString = $("#students-template").html();
        var template = mustache.compile(studentsTemplateString);

        var listView = controls.listView(students);
        var listViewHTML = listView.render(template);

        $("#content").html(listViewHTML);

        $("#content").on("click", "a", function (ev) {
            ev.preventDefault();
            var id = $(ev.target).attr("href");
            
            data.marks(id)
            .then(function (marks) {

                var marksTemplateString = $("#marks-template").html();
                var template = mustache.compile(marksTemplateString);

                var listView = controls.listView(marks);
                var listViewHTML = listView.render(template);

                $("#content").fadeOut(500, function () {
                    $("#content").html(listViewHTML);
                });
                $("#content").fadeIn(500);
            });
        });
    }, function (error) {
        console.log(error);
    });
});