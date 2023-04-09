using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _29._03._2023_dz_command
{
    interface ICommand
    {
        object Execut();
        void Undo();
    }

    class TvOnCommand : ICommand
    {
        public string tv;

        public TvOnCommand(string tv)
        {
            this.tv = tv;
        }

        public object Execut()
        {
            return "It's TV";
        }
        public void Undo()
        {
            Console.WriteLine($"TV: {tv}");
        }
    }

    class MicrowaveCommand : ICommand
    {
        public string microwave { set; get; }
        public string time { set; get; }

        public MicrowaveCommand(string microwave, string time)
        {
            this.microwave = microwave;
            this.time = time;
        }

        public object Execut()
        {
            return "It's Microwave";
        }
        public void Undo()
        {
            Console.WriteLine($"Microwave: {microwave}");
            Console.WriteLine($"Time: {time}");
        }
    }

    class Controller
    {
        ICommand command;

        public void SetOnController(ICommand command)
        {
            this.command = command;
        }
        public void SetOffController(ICommand command)
        {
            this.command = command;
        }

        public void PressButton()
        {
            var process = command.Execut();
        }
    }

    class Microwave
    {
        public void StartCooking()
        {
            Console.WriteLine("Microwave is cooking");
        }
        public void StopCooking()
        {
            Console.WriteLine("Microwave has been stop");
        }
    }

    class TV
    {
        public void On()
        {
            Console.WriteLine("Microwave is turning on");
        }
        public void Off()
        {
            Console.WriteLine("Microwave is turning off");
        }
    }



    internal class Program
    {
        static void Main(string[] args)
        {
            Controller controller = new Controller();
            controller.SetOnController(new MicrowaveCommand("microwave", "30 sec"));

            Microwave microwave = new Microwave();
            controller.SetOffController(new TvOnCommand("tv"));

        }
    }
}
