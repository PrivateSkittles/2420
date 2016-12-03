using System;

class MainClass
{
    static void Main()
    {
        Random x = new Random();
        Random y = new Random();

        Entity player = new Entity();
        player.AddComponent(new SpatialComponent { Speed = 1 });
        player.AddComponent(new NameComponent { EntityName = "Player" });
        player.AddComponent(new KeyboardMoverComponent());
        player.AddComponent(new KeepInBoundsComponent { MaxBound = 10 });
        player.AddComponent(new RenderComponent());
        player.AddComponent(new TurnCounterComponent { turn = 20 });
        TurnCounterComponent gameWinCondition = player.GetComponent<TurnCounterComponent>();


        Entity enemy = new Entity();
        enemy.AddComponent(new SpatialComponent { X = x.Next(-10, -5), Y = y.Next(-10, 10) });
        enemy.AddComponent(new AIComponent { playerSpace = player });
        enemy.AddComponent(new NameComponent { EntityName = "Blue Enemy" });
        enemy.AddComponent(new KeepInBoundsComponent { MaxBound = 10 });
        enemy.AddComponent(new RenderComponent());
        enemy.AddComponent(new KillOnContactComponent { playerSpace = player });
        KillOnContactComponent gameLossCondition = enemy.GetComponent<KillOnContactComponent>();


        Entity enemy2 = new Entity();
        enemy2.AddComponent(new SpatialComponent { X = x.Next(5, 10), Y = y.Next(-10, 10) });
        enemy2.AddComponent(new NameComponent { EntityName = "Red Enemy" });
        enemy2.AddComponent(new AIComponent { playerSpace = player });
        enemy2.AddComponent(new KeepInBoundsComponent { MaxBound = 10 });
        enemy2.AddComponent(new RenderComponent());
        enemy2.AddComponent(new KillOnContactComponent { playerSpace = player });
        KillOnContactComponent gameLossCondition2 = enemy2.GetComponent<KillOnContactComponent>();


        Entity speedUp = new Entity();
        speedUp.AddComponent(new SpatialComponent { X = x.Next(-10, 9), Y = y.Next(-9, 10) });
        speedUp.AddComponent(new NameComponent { EntityName = "Speed Booster" });
        speedUp.AddComponent(new SpeedBoostComponent { playerSpace = player });
        speedUp.AddComponent(new RenderComponent());


        Entity teleporter = new Entity();
        teleporter.AddComponent(new SpatialComponent { X = x.Next(-9, 10), Y = y.Next(-10, 9) });
        teleporter.AddComponent(new NameComponent { EntityName = "Teleporter" });
        teleporter.AddComponent(new TeleportComponent { playerSpace = player });
        teleporter.AddComponent(new RenderComponent());


        bool GameLoop = true;
        while (GameLoop == true)
        {

            player.Update();

            Console.WriteLine("_____________________");
            Console.WriteLine("  Power Up Locations ");
            Console.WriteLine("_____________________");
            Console.WriteLine();
            speedUp.Update();
            teleporter.Update();


            Console.WriteLine();
            Console.WriteLine("_____________________");
            Console.WriteLine("   Enemy Locations   ");
            Console.WriteLine("_____________________");
            enemy.Update();
            enemy2.Update();


            if (gameLossCondition.isPlayerAlive == false || gameLossCondition2.isPlayerAlive == false)
            {
                Console.WriteLine();
                Console.WriteLine("GAME OVER. GET BETTER.");
                Console.WriteLine();
                GameLoop = false;
            }

            else if (gameWinCondition.didPlayerWin == true)
            {
                Console.WriteLine();
                Console.WriteLine("Congratulations! A winner is you!");
                Console.WriteLine();
                GameLoop = false;
            }
        }
    }
}



