using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    public interface IDungeonObserver
    {
        public void Update(int dungeonKnownDeepness, int dungeonDanger, int monsterMaxLevel, int missingExplorers);  
        public void InitializeInfo(string dungeonName, int dungeonKnownDeepness, int dungeonDanger, int monsterMaxLevel, int missingExplorers);  
    }
    public interface ISubject
    {
        void RegisterObserver(IDungeonObserver observer);
        void RemoveObserver(IDungeonObserver observer);
        void NotifyObservers();
    }
    public class Dungeon : ISubject
    {
        int dungeonKnownDeepness; 
        int dungeonDanger; 
        int monsterMaxLevel; 
        int missingExplorers;
        string dungeonName;
        public int DungeonKnownDeepness
        {
            get { return dungeonKnownDeepness; }
            set
            {
                this.dungeonKnownDeepness = value;
                NotifyObservers();
            }
        }
        public int DungeonDanger
        {
            get { return dungeonDanger; }
            set
            {
                this.dungeonDanger = value;
                NotifyObservers();
            }
        }
        public int MonsterMaxLevel
        {
            get { return monsterMaxLevel; }
            set
            {
                this.monsterMaxLevel = value;
                NotifyObservers();
            }
        }
        public int MissingExplorers
        {
            get { return missingExplorers; }
            set
            {
                this.missingExplorers = value;
                NotifyObservers();
            }
        }
        public string DungeonName
        {
            get { return this.dungeonName; }

        }
        private List<IDungeonObserver> observers;
        public Dungeon(string dungeonName, int dungeonKnownDeepness = 1, int dungeonDanger = 1, int monsterMaxLevel = 1, int missingExplorers = 0)
        {
            this.observers = new List<IDungeonObserver>();
            this.dungeonKnownDeepness = dungeonKnownDeepness;
            this.dungeonDanger = dungeonDanger;
            this.monsterMaxLevel = monsterMaxLevel;
            this.monsterMaxLevel = monsterMaxLevel;
            this.dungeonName = dungeonName;
        }
        public void NotifyObservers()
        {
            foreach (IDungeonObserver observer in this.observers)
            {
                observer.Update(this.DungeonKnownDeepness, this.DungeonDanger, this.MonsterMaxLevel, this.MissingExplorers);
            }
        }

        public void RegisterObserver(IDungeonObserver observer)
        {
            this.observers.Add(observer);
            observer.InitializeInfo(this.DungeonName, this.DungeonKnownDeepness, this.DungeonDanger, this.MonsterMaxLevel, this.MissingExplorers);
        }

        public void RemoveObserver(IDungeonObserver observer)
        {
            this.observers.Remove(observer);
        }
    }
    public class DungeonChangesObserver : IDungeonObserver
    {
        int dungeonKnownDeepness;
        int dungeonDanger;
        int monsterMaxLevel;
        int missingExplorers;
        string dungeonName = string.Empty;

        public void InitializeInfo(string dungeonName, int dungeonKnownDeepness, int dungeonDanger, int monsterMaxLevel, int missingExplorers)
        {
            this.dungeonKnownDeepness = dungeonKnownDeepness;
            this.dungeonDanger = dungeonDanger;
            this.monsterMaxLevel = monsterMaxLevel;
            this.monsterMaxLevel = monsterMaxLevel;
            this.dungeonName = dungeonName;
        }

        public void Update(int dungeonKnownDeepness, int dungeonDanger, int monsterMaxLevel, int missingExplorers)
        {
            Console.WriteLine(
                $"Параметры подземелья \"{dungeonName}\" изменились\n" +
                $"Глубина: {this.dungeonKnownDeepness} --> {dungeonKnownDeepness}\n" +
                $"Опасность: {this.dungeonDanger} --> {dungeonDanger}\n" +
                $"Максимальный уровень монстров: {this.monsterMaxLevel} --> {monsterMaxLevel}\n" +
                $"Количество пропавших исследователей: {this.missingExplorers} --> {missingExplorers}\n\n"
                );
            this.dungeonKnownDeepness = dungeonKnownDeepness;
            this.dungeonDanger = dungeonDanger;
            this.monsterMaxLevel = monsterMaxLevel;
            this.monsterMaxLevel = monsterMaxLevel;
        }

    }
    public class DungeonCriticalChangesObserver : IDungeonObserver
    {

        string dungeonName = string.Empty;
        int criticalDungeonKnownDeepness;
        int criticalDungeonDanger;
        int criticalMonsterMaxLevel;
        int criticalMissingExplorers;
        public DungeonCriticalChangesObserver(int criticalDungeonKnownDeepness, int criticalDungeonDanger, int criticalMonsterMaxLevel, int criticalMissingExplorers)
        {
            this.criticalDungeonKnownDeepness = criticalDungeonKnownDeepness;
            this.criticalDungeonDanger = criticalDungeonDanger;
            this.criticalMonsterMaxLevel = criticalMonsterMaxLevel;
            this.criticalMissingExplorers = criticalMissingExplorers;
        }
        public void InitializeInfo(string dungeonName, int dungeonKnownDeepness, int dungeonDanger, int monsterMaxLevel, int missingExplorers)
        {
            this.dungeonName = dungeonName;
        }

        public void Update(int dungeonKnownDeepness, int dungeonDanger, int monsterMaxLevel, int missingExplorers)
        {
            if (dungeonKnownDeepness >= this.criticalDungeonKnownDeepness)
            {
                Console.WriteLine(
                    $"В подземелье \"{this.dungeonName}\" превышен порог критического значения ГЛУБИНЫ!\n" +
                    $"Текущее значение: {dungeonKnownDeepness} критическое: {this.criticalDungeonKnownDeepness}\n" +
                    $"Вам следует обратить на него внимание!\n\n"
                    );
            }
            if (dungeonDanger >= this.criticalDungeonDanger)
            {
                Console.WriteLine(
                    $"В подземелье \"{this.dungeonName}\" превышен порог критического значения ОПАСНОСТИ!\n" +
                    $"Текущее значение: {dungeonDanger} критическое: {this.criticalDungeonDanger}\n" +
                    $"Вам следует обратить на него внимание!\n\n"
                    );
            }
            if (monsterMaxLevel >= this.criticalMonsterMaxLevel)
            {
                Console.WriteLine(
                    $"В подземелье \"{this.dungeonName}\" превышен порог критического значения УРОВНЯ МОНСТРОВ!\n" +
                    $"Текущее значение: {monsterMaxLevel} критическое: {this.criticalMonsterMaxLevel}\n" +
                    $"Вам следует обратить на него внимание!\n\n"
                    );
            }
            if (missingExplorers >= this.criticalMissingExplorers)
            {
                Console.WriteLine(
                    $"В подземелье \"{this.dungeonName}\" превышен порог критического значения ПРОПАВШИХ ИССЛЕДОВАТЕЛЕЙ!\n" +
                    $"Текущее значение: {missingExplorers} критическое: {this.criticalMissingExplorers}\n" +
                    $"Вам следует обратить на него внимание!\n\n"
                    );
            }
        }
    }

}
