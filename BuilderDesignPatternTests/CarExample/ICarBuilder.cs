namespace BuilderDesignPatternTests.CarExample;
public interface ICarBuilder
{
    void Make(string carName);
    void SetModel(string model);
    void SetNumberOfDoors(int numberOfDoors);
    void SetEngineType(string engineType);
    Car GetCar();
}

