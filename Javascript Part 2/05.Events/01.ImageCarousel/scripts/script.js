(function () {
    var leftButton = document.getElementById("left_button"),
    rightButton = document.getElementById("right_button"),
    image = document.getElementById('image'),
    currentImageNumber = 1;


    var nextImage = function placeNextImage() {

        if (urlExists("imgs/" + (currentImageNumber + 1) + ".jpg")) {
            currentImageNumber += 1;
            image.src = "imgs/" + currentImageNumber + ".jpg";
        }
    }

    var previousImage = function placePreviousImage() {
        ;

        if (urlExists("imgs/" + (currentImageNumber - 1) + ".jpg")) {

            currentImageNumber -= 1;
            image.src = "imgs/" + currentImageNumber + ".jpg";
        }
    }

    function urlExists(url) {
        var http = new XMLHttpRequest();
        http.open('head', url, false);
        http.send();
        return http.status != 404;
    }

    left_button.addEventListener("click", previousImage, false);
    rightButton.addEventListener("click", nextImage, false);
})();