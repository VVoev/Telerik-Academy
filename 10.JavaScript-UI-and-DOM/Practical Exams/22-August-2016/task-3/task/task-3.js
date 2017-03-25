function solve() {
    return function () {
        var template =
            `
            <ul class="nav">
            <li class="nav-item logo">
                <a href="{{{logo.url}}}">
                    <img src="{{{logo.image}}}">
                </a>
            </li>
            
            {{#each items}}
            <li class="nav-item">
                <a href="{{url}}">{{title}}</a>
            {{#if this.items}}
            <ul class="subnav">
            
            {{#this.items}}
            <li class="nav-item">
                        <a href={{url}}>{{title}}</a>
                    </li>
            {{/this.items}}
            </ul>
            {{else}}
            </li>
                
                
            {{/if}}
            {{/each}}
            </ul>
            `;
        return template;
    };
}

//module.exports = solve;