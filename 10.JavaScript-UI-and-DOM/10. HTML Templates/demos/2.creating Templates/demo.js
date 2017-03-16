var details,
    postTemplateHTML,
    postTemplate;

details = {
    academy:"Telerik Academy",
    name:"Vlado",
    years:32,
    course:["C#","JavaScript"]
}

postTemplateHTML = document.getElementById('post').innerHTML;
postTemplate = Handlebars.compile(postTemplateHTML);
document.getElementById('body').innerHTML = postTemplate(details);


