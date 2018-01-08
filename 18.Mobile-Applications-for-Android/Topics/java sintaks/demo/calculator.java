class Calculator {
    private double mResult;

    public Calculator() {
        mResult = 0;
    }

    public Calculator add(double value) {
        mResult += value;
        return this;
    }

    public Calculator multiply(double value) {
        mResult *= value;
        return this;
    }

    /* More operations .... */

    public double getResult() {
        return mResult;
    }
}