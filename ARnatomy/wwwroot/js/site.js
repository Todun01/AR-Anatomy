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
        document.getElementById("skeletal-full").href = "https://ar-natomy.b-cdn.net/USDZ/skeletal-full.usdz";
    } else {
        document.getElementById("skeletal-full").href = "intent://arvr.google.com/scene-viewer/1.0?file=https://ar-natomy.b-cdn.net/GLB/skeletal-full.glb&mode=ar_preferred#Intent;scheme=https;package=com.google.ar.core;action=android.intent.action.VIEW;S.browser_fallback_url=https://ar-natomy.tau.edu.ng;end;";
    }
});