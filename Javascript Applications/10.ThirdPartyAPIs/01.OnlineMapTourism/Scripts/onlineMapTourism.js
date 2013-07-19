(function () {

    var citiesCount = cities.length;
    var index = 4;
    var map;
    var nextButton = $("#next_button");
    var previousButton = $("#previous_button");
    var infoWindow;
    var pos;
    var marker;
    var select = $("select");

    function initialize(city) {
        var mapOptions = {
            zoom: 5,
            center: new google.maps.LatLng(city.latitude, city.longtitude),
            mapTypeId: google.maps.MapTypeId.ROADMAP //ROADMAP
        };
        map = new google.maps.Map(document.getElementById('map-canvas'),
            mapOptions);

        pos = new google.maps.LatLng(city.latitude,
        city.longtitude);

        infoWindow = new google.maps.InfoWindow({
            map: map,
            position: pos,
            content: city.information
        });

        marker = new google.maps.Marker({
            map: map,
            position: pos,
            title: city.name
        });

    };
    google.maps.event.addDomListener(window, 'load', initialize(cities[index]));

    function updatePosition() {
        pos = new google.maps.LatLng(cities[index].latitude,
            cities[index].longtitude);
        map.panTo(pos);
        infoWindow.setPosition(pos);
        infoWindow.setContent(cities[index].information);
        marker.setPosition(pos);
        marker.setTitle(cities[index].name);
        select.val(index);
    }

    nextButton.click(function () {
        if (index < citiesCount - 1) {
            index++;
        }
        else {
            index = 0;
        }

        updatePosition();
    });

    previousButton.click(function () {
        if (index > 0) {
            index--;
        }
        else {
            index = citiesCount - 1;
        }

        updatePosition();
    });

    select.change(function () {
        index = select.val();
        updatePosition();
    });

})();