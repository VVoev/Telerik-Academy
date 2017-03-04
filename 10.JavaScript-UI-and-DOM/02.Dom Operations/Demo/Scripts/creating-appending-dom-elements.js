(function () {
    var generateBoxesBtn;

    function onClickGenerateBoxesButton() {
        var contentDiv = document.getElementById("content");

        while(contentDiv.firstChild){
            contentDiv.removeChild(contentDiv.firstChild);
        }

        var count = (document.getElementById("tb-box-count").value || 5);

        var div;
        for(let i = 0 ;i<count; i+=1){
            div = document.createElement("div");
            div.className = "colored";
            contentDiv.appendChild(div);
        }
    }

    generateBoxesBtn = document.getElementById("btn-generate-boxes");
    generateBoxesBtn.addEventListener("click",onClickGenerateBoxesButton);
})();