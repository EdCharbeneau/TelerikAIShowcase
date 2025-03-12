var dotnetInstance;
var audioPlayer;
let visualizerInstance;

export async function init(audioTagRef, targetCanvas, dotnet) {
    dotnetInstance = dotnet;
    audioPlayer = audioTagRef;
    audioPlayer.canplay = () => dotnetInstance.invokeMethodAsync("OnSourceChangedHandler");
    console.log(audioTagRef);

    if (targetCanvas && targetCanvas !== '') {
        visualizerInstance = new AudioVisualizer(audioPlayer, targetCanvas);
    }
}

export async function play() {
    audioPlayer.play();
}

export async function pause() {
    audioPlayer.pause();
}

export async function stop() {
    audioPlayer.currentTime = audioPlayer.duration;
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

class AudioVisualizer {
    constructor(audioPlayer, canvasId) {
        this.audioPlayer = audioPlayer;
        this.canvas = document.getElementById(canvasId);
        this.parent = this.canvas.parentElement;
        this.ctx = this.canvas.getContext('2d');
        const styles = getComputedStyle(this.canvas);
        this.barColor = styles.getPropertyValue('--kendo-color-primary');

        this.audioContext = new (window.AudioContext || window.webkitAudioContext)();
        this.analyser = this.audioContext.createAnalyser();

        // Connect audio element to the analyser
        this.source = this.audioContext.createMediaElementSource(this.audioPlayer);
        this.source.connect(this.analyser);
        this.analyser.connect(this.audioContext.destination);

        // Configure analyser
        this.analyser.fftSize = 2048;
        this.bufferLength = this.analyser.frequencyBinCount;
        this.dataArray = new Uint8Array(this.bufferLength);

        this.canvas.width = this.parent.clientWidth;
        this.canvas.height = this.parent.clientHeight;

        // Add ResizeObserver to update canvas size
        this.resizeObserver = new ResizeObserver(() => {
            this.canvas.width = this.parent.clientWidth;
            this.canvas.height = this.parent.clientHeight;
        });
        this.resizeObserver.observe(this.parent);

        this.audioPlayer.addEventListener('play', () => {
            if (this.audioContext.state === 'suspended') {
                this.audioContext.resume();
            }
            this.draw();
        });

        this.audioPlayer.addEventListener('ended', () => {
            this.ctx.clearRect(0, 0, this.canvas.width, this.canvas.height);
        });
    }

    dispose() {
        if (this.source) {
            this.source.disconnect();
            this.source = null;
        }
        if (this.analyser) {
            this.analyser.disconnect();
            this.analyser = null;
        }
        if (this.audioContext) {
            this.audioContext.close();
            this.audioContext = null;
        }
        if (this.resizeObserver) {
            this.resizeObserver.disconnect();
            this.resizeObserver = null;
        }
    }

    draw() {
        requestAnimationFrame(() => this.draw());
        if (this.audioPlayer.ended) {
            return;
        }

        this.analyser.getByteTimeDomainData(this.dataArray);

        // Clear canvas
        this.ctx.clearRect(0, 0, this.canvas.width, this.canvas.height);
        this.ctx.strokeStyle = this.barColor;
        this.ctx.fillStyle = 'rgb(72 42 95)';

        for (let i = 0; i < this.bufferLength; i++) {
            const v = this.dataArray[i] / 16.0;
            this.ctx.lineWidth = 4;
            this.ctx.strokeRect(v, v, this.canvas.width - v * 2, this.canvas.height - v * 2);
        }
    }

    dispose() {
        if (this.source) {
            this.source.disconnect();
            this.source = null;
        }
        if (this.analyser) {
            this.analyser.disconnect();
            this.analyser = null;
        }
        if (this.audioContext) {
            this.audioContext.close();
            this.audioContext = null;
        }
    }
}