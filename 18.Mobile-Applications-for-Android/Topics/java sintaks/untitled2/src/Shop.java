import interfaces.CofeeFactory;

public class Shop implements  CofeeFactory{

    @Override
    public Cofee makeCofee() {
        return new Cofee();
    }
}
