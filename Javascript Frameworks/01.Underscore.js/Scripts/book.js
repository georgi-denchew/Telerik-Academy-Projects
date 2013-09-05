var Book = Class.create({
    init: function (name, author) {
        this.name = name;
        this.author = author;
    },
    toString: function () {
        return "name: " + this.name + "; author: " + this.author + ";";
    }
});