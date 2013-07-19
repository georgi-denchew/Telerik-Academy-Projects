
var player;
var share = document.getElementById("share-tag");

function onYouTubeIframeAPIReady() {
    player = new YT.Player('player', {
        height: '390',
        width: '640',
        videoId: 'OV0bLtUoQKU',
        events: {
            'onReady': onPlayerReady,
        } 
    });
}

function onPlayerReady(event) {
    event.target.playVideo();
}

document.getElementById('single-video').addEventListener('click', function () {
    var video = document.getElementById('load-video').value;

    player.loadVideoById(video, 0, "large");
}, false);

document.getElementById('pause').addEventListener('click', function () {
    player.pauseVideo();
}, false);

document.getElementById('play').addEventListener('click', function () {
    player.playVideo();
}, false);

document.getElementById('stop').addEventListener('click', function () {
    player.stopVideo();
}, false);

document.getElementById('mute').addEventListener('click', function () {
    player.mute();
}, false);

document.getElementById('unmute').addEventListener('click', function () {
    player.unMute();
}, false);

document.getElementById('set_volume').addEventListener('click', function () {
    var volume = document.getElementById('volume').value;
    player.setVolume(volume);
}, false);

document.getElementById('quality').addEventListener('change', function () {
    player.setPlaybackQuality(this.value);
}, false);

document.getElementById('load-playlist').addEventListener('click', function () {
    var videoPlaylist = document.getElementById('playlist').value.split(',');

    player.loadPlaylist(videoPlaylist, 0, 0, "large");
}, false);

document.getElementById('previous').addEventListener('click', function () {
    player.previousVideo();
}, false);

document.getElementById('next').addEventListener('click', function () {
    player.nextVideo();
}, false);