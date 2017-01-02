function CheckNumber(x) {
    var number = Number(x);

   if(number % 5==0 && number % 7 ==0){
       console.log('true '+number)
   }else{
       console.log('false '+number)
   }
}
CheckNumber(3);