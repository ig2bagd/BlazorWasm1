export function afterStarted(blazor) {
    var customScript = document.createElement('script');
    customScript.setAttribute('src', './scripts/jsInterop.js');
    document.head.appendChild(customScript);
}