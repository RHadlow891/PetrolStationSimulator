using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace assignment4
{
    class Management
    {
        //Where display class is assigned
        private Display m_Display;
        //Creates a list of pumps which are called in the pump class
        private List<Pump> m_Pump = new List<Pump>();
        
        //Setting data types for use in functions
        private int m_timeLeft = 0;
        private int m_vehicleType;
        private int m_vehicleNum = 0;
        private double totalFuelPumped = 0;

        //Creation of timers with randomizer
        Timer timer = new Timer();
        static Random rnd = new Random();

        //Management function
        public Management()
        {
            //Uses a for loop to create up to 9 pumps
            for (int i = 0; i < 9; i++)
            {
                m_Pump.Add(new Pump(i + 1));
            }

            m_Display = new Display();
            
            timer.Elapsed += new ElapsedEventHandler(timeUp);

            this.timeGenerator();
            timer.Enabled = true;
        }
        //Generates a random time from 1.5 seconds to 2.2 seconds for creating the next vehicle
        private void timeGenerator()
        {
            Random rnd = new Random();
            timer.Interval = rnd.Next(1500, 2201);
        }

        //Uses accessors to get the pump number and set a value
        public List<Pump> PumpList
        {
            get { return m_Pump; }
            set { m_Pump = value; }
        }

        //Function that uses a switch case to select a random vehicle
        private Vehicle generateVehicle()
        {
           int vehicleType = rnd.Next(0, 3);

            Vehicle vehicle = new Vehicle();

            switch (vehicleType)
            {
                case 0:
                    vehicle = new Car();
                    break;
                case 1:
                    vehicle = new Van();
                    break;
                case 2:
                    vehicle = new HGV();
                    break;
            }
            m_vehicleNum += 1;
            return vehicle;
        }

        public void timeUp(Object source, ElapsedEventArgs e)
        {
            foreach (Pump pump in m_Pump)
            {
                if (pump.isAvailable())
                {
                    pump.assignPump(generateVehicle());
                    break;
                } else
                {
                    if(pump.getVehicle().isFull())
                    {
                        totalFuelPumped += pump.getVehicle().maxFuel();
                        pump.unassignPump();
                    }
                }
            }

            this.m_Display.drawTable(m_Pump, totalFuelPumped, m_vehicleNum);
            this.timeGenerator();
        }
    }
}
