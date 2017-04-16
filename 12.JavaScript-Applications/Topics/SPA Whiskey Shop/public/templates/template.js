let templates = (function () {

    var handlebars =window.handlebars || window.Handlebars,
    Handlebars = window.handlebars || window.Handlebars;

    function get(name) {
        let promise = new Promise((resolve, reject) => {
            let url = `templates/${name}.handlebars`;
            $.get(url,function (templateHtml) {
                let template = handlebars.compile(templateHtml);
                resolve(template);
            })
        })
        return promise;
    }

    function fillItems(name,items) {

        let promise = new Promise((resolve, reject) => {
            let url = `templates/${name}.handlebars`;
            $.get(url,function (templateHtml) {
                let template = handlebars.compile(templateHtml);
                let result = template(items);
                let content = $('#content').html(result)
            })
        })
        return promise;
    }




    return {
        get,
        fillItems
    }

}());