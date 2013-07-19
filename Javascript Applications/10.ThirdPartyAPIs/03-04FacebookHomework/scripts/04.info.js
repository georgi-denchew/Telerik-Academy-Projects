window.fbAsyncInit = function () {
    FB.init({
        appId: '207212666093569',
        channelUrl: '//http://localhost:20511/channel.html',
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

    FB.logout(function (response) {

    });
};

// Load the SDK asynchronously
(function (d) {
    var js, id = 'facebook-jssdk', ref = d.getElementsByTagName('script')[0];
    if (d.getElementById(id)) { return; }
    js = d.createElement('script'); js.id = id; js.async = true;
    js.src = "//connect.facebook.net/en_US/all.js";
    ref.parentNode.insertBefore(js, ref);
}(document));

function getProfileInfo() {
    FB.api('/me', function (response) {
        var holder = $("#profile-info");
        holder.append("<h1> Your birthday is:" + response.birthday + " Your country is:" + response.locale);
    });
    $("#log").css("display", "none");
}