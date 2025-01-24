using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    public abstract class Warrior
    {
        public abstract string GetInfo();
    }

    public class RedWarrior:Warrior
    {
        
        public override string GetInfo()
        {
            return "Я воин красной команды";
        }

    }
    public class BlueWarrior : Warrior
    {

        public override string GetInfo()
        {
            return "Я воин синей команды";
        }

    }
    public abstract class Archer
    {
        public abstract string GetInfo();
    }
    public class RedArcher : Archer
    {

        public override string GetInfo()
        {
            return "Я лучник красной команды";
        }

    }
    public class BlueArcher : Archer
    {

        public override string GetInfo()
        {
            return "Я лучник синей команды";
        }

    }
    public abstract class TroopsFactory()
    {
        public abstract Warrior CreateWarrior();
        public abstract Archer CreateArcher();

    }
    public class RedTroopsFactory: TroopsFactory
    {
        public override Warrior CreateWarrior()
        {
            return new RedWarrior();
        }
        public override Archer CreateArcher()
        {
            return new RedArcher();
        }

    }
    public class BlueTroopsFactory:TroopsFactory
    {
        public override Warrior CreateWarrior()
        {
            return new BlueWarrior();
        }
        public override Archer CreateArcher()
        {
            return new BlueArcher();
        }

    }
}
