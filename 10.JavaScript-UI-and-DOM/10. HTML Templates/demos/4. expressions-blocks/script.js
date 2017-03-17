/* globals document, Handlebars */

var post,
    postTemplateHtml,
    postTemplate,
    categories,
    categoriesTemplateHtml,
    categoriesTemplate;
post = {
    id: 3,
    title: 'Creating templates with Handlebars.js',
    content: 'Creating templates with Handlebars.js is pretty easy and intuitive. Handlebars.js supports <strong>one-way data-binding</strong> and defines dynamic HTML.',
    category: {
        id: 4,
        name: 'Web'
    },
    tags: [{
        name: 'web',
    }, {
        name: 'javascript'
    }, {
        name: 'js'
    }, {
        name: 'handlebars'
    }, {
        name: 'html-templates'
    }]
};
categories = [{
    id: 1,
    name: 'Mobile'
}, {
    id: 2,
    name: 'Desktop'
}, {
    id: 3,
    name: 'Embedded'
}, {
    id: 4,
    name: 'Web'
}];

categoriesTemplateHtml = document.getElementById('categories-list-template').innerHTML;
categoriesTemplate = Handlebars.compile(categoriesTemplateHtml);
document.getElementById('root').innerHTML = categoriesTemplate({
    categories: categories
});


postTemplateHtml = document.getElementById('post-template').innerHTML;
postTemplate = Handlebars.compile(postTemplateHtml);
document.getElementById('root').innerHTML += postTemplate(post);
