function solve() {
    return function (selector) {
        var template = `
         <div id="calendar">
            <div class="events-calendar">
                <h2 class="header">
                    Appointments for <span class="{{month}}">{{month}}</span> <span class="{{year}}">{{year}}</span>
                </h2>
                
                
                {{#days}}
                 <div class="col-date">
                     <div class="date">{{day}}</div>
                        <div class="events">
                        {{#events}}
                        
                        {{#if title}}
                            <div class="event {{importance}}" title="no comment">
                                <div class="title">{{title}}</div>
                                <span class="time">at: {{time}}</span>
                            </div>
                            
                            {{else}}
                            <div class="event {{importance}}">
                                <div class="title">Free slot</div>
                            </div>
                            
                            {{/if}}
                            
                        {{/events}}
                        </div>
                </div>
                {{/days}}   
         </div>
    </div>
          
            `
        document.getElementById(selector).innerHTML = template;
    };
}
/**
 * Created by Vladimir on 3/26/2017.
 */
