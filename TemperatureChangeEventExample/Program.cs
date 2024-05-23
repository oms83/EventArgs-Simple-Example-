using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TemperatureChangeEventExample
{
    public class TemperatureChangeEventArgs : EventArgs
    {
        public int OldTemperature { get;  }
        public int NewTemperature { get;  }
        public int Diffrence { get;  }

        public TemperatureChangeEventArgs(int OldTemperature,  int NewTemperature)
        {
            this.NewTemperature = NewTemperature;
            this.OldTemperature = OldTemperature;
            this.Diffrence = NewTemperature - OldTemperature;
        }
    }

    public class Thermostat
    {
        public event EventHandler<TemperatureChangeEventArgs> OnTemperatureChanged;
        private int OldTemperature;
        private int CurrentTemperature;

        public void SetTemperature(int NewTemperature)
        {
            if (NewTemperature != CurrentTemperature)
            {
                this.OldTemperature = this.CurrentTemperature;
                this.CurrentTemperature = NewTemperature;
                TemperatureChanged(OldTemperature, CurrentTemperature);
            }
        }
        private void TemperatureChanged(int OldTemperature, int NewTemperature)
        {
            TemperatureChanged(new TemperatureChangeEventArgs(OldTemperature, NewTemperature));
        }

        protected virtual void TemperatureChanged(TemperatureChangeEventArgs e)
        {
            OnTemperatureChanged?.Invoke(this, e);
        }
    }

    public class Display
    {
        public void Subscribe(Thermostat thermostat)
        {
            thermostat.OnTemperatureChanged += HandleTemperatureChange;
        }
        public void HandleTemperatureChange(object sender, TemperatureChangeEventArgs e)
        {
            Console.WriteLine("\n\nTemperature Changed: ");
            Console.WriteLine($"Temperature changed from {e.OldTemperature}");
            Console.WriteLine($"Temperature changed to {e.NewTemperature}");
            Console.WriteLine($"Temperatures Diffrence {e.Diffrence}");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Thermostat thermostat = new Thermostat();
            Display display = new Display();
            display.Subscribe(thermostat);
            thermostat.SetTemperature(23);
            thermostat.SetTemperature(25);
            thermostat.SetTemperature(45);
            thermostat.SetTemperature(20);

            Console.ReadKey();
        }
    }
}
