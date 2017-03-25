function solve() {
    return function (selector) {
        var template = `
            <h2 class="header">
                Appointments for <span class="{{month}}">August</span> <span class="{{year}}">{{year}}</span>
            </h2>
            
            {{#days}}
            <div class="col-date">
                <div class="date">{{day}}</div>
                    <div class="events">
                    {{#events}}
                        {{#if title}}
                            <div class="event {{importance}}" title="{{title}}">
                                <div class="title">{{title}}</div>
                                <span class="{{time}}">at: {{time}}</span>
                            </div>                        
                        {{else}}
                        <div class="event none">
                            <div class="title">Free slot</div>
                        </div>
                        {{/if}}                               
                    {{/events}}
                    </div>   
            </div>    
            {{/days}}           
            `
        document.getElementById(selector).innerHTML = template;
    };
}

// module.exports = solve;