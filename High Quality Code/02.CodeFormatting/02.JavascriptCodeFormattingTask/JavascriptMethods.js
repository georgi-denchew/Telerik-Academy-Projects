function methods() {
    "use strict";
    var browser = navigator.appName;
    var addScroll = false;
    var theLayer;

    if ((navigator.userAgent.indexOf('MSIE 5') > 0) ||
        (navigator.userAgent.indexOf('MSIE 6')) > 0) {
        addScroll = true;
    }

    var off = 0;
    var txt = '';
    var xPosition = 0;
    var yPosition = 0;
    document.onmousemove = mouseMove;

    if (browser === 'Netscape') {
        document.captureEvents(Event.MOUSEMOVE);
    }

    function mouseMove(evn) {
        if (browser === 'Netscape') {
            xPosition = evn.pageX - 5; yPosition = evn.pageY;
        }
        else {
            xPosition = event.x - 5; yPosition = event.y;
        }

        if (browser === 'Netscape') {
            if (document.layers.ToolTip.visibility === 'show') {
                popTip();
            }
        }
        else {
            if (document.all.ToolTip.style.visibility === 'visible') {
                popTip();
            }
        }
    }

    function popTip() {
        if (browser === 'Netscape') {
            theLayer = document.layers.ToolTip;
            if ((xPosition + 120) > window.innerWidth) {
                xPosition = window.innerWidth - 150;
            }

            theLayer.left = xPosition+ 10;
            theLayer.top = yPosition + 15;
            theLayer.visibility = 'show';
        }
        else {
            theLayer = document.all.ToolTip;

            if (theLayer) {
                xPosition = event.x - 5; yPosition = event.y;

                if (addScroll) {
                    xPosition = xPosition + document.body.scrollLeft;
                    yPosition = yPosition + document.body.scrollTop;
                }

                if ((xPosition + 120) > document.body.clientWidth) {
                    xPosition = xPosition - 150;
                }

                theLayer.style.pixelLeft = xPosition + 10;
                theLayer.style.pixelTop = yPosition + 15;
                theLayer.style.visibility = 'visible';
            }
        }
    }

    function hideTip() {

        if (browser === 'Netscape') {
            document.layers.ToolTip.visibility = 'hide';
        }
        else {
            document.all.ToolTip.style.visibility = 'hidden';
        }
    }

    function hideMenu1() {
        if (browser === 'Netscape') {
            document.layers.menu1.visibility = 'hide';
        }
        else {
            document.all.menu1.style.visibility = 'hidden';
        }
    }

    function showMenu1() {
        if (browser === 'Netscape') {
            theLayer = document.layers.menu1;
            theLayer.visibility = 'show';
        }
        else {
            theLayer = document.all.menu1;
            theLayer.style.visibility = 'visible';
        }
    }

    function hideMenu2() {
        if (browser === 'Netscape') {
            document.layers.menu2.visibility = 'hide';
        }
        else {
            document.all.menu2.style.visibility = 'hidden';
        }
    }

    function showMenu2() {
        if (browser === 'Netscape') {
            theLayer = document.layers.menu2;
            theLayer.visibility = 'show';
        }
        else {
            theLayer = document.all.menu2;
            theLayer.style.visibility = 'visible';
        }
    }
}