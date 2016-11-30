using System;

abstract class Component
{
    public Entity Container { get; set; }
    public virtual void Update() { }
}

class NameComponent : Component
{
    public string EntityName { get; set; }
}

class SpatialComponent : Component
{
    public int X { get; set; }
    public int Y { get; set; }
    public int Speed { get; set; }
}

class KeyboardMoverComponent : Component
{
    public override void Update()
    {
        Console.WriteLine();
        Console.WriteLine("#######################");
        Console.WriteLine("#######################");
        Console.WriteLine();
        Console.WriteLine("Which way to move?: WASD");
        Console.WriteLine();
        Console.WriteLine("_____________________");
        Console.WriteLine("   Player Location   ");
        Console.WriteLine("_____________________");
        Console.WriteLine();

        char direction = Console.ReadKey().KeyChar;
        SpatialComponent spatial = Container.GetComponent<SpatialComponent>();
        switch (direction)
        {
            case 'w':
                spatial.Y += spatial.Speed;
                break;
            case 'a':
                spatial.X -= spatial.Speed;
                break;
            case 's':
                spatial.Y -= spatial.Speed;
                break;
            case 'd':
                spatial.X += spatial.Speed;
                break;
        }
    }
}

class RenderComponent : Component
{
    public override void Update()
    {
        NameComponent name = Container.GetComponent<NameComponent>();
        SpatialComponent spatial = Container.GetComponent<SpatialComponent>();
        Console.WriteLine(name.EntityName + " is at: (" + spatial.X + ", " + spatial.Y + ")");

    }
}

class KeepInBoundsComponent : Component
{
    public int MaxBound { get; set; }
    public override void Update()
    {
        SpatialComponent spatial = Container.GetComponent<SpatialComponent>();
        if (spatial.X > MaxBound)
            spatial.X = MaxBound;
        if (spatial.X < -1 * MaxBound)
            spatial.X = -1 * MaxBound;
        if (spatial.Y > MaxBound)
            spatial.Y = MaxBound;
        if (spatial.Y < -1 * MaxBound)
            spatial.Y = -1 * MaxBound;
    }
}

class SpeedBoostComponent : Component
{
    public Entity playerSpace;
    public int turn;

    public override void Update()
    {
        SpatialComponent spatial = Container.GetComponent<SpatialComponent>();
        SpatialComponent spatialPlayer = playerSpace.GetComponent<SpatialComponent>();

        if (spatial.X == spatialPlayer.X && spatial.Y == spatialPlayer.Y)
        {
            Console.WriteLine("Speed Boost Get!");
            turn = 6;
            spatialPlayer.Speed = 2;
        }

        if (turn > 0)
        {
            turn--;
            Console.WriteLine(turn + " turns left of boost");
        }

        if (turn == 0)
            spatialPlayer.Speed = 1;
    }
}

class TeleportComponent : Component
{
    public Entity playerSpace;

    public override void Update()
    {
        SpatialComponent spatialPowerUp = Container.GetComponent<SpatialComponent>();
        SpatialComponent spatialPlayer = playerSpace.GetComponent<SpatialComponent>();
        Random x = new Random();
        Random y = new Random();

        if (spatialPowerUp.X == spatialPlayer.X && spatialPowerUp.Y == spatialPlayer.Y)
        {
            Console.WriteLine("Player Teleported!");
            spatialPlayer.X = y.Next(-10, 10);
            spatialPlayer.Y = y.Next(-10, 10);
        }
    }
}

class AIComponent : Component
{
    public Entity playerSpace;
    public override void Update()
    {

        SpatialComponent spatial = Container.GetComponent<SpatialComponent>();
        SpatialComponent spatialPlayer = playerSpace.GetComponent<SpatialComponent>();
        if (spatial.X > spatialPlayer.X)
            spatial.X -= 1;
        else if (spatial.X < spatialPlayer.X)
            spatial.X += 1;
        else if (spatial.Y > spatialPlayer.Y)
            spatial.Y -= 1;
        else if (spatial.Y < spatialPlayer.Y)
            spatial.Y += 1;
    }
}

//class KillOnContactComponent : Component
//{
//    public Entity playerSpace;
//    public override void Update()
//    {
//        SpatialComponent spatial = Container.GetComponent<SpatialComponent>();
//        SpatialComponent spatialPlayer = playerSpace.GetComponent<SpatialComponent>();
//        if (spatial.X == spatialPlayer.X && spatial.Y == spatialPlayer.Y)
//            Console.WriteLine("GAME OVER");

//    }
//}

