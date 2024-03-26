namespace BuilderDesignPatternTests.CarExample;
public interface ICarBuilder
{
    void SetMake(string make);
    void SetModel(string model);
    void SetNumberOfDoors(int numberOfDoors);
    void SetEngineType(string engineType);
    Car GetCar();
}

