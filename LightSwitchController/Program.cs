using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightSwitchController
{
    public class LightSwitchChangeEventArgs : EventArgs
    {
        public bool IsLight { get; }

        public LightSwitchChangeEventArgs(bool isLight)
        {
            IsLight = isLight;
        }
    }

    public class LightController
    {
        private bool _isLight = false;
        public void SetLightSwitcher(bool IsLight)
        {

            if (_isLight != IsLight)
            {
                _isLight = IsLight;
                LightSwitcherChanged(IsLight);
            }
        }

        public event Action<LightSwitchChangeEventArgs> OnLightSwitchChanged;
        private void LightSwitcherChanged(bool IsLight)
        {
            LightSwitcherChanged(new LightSwitchChangeEventArgs(IsLight));
        }

        protected virtual void LightSwitcherChanged(LightSwitchChangeEventArgs e)
        {
            OnLightSwitchChanged?.Invoke(e);
        }
    }

    public class Dispaly
    {
        public void Subscribe(LightController lightController)
        {
            lightController.OnLightSwitchChanged += HandleLightSwitcher;
        }

        public void HandleLightSwitcher(LightSwitchChangeEventArgs e)
        {
            if (e.IsLight)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("\n\nLigth Switch Changed: ");
                Console.WriteLine("Light is on");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("\n\nLigth Switch Changed: ");
                Console.WriteLine("Light is off");
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Dispaly dispaly = new Dispaly();
            LightController lightController = new LightController();
            dispaly.Subscribe(lightController);

            lightController.SetLightSwitcher(true);
            lightController.SetLightSwitcher(false);
            lightController.SetLightSwitcher(true);
            lightController.SetLightSwitcher(true);
            lightController.SetLightSwitcher(false);
            
            Console.ReadKey();

        }
    }
}
