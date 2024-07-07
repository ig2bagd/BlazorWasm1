function addState(uri) {
    let href = window.location.href;
    console.log(`href: ${href}, uri: ${uri}`);
    window.history.pushState({ prevUrl: href }, null, uri);
}

function setState(baseUri) {
    let href = window.location.href;
    console.log(`href: ${href}, baseUri: ${baseUri}`);
    window.history.replaceState(null, null, baseUri);
}

function saveMessage(msg) {
    alert(`This is my message: ${msg}`);
}