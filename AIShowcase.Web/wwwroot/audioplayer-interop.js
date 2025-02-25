var dotnetInstance;
var audioPlayer;

export async function init(audioTagRef, dotnet) {
    dotnetInstance = dotnet;
    audioPlayer = audioTagRef;
    audioPlayer.canplay = () => dotnetInstance.invokeMethodAsync("OnSourceChangedHandler");
    console.log(audioTagRef);
}

export async function play() {
    audioPlayer.play();
    console.log(audioPlayer);
}

export async function pause() {
    audioPlayer.pause();
}

export async function stop() {
    audioPlayer.pause();
    audioPlayer.currentTime = 0;
}

export async function setVolume(volume) {
    audioPlayer.volume = volume;
}

export async function muted(isMuted) {
    audioPlayer.muted = isMuted;
}

export async function load(dataUri) {
    audioPlayer.src = dataUri;
}