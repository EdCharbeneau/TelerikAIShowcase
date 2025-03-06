window.highlightAll = () => {
    return Prism.highlightAll();
}
window.highlightAllUnder = (element) => {
    console.log("highlight called");
    return Prism.highlightAllUnder(element);
}