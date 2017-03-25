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
          <div id="forum-container">
            <h1>{{title}}</h1>
                <ul>
                    {{#posts}}
                   <li>
                        <div class="post">
                            <p class="author">
                                <a class="user" href="/user/Cuki">{{author}}</a>
                            </p>
                            <pre class="content">{{{text}}}</pre>
                        </div>                  
                   </li>
                   {{#comments}}
                   {{#if deleted}}
                   
                    {{else}}
                    <ul>
                        <li>
                            <div class="comment">
                                <p class="author">
                                    {{#if author}}
                                    <a class="user" href="/user/Kon">{{author}}</a>
                                    {{else}}
                                     <a class="anonymous">Anonymous</a>
                                     {{/if}}
                                </p>
                                <pre class="content">{{text}}</pre>
                            </div>
                        </li>
                    </ul>                 
                   {{/if}}
                   {{/comments}}
                    {{/posts}}
                </ul>
           </div>

        `
        return template;
    }
}

// submit the above

if (typeof module !== 'undefined') {
    module.exports = solve;
}
