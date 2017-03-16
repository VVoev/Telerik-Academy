var post;
var postTemplateHTML;
var postTemplate;

post = {
    title:"Creating Templates with HandleBars",
    content:"It is easy handlebar support <h1> Tags </h1> and also <strong> Strong Tag</strong>"
}

postTemplateHTML = document.getElementById('post-template').innerHTML;
postTemplate = Handlebars.compile(postTemplateHTML);
document.getElementById('root').innerHTML = postTemplate(post);

