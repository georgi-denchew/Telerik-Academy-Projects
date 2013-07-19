var initialWidth = 0;

window.fbAsyncInit = function () {
    FB.init({
        appId: '207212666093569', // App ID
        channelUrl: '//http://localhost:50989/channel.html', // Channel File
        status: true, // check login status
        cookie: true, // enable cookies to allow the server to access the session
        xfbml: true  // parse XFBML
    });

    FB.login(function (response) {
        if (response.authResponse) {
            getProfileInfo();
        } else {
            console.log('User cancelled login or did not fully authorize.');
        }
    }, { scope: 'read_friendlists,user_photos, user_birthday' });
};

// Load the SDK asynchronously
(function (d) {
    var js, id = 'facebook-jssdk', ref = d.getElementsByTagName('script')[0];
    if (d.getElementById(id)) { return; }
    js = d.createElement('script'); js.id = id; js.async = true;
    js.src = "//connect.facebook.net/en_US/all.js";
    ref.parentNode.insertBefore(js, ref);
}(document));

$("#show-friends").click(function () { getFriends() });

function getFriends() {
    FB.api('/me/friends', function (response) {
        var friendsHolder = $('#firends-holder');
        for (i = 0; i < response.data.length; i++) {
            var friendPictureUrl = 'https://graph.facebook.com/' + response.data[i].id + '/picture';
            var friendName = response.data[i].name;
            friendsHolder.append("<figure> <img src =" + friendPictureUrl + "/>" + "<figcaption>" + friendName +
                "</figcaption>" + "</figure>");
        }

        initialWidth = $("img").eq(0).width();
    });
}

$("body").click(function (ev) {

    var clicked = ev.target;

    if (clicked instanceof HTMLImageElement) {

        if ($(clicked).width() === initialWidth) {
            $(clicked).width(initialWidth * 2);
        }
        else {
            $(clicked).width(initialWidth);
        }        
    }
});