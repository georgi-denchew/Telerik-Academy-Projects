/// <reference path="class.js" />
var Animal = Class.create({
    init: function (species, name, numberOfLegs) {
        this.species = species;
        this.name = name;
        this.numberOfLegs = numberOfLegs;
    },
    toString: function () {
        return "species: " + this.species + "; name: " + this.name + "; legs: " + this.numberOfLegs + ";";
    }
});