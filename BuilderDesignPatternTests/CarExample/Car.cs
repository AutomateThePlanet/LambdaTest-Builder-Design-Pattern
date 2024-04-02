using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderDesignPatternTests.CarExample;
public class Car
{
    public string Name { get; set; }
    public string Model { get; set; }
    public int NumberOfDoors { get; set; }
    public string EngineType { get; set; }

    public override string ToString()
    {
        return $"Make: {Name}, Model: {Model}, Doors: {NumberOfDoors}, Engine Type: {EngineType}";
    }
}
