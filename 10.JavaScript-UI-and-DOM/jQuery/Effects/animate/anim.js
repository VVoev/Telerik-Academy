$(document).ready(function(){
    $("button").click(function(){
       for(var i = 0; i<4;i++){
           $('img').animate({right: '250px'});
           $('img').animate({bottom: '250px'});
           $('img').animate({left: '250px'});
           $('img').animate({top: '250px'});
           $('img').animate({height: '500px'}, "slow");
           $('img').animate({width: '500px'}, "slow",function () {
               $('#cat').show();
               $('#cat').css('font-size','40px')
               $('button').hide();
           });

       }
    });
});