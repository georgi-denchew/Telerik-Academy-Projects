var Class = (function () {
    function createClass(properties) {
        var f = function () {
            this.init.apply(this, arguments);
        }

        for (var prop in properties) {
            f.prototype[prop] = properties[prop];
        }
        if (!f.prototype.init) {
            f.prototype.init = function () { }
        }
        return f;
    }

    return {
        create: createClass,
    };
}());

var City = Class.create({
    init: function (name, latitude, longtitude, information) {
        this.name = name;
        this.latitude = latitude;
        this.longtitude = longtitude;
        this.information = information;
    }
});

var cities = [];

var sofia = new City("Sofia", 42.70, 23.33, "Sofia (Bulgarian: София, \
    is the capital and largest city of Bulgaria. Sofia is located \
    at the foot of Mount Vitosha in the western part of the country.");
cities.push(sofia);

var berlin = new City("Berlin", 52.52, 13.39, "Berlin is the capital city of Germany and one of the 16\
    states of Germany. With a population of 3.3 million people, Berlin is Germany's \
largest city and is the second most populous city proper and the seventh most populous\
urban area in the European Union.");
cities.push(berlin);

var vienna = new City("Vienna", 48.20, 16.39, "Wien is the capital and largest city of Austria, and one of\
the nine states of Austria. Vienna is Austria's primary city, with a population of about\
1.757 million");
cities.push(vienna);

var prague = new City("Prague", 50, 14.45, "Prague is the capital and largest city of the Czech Republic.\
It is the fourteenth-largest city in the European Union. It is also the historical capital\
of Bohemia proper.");
cities.push(prague);

var moskow = new City("Moskow", 55.75, 37.66, "Moscow is the capital city and the most populous federal\
    subject of Russia. The city is a major political, economic, cultural and scientific \
center in Russia and in Eurasia.");
cities.push(moskow);

var rome = new City("Rome", 41.95, 12.50, "Rome is a city and special comune (named \"Roma Capitale\") in Italy.\
    Rome is the capital of Italy and also of the homonymous province and of the region of Lazio. ");
cities.push(rome);

var madrid = new City("Madrid", 40.35, -3.70, "Madrid is the capital of Spain and its largest city. The population \
of the city is roughly 3.3 million and the entire population of the Madrid metropolitan area is\
calculated to be around 6.5 million.");
cities.push(madrid);

var london = new City("London", 51.40, -0.1, "London is the capital of England and the United Kingdom. With \
an estimated 8,308,369 residents as of 2012, London is the most populous region, urban zone \
and metropolitan area in the United Kingdom.");
cities.push(london);

var washington = new City("Washington", 38.90, -77.05, "Washington, D.C., formally the District of Columbia and \
commonly referred to as Washington, \"the District\", or simply D.C., is the capital of the\
United States.");
cities.push(washington);

var tokyo = new City("Tokyo", 35.69, 139.69, "Tokyo, officially Tokyo Metropolis, is one of the 47 prefectures of Japan.\
Tokyo is the capital of Japan, the center of the Greater Tokyo Area, and the largest metropolitan\
area in the world.");
cities.push(tokyo);