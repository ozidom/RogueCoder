using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RogueCoder.Models
{
    public interface ICAO
    {
        int PassWord { get; set; }
        string Execute(string command);
        string GetID();
    }

    public abstract class ComputerAccessibleObject
    {
        public string name;
        public string password;
        private bool isConnected;

        public ComputerAccessibleObject()
        {
            this.password = "password";
            isConnected = false;
        }

        public ComputerAccessibleObject(string password)
        {
            this.password = password;
        }

        public bool IsConnected
        {
            get
            {
                return isConnected;
            }
        }

        public bool Connect()
        {
            if (password != string.Empty)
            {
                Connect(password);
            }
            return IsConnected;
        }

        public bool Connect(string password)
        {
            isConnected = (this.password == password);
            return IsConnected;
        }


        public virtual string GetDescription()
        {
            return "no description";
        }

        public abstract string Execute(string command);


        public override string ToString()
        {
            return name;
        }

    }

    public class AutoGunCAO : ComputerAccessibleObject
    {
        public override string Execute(string command)
        {
            return string.Empty;
        }
    }

    public class LightCAO : ComputerAccessibleObject
    {
        public bool state;

        public LightCAO()
        {
            name = "light";
            state = true;
        }

        public override string GetDescription()
        {
            return "Light is " + state.ToString();
        }

        public override string Execute(string command)
        {
            if (base.IsConnected)
            {
                state = (command.ToUpper() == "ON" ? true : false);
                return "Light is " + state.ToString();
            }
            return "Not connected to light";
        }
    }

    public class HatchCAO : ComputerAccessibleObject
    {
        public bool state;

        public HatchCAO()
        {
            name = "Hatch";
            state = false;
        }

        public override string GetDescription()
        {
            return "Hatch is " + state.ToString();
        }

        public override string Execute(string command)
        {
            if (base.IsConnected)
            {
                state = (command.ToUpper() == "ON" ? true : false);
                return "Hatch is " + state.ToString();
            }
            return "Not connected to Hatch";
        }
    }

    public class ElevatorLockCAO : ComputerAccessibleObject
    {
        public bool state;

        public ElevatorLockCAO()
        {
            name = "ElevatorLock";
            state = true;
        }

        public override string GetDescription()
        {
            return "Elavtor Lock is " + state.ToString();
        }

        public override string Execute(string command)
        {
            if (base.IsConnected)
            {
                state = (command.ToUpper() == "ON" ? true : false);
                return "Lock is " + state.ToString();
            }
            return "Not connected to Elevator lock";
        }
    }

    public class ConsoleCAO : ComputerAccessibleObject
    {
        public override string Execute(string command)
        {
            return string.Empty;
        }
    }

    public class ElevatorCAO : ComputerAccessibleObject
    {
        public override string Execute(string command)
        {
            return string.Empty;
        }
    }
}
