var sliderControl = (function () {

    function removeAllChildren(parent) {
        while (parent.firstChild) {
            parent.removeChild(parent.firstChild);
        }
    };

    var Container = {
        init: function (thumbnailsSelector, imageSelector, leftButton, rightButton) {

            this.thumbnailContainer = document.querySelector(thumbnailsSelector);
            this.imageContainer = document.querySelector(imageSelector);
            this.leftButton = document.querySelector(leftButton);
            this.rightButton = document.querySelector(rightButton);
            this.thumbnails = [];
            var that = this;

            this.thumbnailContainer.addEventListener("click", function (ev) {

                if (ev.target instanceof HTMLImageElement) {
                    var imageTag = ev.target;

                    for (var i = 0, len = that.thumbnails.length; i < len; i++) {
                        if (imageTag.title === that.thumbnails[i].name) {
                            var imageToDisplay = that.thumbnails[i];
                        }
                    }

                    removeAllChildren(that.imageContainer);
                    that.imageContainer.appendChild(imageToDisplay.createImage());
                }
            }, false);

            this.leftButton.addEventListener("click", function () {
                var currentImage = that.imageContainer.firstChild;

                for (var i = 0, len = that.thumbnails.length; i < len; i++) {
                    if (currentImage.title === that.thumbnails[i].name && i > 0) {

                        var imageToDisplay = that.thumbnails[i - 1];

                        removeAllChildren(that.imageContainer);

                        that.imageContainer.appendChild(imageToDisplay.createImage());
                    }
                }
            }, false);

            this.rightButton.addEventListener("click", function () {
                var currentImage = that.imageContainer.firstChild;

                for (var i = 0, len = that.thumbnails.length; i < len; i++) {
                    if (currentImage.title === that.thumbnails[i].name && i < len - 1) {

                        var imageToDisplay = that.thumbnails[i + 1];
                        removeAllChildren(that.imageContainer);
                        that.imageContainer.appendChild(imageToDisplay.createImage());
                    }
                }
            }, false);
        },
        addThumbnail: function (image) {
            this.thumbnails.push(image);
        },
        displayThumbnails: function () {
            var fragment = document.createDocumentFragment();

            //clean the container!
            while (this.thumbnailContainer.firstChild) {
                this.thumbnailContainer.removeChild(this.thumbnailContainer.firstChild);
            }

            for (var i = 0, len = this.thumbnails.length; i < len; i++) {

                fragment.appendChild(this.thumbnails[i].createThumbnail());
            }

            this.thumbnailContainer.appendChild(fragment);
        },

    };

    var Image = {
        init: function (name, thumbnailURL, largeURL) {
            this.name = name;
            this.thumbnailURL = thumbnailURL;
            this.largeURL = largeURL;
        },
        createThumbnail: function () {
            var thumbnailElement = document.createElement("img");
            thumbnailElement.src = this.thumbnailURL;
            thumbnailElement.title = this.name;
            return thumbnailElement;
        },
        createImage: function () {
            var imageElement = document.createElement("img");
            imageElement.src = this.largeURL;
            imageElement.title = this.name;
            return imageElement;
        }
    };

    return {
        getThumbnailContainer: function () {
            return Object.create(Container);
        },
        Image: function () {
            return Object.create(Image);
        }
    }

})();