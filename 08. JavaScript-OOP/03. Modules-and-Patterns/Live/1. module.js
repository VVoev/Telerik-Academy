var controls = (function () {
    function formatResult(name, value) {
        return name + ' says the result is ' + value;
    }

    class Calculator {
        constructor(name) {
            this.name = name;
            this.result = 0;
        };

        add(x) {
            x=Number(x);
            this.result += x;
            return this;
        };

        subtract(x) {
            x=Number(x);
            this.result -= x;
            return this;
        };

        deduct(x) {
            x=Number(x);
            this.result /=x;
            return this;
        };

        multiply(x) {
            x=Number(x);
            this.result *=x;
            return this;
        };

        showResult() {
            console.log(formatResult(this.name, this.result));
            return this;
        };
    };

    return { getCalculator: (name) => new Calculator(name) };
} ());
let calc = controls.getCalculator('First');
calc.add(13);
calc.subtract(3);
calc.multiply(5);
calc.deduct(2);
calc.showResult();