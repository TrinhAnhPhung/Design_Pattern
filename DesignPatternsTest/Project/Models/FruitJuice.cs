using System;
namespace NOPKIEMTRA.Project.Models
{  
// FruitJuice.cs - Abstract class với Template Method Pattern
public abstract class FruitJuice
{
    // Template Method
    public void Print()
    {
        Console.WriteLine($"===== {GetName()} Juice =====");
        Console.WriteLine($"Weight: {Weight()}g");
        Console.WriteLine($"Size: {Sized()}cm");
        Console.WriteLine($"Color: {Color()}");
        Console.WriteLine();
    }

    public void Harvest()
    {
        Console.WriteLine($"Harvesting {GetName()}...");
    }

    public void Pawn()
    {
        Console.WriteLine($"Processing {GetName()} for juice...");
    }

    // Primitive methods (abstract)
    protected abstract int Weight();
    protected abstract int Sized();
    protected abstract string Color();
    protected abstract string GetName();
}

// Banana.cs
public class Banana : FruitJuice
{
    protected override int Weight() => 120;
    protected override int Sized() => 20;
    protected override string Color() => "Yellow";
    protected override string GetName() => "Banana";
}

// Strawberry.cs
public class Strawberry : FruitJuice
{
    protected override int Weight() => 15;
    protected override int Sized() => 3;
    protected override string Color() => "Red";
    protected override string GetName() => "Strawberry";
}

// Mango.cs
public class Mango : FruitJuice
{
    protected override int Weight() => 300;
    protected override int Sized() => 15;
    protected override string Color() => "Orange";
    protected override string GetName() => "Mango";
}

// Program.cs - Class với hàm output
public class Program
{
    public static void Output()
    {
        FruitJuice banana = new Banana();
        FruitJuice strawberry = new Strawberry();
        FruitJuice mango = new Mango();

        banana.Harvest();
        banana.Pawn();
        banana.Print();

        strawberry.Harvest();
        strawberry.Pawn();
        strawberry.Print();

        mango.Harvest();
        mango.Pawn();
        mango.Print();
    }

    static void Main()
    {
        Output();
    }
}
}