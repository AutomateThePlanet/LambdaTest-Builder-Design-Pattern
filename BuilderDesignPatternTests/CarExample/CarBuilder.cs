namespace BuilderDesignPatternTests.CarExample;
public class CarBuilder : ICarBuilder
{
    private Car _car = new Car();

    public void Make(string name)
    {
        _car.Name = name;
    }

    public void SetModel(string model)
    {
        _car.Model = model;
    }

    public void SetNumberOfDoors(int numberOfDoors)
    {
        _car.NumberOfDoors = numberOfDoors;
    }

    public void SetEngineType(string engineType)
    {
        _car.EngineType = engineType;
    }

    public Car GetCar()
    {
        return _car;
    }
}

