using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment4
{
    class Pump
    {
        private Vehicle m_CurrentVehicle;
        private int m_PumpNum;
        private double m_price = 1.2;
        private double m_commission = 0.01;
        public Pump()
        {
        }

        public Pump(int _pNum)
        {
            m_PumpNum = _pNum;
            m_CurrentVehicle = null;
        }
        //function that call the current vehicle from the vehicle class
        public void assignPump(Vehicle _vehicle)
        {
            m_CurrentVehicle = _vehicle;
            
        }

        public void unassignPump()
        {
            m_CurrentVehicle = null;
        }
        //Boolean function explaining the availabilty of a vehicle, showing when it is null to simplify the program
        public bool isAvailable()
        {
            return (m_CurrentVehicle == null);
        }
        //this function will get the pump number from the pump function
        public int getPumpNo()
        {
            return m_PumpNum;
        }
        //returns current vehicle
        public Vehicle getVehicle()
        {
            return m_CurrentVehicle;
        }
        //function used for the price of total fuel
        public double price()
        {
            return m_price;
        }
        //function used for the total commission
        public double commission()
        {
            return m_commission;
        }
    }
}
