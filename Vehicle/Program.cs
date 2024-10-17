
public interface IEngine
{

    public bool moveVehicle(int distance);
    public void refuel();
}
public class ElectricEngine: IEngine
{
    int autonomy = 0;
    public bool moveVehicle(int distance)
    {
        if (autonomy >= distance)
        {
            Console.Write($"Moving an electric vehicle {distance} kms");
            Console.WriteLine();
            autonomy = autonomy - distance;
            return true;
        }
        else
        {
            Console.Write($"Can not move an electric vehicle {distance} kms. No battery left");
            Console.WriteLine();
            return false;

        }

    }
    public void refuel()
    {
        Console.Write("Recharging electricity");
        Console.WriteLine();
        autonomy += 300;
        if (autonomy >= 800){
            autonomy = 800;
        }
        Console.Write($"Autonomy is {autonomy} km");
        Console.WriteLine();
    }
}
public class CombustionEngine : IEngine
{

    int autonomy = 0;
    public bool moveVehicle(int distance)
    {
        if (autonomy >= distance)
        {
            Console.Write($"Moving a combustion vehicle {distance} kms");
            Console.WriteLine();
            autonomy = autonomy - distance;
            return true;
        }
        else
        {
            Console.Write($"Can not move a combustion vehicle {distance} kms. No gasoline left");
            Console.WriteLine();
            return false;

        }

    }
    public void refuel()
    {
        Console.Write("Recharging gasoline");
        Console.WriteLine();
        autonomy += 500;
        if (autonomy >= 1000)
        {
            autonomy = 1000;
        }
        Console.Write($"Autonomy is {autonomy} km");
        Console.WriteLine();

    }
}

public class Transport
{
    int DistanceMoved { get; set; } = 0;

    public String Name { get; set; }

    IEngine Engine { get; set; }

    public virtual IEngine CreateEngine()
    {
        return new CombustionEngine();
    }

    public Transport(String name)
    {
        Name = name;
        Engine = CreateEngine();
    }

    public void Move(int distance)
    {
        bool CouldMove = Engine.moveVehicle(distance);
        
        while (!CouldMove) {
          
            Engine.refuel();
            CouldMove = Engine.moveVehicle(distance);
        }
        DistanceMoved += distance;
    }
    public void Deliver() { 
  
        Move(300);
        Console.WriteLine("Package delivered");
        Console.WriteLine();
        Move(500);
        Console.WriteLine("Package delivered");
        Console.WriteLine();
        Move(800);
        Console.WriteLine("Package delivered");
        Console.WriteLine();
        Console.WriteLine($"Total of {DistanceMoved} km driven by {Name}");
        Console.WriteLine();

    }
    

}

public class CombustionTransport: Transport
{
    public CombustionTransport(string name) : base(name)
    {
    }

    public override IEngine CreateEngine()
    {
        return new CombustionEngine();
    }

}

public class ElectricTransport : Transport
{
    public ElectricTransport(string name) : base(name)
    {
    }

    public override IEngine CreateEngine()
    {
        return new ElectricEngine();
    }

}

public class Program
{
    public static void Main(string[] args)
    {
        Transport t1 = new ElectricTransport("BMW i8");
        Transport t2 = new CombustionTransport("Mazda RX-8");
        t1.Deliver();
        t2.Deliver();
    }
}