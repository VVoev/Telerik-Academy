var holder,
    list,
    i,
    count = 15;

holder = $('#holder');
holder.append('<h1>Header:</h1>');
list = $('<ul>');
holder.append(list);
for(let i = 1 ; i<=count;i+=1){
    list.append('<li>'+i+'</li>');
}
