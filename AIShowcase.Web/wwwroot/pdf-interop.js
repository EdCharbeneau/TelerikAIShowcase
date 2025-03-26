// This method is a quick hack to overcome the lack of a proper API to interact with the PDF viewer.
// The PDF viewer does not notify the host application when the PDF is fully loaded, so we have to poll the viewer to check if the PDF is ready.
observeElement = (selector, callback) => {
    const targetNode = document.querySelector(selector);
    console.log(targetNode);
    if (!targetNode) return;

    const observer = new MutationObserver((mutationsList, observer) => {
        for (let mutation of mutationsList) {
            if (mutation.type === 'attributes' && mutation.attributeName === 'style') {
                if (targetNode.style.display === 'none') {
                    callback();
                    observer.disconnect();
                    break;
                }
            }
        }
    });

    observer.observe(targetNode, { attributes: true });
};

// This method is a quick hack to overcome the lack of a proper API to interact with the PDF viewer.
// The PDF viewer does not have deep linking for search results. This method operates the UI as if the user is searching for a term.
window.invokePDFSearch = async (searchValue, page) => {
    console.log("invokePDFSearch");
    observeElement('.k-loader-container', () => {
        console.log("Loading Finished");
        setTimeout(function () {

        // find the search input
        // click the search button in the toolbar
        var searchButton = document.querySelector("[title='Search']");
        searchButton.click();
        console.log("seach clicked");

        setTimeout(function () {
            // find the search input
            var searchInput = document.querySelector(".k-search-panel input");

            searchInput.focus();
            // set the search value
            searchInput.value = searchValue;
            // trigger the "change" event to display the found text
            searchInput.dispatchEvent(new Event('change'));

            setTimeout(function () {

            var next = document.querySelector("[title='Next match']");
            var previous = document.querySelector("[title='Previous match']");

            previous.click();
            next.click();

        }, 500);
        }, 500);
        }, 500);
    });

};

