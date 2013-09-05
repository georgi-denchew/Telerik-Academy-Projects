/// <reference path="underscore.js" />
define(["underscore"], function () {
    var people = [
        { id: 1, name: "Doncho Minkov", age: 18, avatarUrl: "images/minkov.jpg" },
        { id: 2, name: "Georgi Georgiev", age: 15, avatarUrl: "images/joreto.jpg" },
        { id: 3, name: "Svetlin Nakov", age: 16, avatarUrl: "images/nakov.jpg" }
    ];

    function getPeople() {
        return people;
    }

    function getDetails(id) {
        var selected = _.chain(people).filter(function (p) {
            return p.id == id;
        });

        return selected.first()._wrapped;
    }

    return {
        people: getPeople,
        details: getDetails
    }
});