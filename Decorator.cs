using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    public abstract class Troops
    {
        public abstract string Info();
        public abstract int TrainingCost();
    }
    public class Soldier : Troops
    {

        public override string Info()
        {
            return "Солдат";
        }

        public override int TrainingCost()
        {
            return 1;
        }    }
    public abstract class TroopsDecorator : Troops
    {
        private Troops decorated_troops;
        public TroopsDecorator(Troops troops)
        {
            this.decorated_troops = troops;
        }
        public override string Info()
        {
            return decorated_troops.Info();
        }

        public override int TrainingCost()
        {
            return decorated_troops.TrainingCost();
        }
    }
    public class Swordman : TroopsDecorator
    {
        public  Swordman(Troops troops) : base(troops) { }
        public override string Info()
        {
            return base.Info() + " + броня + меч";
        }

        public override int TrainingCost()
        {
            return base.TrainingCost() + 10;
        }
    }
    public class Commander : TroopsDecorator
    {
        public Commander(Troops troops) : base(troops) { }
        public override string Info()
        {
            return base.Info() + " + крутая броня + доргой меч + модная фляжка + знания";
        }

        public override int TrainingCost()
        {
            return base.TrainingCost() + 100;
        }
    }
}
