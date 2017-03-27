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
        var template =
            `
            <h1>{{title}}</h1>
            <ul>
            {{#posts}}
                 <li>
                    <div class="post">
                        <p class="author">
                        <a class="user" href="/user/{{author}}">{{author}}</a>
                        </p>
                        <pre class="content">{{{text}}}</pre>
                    </div>
                </li>
                
                {{#comments}}
                <ul>
                    {{#if author}}
                    <li>
                        <div class="comment">
                            <p class="author">
                                <a class="user" href="/user/Kon">{{author}}</a>
                            </p>
                            <pre class="content">{{text}}</pre>
                        </div>
                    </li>
                    {{else}}
                        {{#if deleted}}
                        {{else}}
                        <li>
                              <div class="comment">
                              <p class="author">
                              <a class="anonymous">Anonymous</a>
                              </p>
                              <pre class="content">Hello</pre>
                              </div>
                        </li>
                        {{/if}}
                    {{/if}}
                </ul>
                {{/comments}}
            {{/posts}}    
            </ul>
           `
        return template;
    }
}
