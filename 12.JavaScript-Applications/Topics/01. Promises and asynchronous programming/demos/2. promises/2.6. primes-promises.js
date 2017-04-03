(function () {

    var isPrime = function (number) {
        for (var i = 2; i < number; i++) {
            if (number % i == 0) {
                return false;
            }
        }
        return true;
    };

    var calculatePrimes = function (rangeStart, rangeEnd) {
        var currentNum;
        var primes = [];

        for (currentNum = rangeStart; currentNum < rangeEnd; currentNum += 1) {
            if (isPrime(currentNum)) {
                primes.push(currentNum)
            }
        }

        return primes;
    }

    var writeArray = function (array) {
        var targetElement = document.getElementById("array-display-element");
        targetElement.innerText +=array.join(",  ");
    }

    var getDisplayPrimePromise = function (rangeStart, rangeEnd) {
        return new Promise(function (resolve,reject) {
            setTimeout(function (rangeStart,rangeEnd) {
                var primes = calculatePrimes(rangeStart,rangeEnd);
                resolve(primes);
            },0,rangeStart,rangeEnd)
        })
    }

    var calculatePrimesButton = document.getElementById("calculate-primes-button");
    calculatePrimesButton.onclick = function () {
        getDisplayPrimePromise(2, 100000).then(writeArray);
    }


}());
