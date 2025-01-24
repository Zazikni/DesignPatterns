namespace DesignPatterns
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //SingletonTest();
            //AbstractFactoryTest();
            //AdapterTest();
            //DecoreatorTest();
            //CommandTest();
            ObserverTest();

        }
        public static void ObserverTest()
        {
            Dungeon dungeon = new Dungeon("Старый склеп");
            IDungeonObserver dungeonStatsObserver = new DungeonChangesObserver();
            IDungeonObserver dungeonCriticalObserver = new DungeonCriticalChangesObserver(10,10,10,10);
            dungeon.RegisterObserver(dungeonStatsObserver);
            dungeon.RegisterObserver(dungeonCriticalObserver);
            dungeon.DungeonKnownDeepness += 10;
            dungeon.DungeonDanger += 10;

        }
        public static void CommandTest()
        {
            Guardian templeGuardian = new Guardian();
            ICommand openGates = new OpenGatesCommand(templeGuardian);
            ICommand closeGates = new CloseGatesCommand(templeGuardian);

            CommandController control = new CommandController();

            control.SetCommand(openGates);
            control.PressButton();  
            control.PressUndo();   

            control.SetCommand(closeGates);
            control.PressButton();  
            control.PressUndo();   

        }
        public static void DecoreatorTest()
        {
            Troops soldier = new Soldier();
            Console.WriteLine($"Информация: {soldier.Info()}\nСтоимость обучения: {soldier.TrainingCost()}\n");
            Troops swordman = new Swordman(soldier);
            Console.WriteLine($"Информация: {swordman.Info()}\nСтоимость обучения: {swordman.TrainingCost()}\n");
            Troops commander = new Commander(swordman);
            Console.WriteLine($"Информация: {commander.Info()}\nСтоимость обучения: {commander.TrainingCost()}\n");
        }
        public static void AdapterTest()
        {
            DistanceWarrior gunsl = new Gunslinger();
            DistanceWarrior wizard = new WizardToDistanceWarriorAdapter();
            Console.WriteLine(gunsl.Shoot());
            Console.WriteLine(wizard.Shoot());
        }
        public static void AbstractFactoryTest()
        {
            TroopsFactory factory = new RedTroopsFactory();
            //TroopsFactory factory = new BlueTroopsFactory();
            Warrior war = factory.CreateWarrior();
            Archer arch = factory.CreateArcher();
            Console.WriteLine(war.GetInfo());
            Console.WriteLine(arch.GetInfo());
        }

        public static void SingletonTest()
        {
            // а что тут тестировать то :)
        }
    }
}
