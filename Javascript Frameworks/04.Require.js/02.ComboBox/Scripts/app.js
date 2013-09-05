/// <reference path="require.js" />
require.config({
    paths: {
        jquery: "jquery-2.0.3",
        mustache: "mustache",
        controls: "controls",
        dataPersister: "data-persister",
        underscore: "underscore"
    }
});


require(["jquery", "mustache", "dataPersister", "controls"], function ($, mustache, data, controls) {
    var people = data.people();

    var peopleTemplateString = $("#people-template").html();
    var peopleTemplate = mustache.compile(peopleTemplateString);

    var peopleComboBox = controls.comboBox(people);
    var comboBoxHTML = peopleComboBox.render(peopleTemplate);

    $('#combo-box').html(comboBoxHTML);

    $("#combo-box").change(function (ev) {

        var id = $("#combo-box option:selected").attr("value");
        
        var person = data.details(id);

        var detailsTemplateString = $("#details-template").html();
        var detailsTemplate = mustache.compile(detailsTemplateString);

        var detailsComboBox = controls.detailsBox(person);
        var detailsBoxHTML = detailsComboBox.render(detailsTemplate);

        $("#content").html(detailsBoxHTML);
    });
});