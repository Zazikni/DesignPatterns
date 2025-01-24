using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    public abstract class DistanceWarrior
    {
        public abstract string Shoot();
    }
    public class Gunslinger: DistanceWarrior
    {
        public override string Shoot()
        {
            return "Я стрелок. Я стреляю пулями.";
        }
    }
    public class Wizard
    {
        public  string Cast()
        {
            return "Я маг. Я стреляю огненными шарами.";
        }
    }
    public class WizardToDistanceWarriorAdapter: DistanceWarrior
    {
        private Wizard wizard;
        public WizardToDistanceWarriorAdapter()
        {
             this.wizard = new Wizard();
        }

        public override string Shoot()
        {
            return this.wizard.Cast();
        }
    }

}
