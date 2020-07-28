using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment4
{//Parent class
    public class Vehicle
    {
        //Vehicle attributes with assigned data types
        protected Random m_rnd = new Random();
        protected string m_fueltype;
        protected int fuelAmount;
        protected double m_maxfuel;
        protected string m_vehicleType;
        protected int m_createdTime;

        //Vehicle method that allows the current time method to be called through the created time
        public Vehicle()
        {
            m_createdTime = getCurrentTime();
        }
        //Returns the fuel type as a string
        public string getFType()
        {
            return m_fueltype;
        }
        //Returns the vehicle type as a string
        public string getVehicleType()
        {
            return m_vehicleType;
        }
        //Returns the current time
        private int getCurrentTime()
        {
            return (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            //https://stackoverflow.com/questions/17632584/how-to-get-the-unix-timestamp-in-c-sharp/17632585 (StackOverflow, July 13th 2013)
        }
        //boolean function that checks if the amount of fuel is greater than the max fuel time
        public bool isFull()
        {
            return ((this.amountFuel()) > m_maxfuel);
        }
        
        public int amountFuel()
        {
            return getCurrentTime() - m_createdTime;
        }
        //The max fuel is the time in which the vehicle will stop filling
        public double maxFuel()
        {
            return m_maxfuel;
        }
    }
    //Child Car class
    public class Car : Vehicle
    {

        public Car() : base()
        {
            //random time from 17 to 19
            m_vehicleType = "Car";
            m_maxfuel = m_rnd.Next(17,19);

            //random number from 1 to 4
            int ifueltype = m_rnd.Next(1, 4);

            //switch case listing fuel types
            switch (ifueltype)
            {
                case 1:
                    m_fueltype = "Unleaded";
                    break;
                case 2:
                    m_fueltype = "Diesel";
                    break;
                case 3:
                    m_fueltype = "LPG";
                    break;
                default:
                    Exception error = new Exception("Fuel type not known");
                    break;
            }
        }
    }
    //Van
    public class Van : Vehicle
    {
        public Van() : base()
        {
            m_vehicleType = "Van";
            m_maxfuel = m_rnd.Next(17, 19);

            int ifueltype = m_rnd.Next(1, 4);

            switch (ifueltype)
            {
                case 1:
                    m_fueltype = "Unleaded";
                    break;
                case 2:
                    m_fueltype = "Diesel";
                    break;
                case 3:
                    m_fueltype = "LPG";
                    break;
                default:
                    Exception error = new Exception("Fuel type not known");
                    break;
            }
        }
    }
    //HGV
    public class HGV : Vehicle
    {
        public HGV() : base()
        {
            m_vehicleType = "HGV";
            m_maxfuel = m_rnd.Next(17, 19);

            int ifueltype = m_rnd.Next(1, 4);

            switch (ifueltype)
            {
                case 1:
                    m_fueltype = "Unleaded";
                    break;
                case 2:
                    m_fueltype = "Diesel";
                    break;
                case 3:
                    m_fueltype = "LPG";
                    break;
                default:
                    Exception error = new Exception("Fuel type not known");
                    break;
            }
        }
    }

}
