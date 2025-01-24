using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    public interface ICommand // command
    {
        void Execute();
        void Unexecute();
    }


    public class Guardian // reciver
    {
        public void OpenCastleGates()
        {
            Console.WriteLine("Врата дворца открыты.");
        }
        public void CloseCastleGates()
        {
            Console.WriteLine("Врата дворца закрыты.");
        }
    }
    public class OpenGatesCommand : ICommand // concrete command 1
    {
        private Guardian guardian;
        public OpenGatesCommand(Guardian guardian)
        {
            this.guardian = guardian;
        }
        public void Execute() { guardian.OpenCastleGates(); }
        public void Unexecute() { guardian.CloseCastleGates(); }
    }
    public class CloseGatesCommand : ICommand // concrete command 2
    {
        private Guardian guardian;
        public CloseGatesCommand(Guardian guardian)
        {
            this.guardian = guardian;
        }
        public void Execute() { guardian.CloseCastleGates(); }
        public void Unexecute() { guardian.OpenCastleGates(); }
    }
    public class CommandController // invoker
    {
        private ICommand command;

        public void SetCommand(ICommand command)
        {
            this.command = command;
        }

        public void PressButton()
        {
            this.command.Execute();
        }

        public void PressUndo()
        {
            this.command.Unexecute();
        }
    }

}
