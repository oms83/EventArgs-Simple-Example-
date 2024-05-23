using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficSignalController
{
    public class TrafficLightChangeEventArgs : EventArgs
    {
        public string NewLightColor { get; }
        public string OldLightColor { get; }

        public TrafficLightChangeEventArgs(string newLightColor, string oldLightColor)
        {
            NewLightColor = newLightColor;
            OldLightColor = oldLightColor;
        }
    }

    public class LigthController
    {
        private string CurrentLightColor = "Red";
        private string OldLightColor = "Green";

        public event EventHandler<TrafficLightChangeEventArgs> OnTrafficLightChange;
        public void SetLightColor(string NewLightColor)
        {
            if (CurrentLightColor != NewLightColor)
            {
                OldLightColor = CurrentLightColor;
                CurrentLightColor = NewLightColor;
                TrafficLightChange(OldLightColor, NewLightColor);
            }
            
        }
        protected void TrafficLightChange(string OldLightColor,  string NewLightColor)
        {
            TrafficLightChange(new TrafficLightChangeEventArgs(NewLightColor, OldLightColor));
        }
        protected virtual void TrafficLightChange(TrafficLightChangeEventArgs e)
        {
            OnTrafficLightChange?.Invoke(this, e);
        }
    }

    public class Display
    {
        public void Subscribe(LigthController controller)
        {
            controller.OnTrafficLightChange += HandleTrafficLightChange;
        }

        private void PrintDetails(TrafficLightChangeEventArgs e)
        {
            Console.WriteLine("\n\nTraffic Ligth Changed: ");
            Console.WriteLine($"Old Light Color: {e.OldLightColor}");
            Console.WriteLine($"New Light Color: {e.NewLightColor}");
        }

        public void HandleTrafficLightChange(object sender, TrafficLightChangeEventArgs e)
        {
            switch(e.NewLightColor.ToLower())
            {
                case "yellow":
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    PrintDetails(e);
                    break;

                case "red":
                    Console.ForegroundColor = ConsoleColor.Red;
                    PrintDetails(e);
                    break;

                case "green":
                    Console.ForegroundColor = ConsoleColor.Green;
                    PrintDetails(e);
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\n\nThe traffic light is out of order:-(");
                    break;  
            }
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            LigthController controller = new LigthController();
            Display display = new Display();
            display.Subscribe(controller);
            controller.SetLightColor("yellow");
            controller.SetLightColor("yellow");
            controller.SetLightColor("green");
            controller.SetLightColor("red");
            controller.SetLightColor("blue");

            Console.ReadKey();
        }
    }
}
