var controls = (function () {
    function formatResult(name, value,action) {
        return name + ' says the result is ' + value+' and its been performing function '+action;
    }

    class Calculator {
        constructor(name,action) {
            this.name = name;
            this.result = 0;
            this.action = action;

        };

        add(x) {
            x=Number(x);
            this.result += x;
            this.action="add";
            return this;
        };

        subtract(x) {
            x=Number(x);
            this.result -= x;
            this.action="minus";
            return this;
        };

        deduct(x) {
            x=Number(x);
            this.result /=x;
            this.action="deduct";
            return this;
        };

        multiply(x) {
            x=Number(x);
            this.result *=x;
            this.action="multiply";
            return this;
        };

        showResult() {
            console.log(formatResult(this.name, this.result,this.action));
            return this;
        };
    };

    return { getCalculator: (name) => new Calculator(name) };
} ());
let calc = controls.getCalculator('First');
calc.add(13);
calc.showResult();
calc.subtract(3);
calc.showResult();
calc.multiply(5);
calc.showResult();
calc.deduct(2);
calc.showResult();

