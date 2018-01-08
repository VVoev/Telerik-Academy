import java.util.Random;

class Calculator {
    private double mResult;

    public Calculator() {
        mResult = 0;
    }

    public void add(double value) {
        mResult += value;
    }

    public void deduct(double value) {
        mResult -= value;
    }

    public void multiply(double value) {
        mResult *= value;
    }

    public void divide(double value) {
        mResult /= value;
    }

    private void magic(){
        mResult = (mResult*3)/2.41;
    }

    public double giveMeStrangeBehavior(){
        magic();
        return  mResult;
    }

    public double getResult() {
        return mResult;
    }
}
