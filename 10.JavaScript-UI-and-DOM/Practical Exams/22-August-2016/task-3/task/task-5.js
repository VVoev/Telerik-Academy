function solve() {
    return function () {
        var template =
            `
            <ul class="nav">           
                <li class="nav-item logo">
                    <a href={{logo.url}}>
                        <img src={{logo.image}}>
                    </a>
                </li>                
                {{#items}}                   
                    <li class="nav-item">
                        <a href="http://academy.telerik.com/">{{title}}</a>
                        {{#if items}}
                         <ul class="subnav">
                         {{#items}}
                         <li class="nav-item">
                            <a href="{{url}}">{{title}}</a>
                         </li>
                        {{/items}}
                        </ul>
                        {{/if}}
                    </li>
                {{/items}}    
            </ul>
            `;
        return template;
    };
}
