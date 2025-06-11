// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function isIos() {
    const ua = window.navigator.userAgent;
    const iOS = /iPad|iPhone|iPod/.test(ua);
    const iPadOS = navigator.platform === 'MacIntel' && navigator.maxTouchPoints > 1;

    return iOS || iPadOS;
}
document.addEventListener("DOMContentLoaded", function () {
    if (isIos()) {
        // full skeletal model
        document.getElementById("view-in-ar-full").rel = "ar";
        document.getElementById("view-in-ar-full").href = ""
    } else {
        document.getElementById("view-in-ar-full").href = "/AFRAME-Scenes/skeletal-full.html";
    }
});