export function getPageReferrer() {
    return document.referrer;
}

export function getLocationHref() {
    return window.location.href;
}

export function getPrevUrl() {
    return window.history.state.prevUrl;
}