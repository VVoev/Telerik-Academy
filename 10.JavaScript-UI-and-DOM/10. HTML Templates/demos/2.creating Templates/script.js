var post,
    postTemplateHTML,
    postTemplate;
post = {
    id: 3,
    tag:"Telerik Academy",
    title: 'Creating templates with Handlebars.js',
    content: 'Creating templates with Handlebars.js is pretty easy and intuitive. Handlebars.js supports one-way data-binding and defines dynamic HTML.'
};
postTemplateHTML = document.getElementById('post-template').innerHTML;
postTemplate = Handlebars.compile(postTemplateHTML);
document.getElementById('root').innerHTML = postTemplate(post);