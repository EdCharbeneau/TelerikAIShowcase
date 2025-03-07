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

export async function load(dataUri, visualizer) {
    audioPlayer.src = dataUri;
    loadVisualizer(visualizer);
}

function loadVisualizer(visualizer) {
    const canvas = visualizer;
    const ctx = canvas.getContext('2d');
    const styles = getComputedStyle(visualizer);
    const barColor = styles.getPropertyValue('--kendo-color-primary');

    const audioContext = new (window.AudioContext || window.webkitAudioContext)();
    const analyser = audioContext.createAnalyser();

    // Connect audio element to the analyser
    const source = audioContext.createMediaElementSource(audioPlayer);
    source.connect(analyser);
    analyser.connect(audioContext.destination);

    // Configure analyser
    analyser.fftSize = 2048;
    const bufferLength = analyser.frequencyBinCount;
    const dataArray = new Uint8Array(bufferLength);

    // Drawing function
    function draw() {
        requestAnimationFrame(draw);
        if (audioPlayer.ended) {
            return;
        }

        analyser.getByteTimeDomainData(dataArray);

        // Clear canvas
        ctx.fillRect(0, 0, canvas.width, canvas.height);
        ctx.strokeStyle = barColor;
        ctx.fillStyle = 'rgb(72 42 95)';
        //ctx.fillStyle = 'rgba(168, 21, 97, 0.8)';

        for (let i = 0; i < bufferLength; i++) {
            const v = dataArray[i]/ 16.0;

            ctx.lineWidth = 4;

            ctx.strokeRect(v, v, canvas.width - v * 2 , canvas.height - v * 2);
        }
    }

    // Start visualization when audio plays
    audioPlayer.addEventListener('play', () => {
        if (audioContext.state === 'suspended') {
            audioContext.resume();
        }
        draw();
    });

    audioPlayer.addEventListener('ended', () => {
        ctx.clearRect(0, 0, canvas.width, canvas.height);
    });
}; 