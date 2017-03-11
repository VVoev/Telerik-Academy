function clickOnButton() {
    var myWindow = window,
        browser = myWindow.navigator.appCodeName,
        //All Modern browsers return Mozilla for compatibility reasons
        ism = (browser == "Mozilla");
    
    if (ism) {
        alert("Yes");
    } else {
        alert("No");
    }
}

