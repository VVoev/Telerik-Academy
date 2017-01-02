function findThirdDigit(number) {
    if (number < 699) {
        console.log('false 0');
    } else {
        number /= 100;
        if ((number | 0) % 10 === 7) {
            console.log('true');
        } else if ((number | 0) % 10 !== 7){
            console.log('false ' + Number((number % 10)));
        }
    }
}/**
 * Created by Vladimir on 1/2/2017.
 */
