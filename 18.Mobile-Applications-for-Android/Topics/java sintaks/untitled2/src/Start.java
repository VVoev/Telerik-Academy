public class Start
{
    public static void main(String [] args)
    {
        Calculator calculator = new Calculator();
        calculator.add(23);
        calculator.deduct(5);
        calculator.multiply(3);
        calculator.divide(2);
        double res = calculator.getResult();
        System.out.println(res);
        double strange = calculator.giveMeStrangeBehavior();
        System.out.println(strange);

        ScientificCalculator sf = new ScientificCalculator();
        System.out.println(sf.CalculateSinus(3.50));
        System.out.println(constants.FAIL);
    }

}