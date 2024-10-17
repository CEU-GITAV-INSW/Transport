public class ElectricEngine
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
public class CombustionEngine
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

    private String Name { get; set; }

    CombustionEngine Engine { get; set; }

    public Transport(String name)
    {
        Name = name;
        Engine = new CombustionEngine();
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
        Console.WriteLine($"Total of {DistanceMoved} km driven");
        Console.WriteLine();

    }
    

}

public class Program
{
    public static void Main(string[] args)
    {

        Transport t = new Transport("Tractor Amarillo");
        t.Deliver();
    }
}