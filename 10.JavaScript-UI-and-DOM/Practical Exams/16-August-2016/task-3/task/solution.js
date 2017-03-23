function solve() {
    return function () {
        var data = {
            title: 'JS UI & DOM 2016',
            posts: [{
                author: 'Cuki',
                text: 'Hello guys',
                comments: [{
                    author: 'Kon',
                    text: 'Hello'
                }, {
                    text: 'Hello'
                }]
            }, {
                author: 'Cuki',
                text: 'This works',
                comments: [{
                    author: 'Cuki',
                    text: 'Well, ofcourse!\nRegards'
                }, {
                    text: 'You are fat',
                    deleted: true
                }]
            }, {
                author: 'Pesho',
                text: 'Is anybody out <a href="https://facebook.com/">there</a>?',
                comments: []
            }]
        };
        var template = [
            '<h1>{{title}}</h1>',
            '<ul>',
                '{{#each posts}}',
                    '<li>',
                         '<div class="post">',
                             '<p class="author">',
                                 '{{#if author}}',
                                    '<a class="user" href="{{user}}">{{author}}</a>',
                                 '{{else}}',
                                    '<a class="anonymous"">Anonymous</a>',
                                  '{{/if}}',
                             '</p>',
                             '<pre class="content">{{{text}}}</pre>',
                         '</div>',
                         '<ul>',
                            '<li>',
                            '{{#each comments}}',
                                '<div class="comment">',
                                        '<p class="author">',
                                            '{{#if author}}',
                                             '<a class="user" href="/user/{{author}}">{{author}}</a>',
                                            '{{else}}',
                                             '<a class="user">Anonymous</a>',
                                            '{{/if}}',
                                        '</p>',
                                        '<pre class="content">{{text}}</pre>',
                                 '</div>',
                            '{{/each}}',
                            '</li>',             
                        '</ul>',
                     '</li>',
                 '{{/each}}',
            '</ul>',

        ].join('\n');

        return template;
    }
}

// submit the above

if (typeof module !== 'undefined') {
    module.exports = solve;
}
