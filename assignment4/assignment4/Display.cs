using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment4
{
    class Display
    {
        //Fucntion that aligns the display in a neat order
        public void drawTable(List<Pump> pumps, double maxFuelAmount, int m_vehicleNum)
        {

            Console.Clear();
            this.drawPumpNos(pumps);
            this.drawAvailability(pumps);
            this.drawVehicles(pumps, maxFuelAmount, m_vehicleNum);
            
        }
        //Displays the pumps in order
        private void drawPumpNos(List<Pump> pumps)
        {
            string output = "";

            foreach (Pump pump in pumps)
            {
                output = output + "Pump " + pump.getPumpNo() + " --- ";
            }

            Console.WriteLine(output);
        }
        //A loop that defines the availability of a pump
        private void drawAvailability(List<Pump> pumps)
        {
            string output = "";
            
            foreach (Pump pump in pumps)
            {
                output = output + (pump.isAvailable() ? "Available --- " : "Unavailable --- ");
            }

            Console.WriteLine(output);
        }
        //Orders the Vehicles with the fuel type and amount of fuel together
        private void drawVehicles(List<Pump> pumps, double maxFuelAmount, int m_vehicleNum)
        {
            string output = "";

            foreach (Pump pump in pumps)
            {
                if (pump.isAvailable())
                    output = output + "N/A --- ";
                else
                    output = output + pump.getVehicle().getVehicleType() + "-" + pump.getVehicle().getFType() + "-" + pump.getVehicle().amountFuel() + " --- ";
                
            }
            //Writelines that display the main output as well as the counters
            Console.WriteLine(output);
            Console.WriteLine("Total fuel in current system: " + totalFuel(pumps));
            Console.WriteLine("Total fuel pumped so far: " + (maxFuelAmount + totalFuel(pumps)));
            Console.WriteLine("Total price spent (£1.20 per litre): " + fuelPrice(maxFuelAmount, pumps));
            Console.WriteLine("Total commission: " + commissionTotal(maxFuelAmount, pumps));
            Console.WriteLine("Total number of vehicles: " + m_vehicleNum);
        }
        //Counter for fuel price
        private double fuelPrice(double maxFuelAmount, List<Pump> pumps)
        {
            return (maxFuelAmount + totalFuel(pumps)) * pumps[0].price();
        }

        //Counter for the total commission
        private double commissionTotal(double fuelPrice, List<Pump> pumps)
        {
            return fuelPrice * pumps[0].commission();
        }



        //Counter for the total fuel
        private int totalFuel(List<Pump> pumps)
        {
            int total = 0;

            foreach (Pump pump in pumps)
            {
                if (!pump.isAvailable())
                    total += pump.getVehicle().amountFuel();
                
            }
            return total;
        }
    }
}
