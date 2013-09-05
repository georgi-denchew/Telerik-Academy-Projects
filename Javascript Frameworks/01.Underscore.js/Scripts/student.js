/// <reference path="class.js" />

var Student = Class.create({
    init: function (firstName, lastName, age, marks) {
        this.firstName = firstName;
        this.lastName = lastName;
        this.age = age;
        this.marks = marks;
    },
    toString: function () {
        return this.firstName + " " + this.lastName;
    }
});
