function solve() {
    return function () {
        var template = `
          <ul class="nav">
            <li class="nav-item logo">
                <a href="{{logo.image}}">
                  <img src="{{logo.image}}">
                </a>
            </li>
            
            {{#items}}
                 <li class="nav-item">
                 <a href="{{url}}">{{title}}</a>
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
              <!--<li class="nav-item">-->
                <!--<a href="#/courses">Courses</a>-->
                <!--<ul class="subnav">-->
                    <!--<li class="nav-item">-->
                        <!--<a href="#/html-basics">HTML Basics</a>-->
                    <!--</li>-->
                    <!--<li class="nav-item">-->
                        <!--<a href="#/css-styling">CSS Styling</a>-->
                    <!--</li>-->
                    <!--<li class="nav-item">-->
                        <!--<a href="#/jsf">JavaScript Fundamentals</a>-->
                    <!--</li>-->
                    <!--<li class="nav-item">-->
                        <!--<a href="#/js-ui-dom">JavaScript UI &amp; DOM</a>-->
                    <!--</li>-->
                    <!--<li class="nav-item">-->
                        <!--<a href="#/js-opp">JavaScript OOP</a>-->
                    <!--</li>-->
                    <!--<li class="nav-item">-->
                        <!--<a href="#/js-apps">JavaScript Application</a>-->
                    <!--</li>-->
                <!--</ul>-->
            <!--</li>-->
           
           </ul>
           
             
`;
        return template;
    };
}

//module.exports = solve;