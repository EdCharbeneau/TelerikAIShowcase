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

//async function getWaveformData() {
//    var context = new AudioContext();
//    var src = context.createMediaElementSource(audioPlayer);
//    const response = await fetch(audioPlayer.src);
//    console.log(response);
//    var buffer = await context.decodeAudioData(await response.arrayBuffer());
//    console.log(buffer);
//    const data = buffer.getChannelData(0);
//    console.log(data);
//    //return dataArray;
//}

//async function invokeRenderWave() {
//    const file = await fetch(audioPlayer.src);
//    var wave = new renderWave(file.arrayBuffer());
//    // audioPlayer.play();
//    audioPlayer.ontimeupdate = function () {
//        let percent = this.currentTime / this.duration;
//        wave.drawTimeline(percent);
//    };
//}

//async function invokeRenderWave() {
//    const file = await fetch(audioPlayer.src);
//    var wave = new renderBars(file.arrayBuffer());
//    // audioPlayer.play();
//    audioPlayer.ontimeupdate = function () {
//        let percent = this.currentTime / this.duration;
//        wave.drawTimeline(percent);
//    };
//}

//"use strict";
//window.AudioContext = window.AudioContext || window.webkitAudioContext;
//class renderWave {
//    constructor(message) {
//        this._samples = 10000;
//        this._strokeStyle = "#3098ff";
//        this.audioContext = new AudioContext();
//        this.canvas = document.querySelector("canvas");
//        this.ctx = this.canvas.getContext("2d");
//        this.data = [];
//        message
//            .then(arrayBuffer => {
//                return this.audioContext.decodeAudioData(arrayBuffer);
//            })
//            .then(audioBuffer => {
//                this.draw(this.normalizedData(audioBuffer));
//                this.drawData(this.data);
//            });
//    }
//    normalizedData(audioBuffer) {
//        const rawData = audioBuffer.getChannelData(0); // We only need to work with one channel of data
//        const samples = this._samples; // Number of samples we want to have in our final data set
//        const blockSize = Math.floor(rawData.length / samples); // Number of samples in each subdivision
//        const filteredData = [];
//        for (let i = 0; i < samples; i++) {
//            filteredData.push(rawData[i * blockSize]);
//        }
//        return filteredData;
//    }
//    draw(normalizedData) {
//        // set up the canvas
//        const canvas = this.canvas;
//        const dpr = window.devicePixelRatio || 1;
//        const padding = 10;
//        canvas.width = canvas.offsetWidth * dpr;
//        canvas.height = (canvas.offsetHeight + padding * 2) * dpr;
//        this.ctx.scale(dpr, dpr);
//        this.ctx.translate(0, canvas.offsetHeight / 2 + padding); // set Y = 0 to be in the middle of the canvas
//        // draw the line segments
//        const width = canvas.offsetWidth / normalizedData.length;
//        for (let i = 0; i < normalizedData.length; i++) {
//            const x = width * i;
//            let height = normalizedData[i] * canvas.offsetHeight - padding;
//            if (height < 0) {
//                height = 0;
//            }
//            else if (height > canvas.offsetHeight / 2) {
//                height = height > canvas.offsetHeight / 2;
//            }
//            // this.drawLineSegment(this.ctx, x, height, width, (i + 1) % 2);
//            this.data.push({
//                x: x,
//                h: height,
//                w: width,
//                isEven: (i + 1) % 2
//            });
//        }
//        return this.data;
//    }
//    drawLineSegment(ctx, x, height, width, isEven, colors = this._strokeStyle) {
//        ctx.lineWidth = 1; // how thick the line is
//        ctx.strokeStyle = colors; // what color our line is
//        ctx.beginPath();
//        height = isEven ? height : -height;
//        ctx.moveTo(x, 0);
//        ctx.lineTo(x + width, height);
//        ctx.stroke();
//    }
//    drawData(data, colors = this._strokeStyle) {
//        data.map(item => {
//            this.drawLineSegment(this.ctx, item.x, item.h, item.w, item.isEven, colors);
//        });
//    }
//    drawTimeline(percent) {
//        let end = Math.ceil(this._samples * percent);
//        let start = end - 5 || 0;
//        let t = this.data.slice(0, end);
//        this.drawData(t, "#1d1e22");
//    }
//}

//var canvasVisualizer;
//class renderBars {
//    constructor(audioBytes) {
//        this.canvas = canvasVisualizer;
//        this.ctx = this.canvas.getContext("2d");
//        this.audioContext = new AudioContext();
//        this.analyzer = this.audioContext.createAnalyser();
//        this.source = this.audioContext.createMediaElementSource(audioPlayer)
//        this.source.connect(this.analyzer);
//        this.analyzer.connect(this.audioContext.destination);
//        console.log(this.analyzer);
//        this.analyzer.fftSize = 512;
//        this.bufferLength = this.analyzer.frequencyBinCount;
//        this.dataArray = new Uint8Array(this.bufferLength);
//        createBars();
//    }
//    getSamples() {
//        this.analyzer.getByteTimeDomainData(this.dataArray);
//        let normalizeSamples = [...this.dataArray].map(e => 128 - 1);
//        return normalizeSamples;
//    }
//    getVolume() {
//        this.analyzer.getByteTimeDomainData(this.dataArray);
//        let normalizeSamples = [...this.dataArray].map(e => 128 - 1);
//        let sum = 0;
//        for (var i = 0; i < normalizeSamples.length; i++) {
//            sum += normalizeSamples[i] * normalizeSamples[i];
//        }
//        let volume = Math.sqrt(sum / normalizedSamples.length);
//        return volume;
//    }
//    drawTimeline(percent) {
//        bars.forEach((bar, i) => {
//            bar.update(this.getSamples()[i])
//            bar.draw(this.ctx);
//        })
//    }
//}
//class Bar {
//    constructor(x, y, width, height, color) {
//        this.x = x;
//        this.y = y;
//        this.width = width;
//        this.height = height;
//        this.color = color;
//    }
//    draw(context) {
//        context.fillStyle = this.color;
//        context.fillRect(this.x, this.y, this.width, this.height);
//    }
//    update() {

//    }
//}

//function animate() {
//    ctx.clearRect(0, 0, visualizer.width, visualizer.height);

//    const file = await fetch(audioPlayer.src);
//    const bytes = file.arrayBuffer();

//    bars.forEach(function (bar) {
//        bar.draw(ctx);
//    });
//    requestAnimationFrame(animate);
//}

//function createBars() {
//    let barWidth = canvasVisualizer.width / 265;
//    for (var i = 0; i < 256; i++) {
//        let color = 'hsl(' + i * 2 + ', 100%, 50%)';
//        bars.push(new Bar(i * barWidth, canvasVisualizer.height / 2, 1, 20, color));
//    }
//}

//const source = audioContext.createMediaElementSource(audioElement);
//const analyser = audioContext.createAnalyser();
//source.connect(analyser);
//analyser.connect(audioContext.destination);
//analyser.fftSize = 2048;

//const bufferLength = analyser.frequencyBinCount;
//const dataArray = new Uint8Array(bufferLength);

function loadVisualizer(visualizer) {
    const canvas = visualizer;
    const ctx = canvas.getContext('2d');
    const styles = getComputedStyle(visualizer);
    const bgColor = styles.getPropertyValue('--kendo-color-primary');

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
        ctx.fillStyle = 'rgba(153, 50, 204, 0.5)';
        ctx.fillRect(0, 0, canvas.width, canvas.height);

        //// Draw waveform
        //ctx.lineWidth = 2;
        //ctx.strokeStyle = bgColor;
        //ctx.beginPath();

        //const sliceWidth = canvas.width / bufferLength;
        //let x = 0;

        //for (let i = 0; i < bufferLength; i++) {
        //    const v = dataArray[i] / 128.0;
        //    const y = v * (canvas.height / 2);

        //    if (i === 0) {
        //        ctx.moveTo(x, y);
        //    } else {
        //        ctx.lineTo(x, y);
        //    }

        //    x += sliceWidth;
        //}

        //ctx.lineTo(canvas.width, canvas.height / 2);
        //ctx.stroke();
        // Draw waveform as boxes
        ctx.strokeStyle = bgColor;
        ctx.fillStyle = 'rgba(153, 50, 204, 0.5)';

        const sliceWidth = canvas.width / bufferLength;
        let x = 0;
        for (let i = 0; i < bufferLength; i++) {
            const v = dataArray[i]/ 16.0;
            const y = v * (canvas.height / 2);

            ctx.lineWidth = 4;

            ctx.strokeRect(v, v, canvas.width - v * 2 , canvas.height - v * 2);
            //ctx.fillRect(x, y, canvas.width, canvas.height - v);

            x += sliceWidth;
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
        ctx.fillStyle = 'rgba(0, 0, 0, 0.5)';
        ctx.clearRect(0, 0, canvas.width, canvas.height);
        console.log("ended");
    });
}; 