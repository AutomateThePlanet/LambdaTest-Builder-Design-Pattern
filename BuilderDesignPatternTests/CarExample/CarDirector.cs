namespace BuilderDesignPatternTests.CarExample;
public class CarDirector
{
    private ICarBuilder _builder;

    public CarDirector(ICarBuilder builder)
    {
        _builder = builder;
    }

    public Car ConstructSportsCar()
    {
        _builder.Make("Ferrari");
        _builder.SetModel("488 Spider");
        _builder.SetNumberOfDoors(2);
        _builder.SetEngineType("V8");
        return _builder.GetCar();
    }

    public Car ConstructSUV()
    {
        _builder.Make("Land Rover");
        _builder.SetModel("Defender");
        _builder.SetNumberOfDoors(4);
        _builder.SetEngineType("V8");
        return _builder.GetCar();
    }
}


/**
var builder = new CarBuilder();
var director = new CarDirector(builder);

Build a sports car

Car sportsCar = director.ConstructSportsCar();
Console.WriteLine(sportsCar);

Build an SUV
Car suv = director.ConstructSUV();
Console.WriteLine(suv);
 **/
