using LocationLibrary;
using PassengerLibrary;
using DriverLibrary;
using AdminLibrary;
using VehicleLibrary;
using System.Collections;

namespace RideLibrary
{
    public class Ride
    {
        private Location startLocation;
        private Location endLocation;
        private double price;
        private Driver driver;
        private Passenger passenger;

        public Location StartLocation
        {
            get { return startLocation; }
            set { startLocation = value; }
        }

        public Location EndLocation
        {
            get { return endLocation; }
            set { endLocation = value; }
        }

        public double Price
        {
            get { return price; }
            set { price = value; }
        }

        public Driver DriverGS
        {
            get { return driver; }
            set { driver = value; }
        }

        public Passenger PassengerGS
        {
            get { return passenger; }
            set { passenger = value; }
        }

        public Ride(double startLatitude = 0.0, double startLongitude = 0.0, double endLatitude = 0.0, double endLongitude = 0.0)
        {
            startLocation = new Location();
            startLocation.Latitude = startLatitude;
            startLocation.Longitude = startLongitude;

            endLocation = new Location();
            endLocation.Latitude = endLatitude;
            endLocation.Longitude = endLongitude;
            passenger = new Passenger();


        }
        public void assignPassenger()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Enter Passenger Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter passenger Phone Number(11-Digits): ");
            string phoneNo = Console.ReadLine();
            while (phoneNo.Length != 11)
            {
                Console.Write("Enter Valid Phone No Format of 11 Digits: ");
                phoneNo = Console.ReadLine();
            }
            passenger.Name = name;
            passenger.PhoneNo = phoneNo;
        }

        public Driver assignDriver(Admin admin)
        {
            double min = 0;
            int i = 0;
            int a = 0;
            bool flag = false;
            double distance = 0;

            if (admin.DriversList.Count == 0)
            {
                driver = null;
                return driver;
            }

            driver = (Driver)admin.DriversList[0];
            distance = Math.Sqrt(Math.Pow((startLocation.Longitude - driver.LocationGS.Longitude), 2) + Math.Pow((startLocation.Latitude - driver.LocationGS.Latitude), 2));
            min = distance;

            if (admin.DriversList.Count > 1)
            {
                for (i = 1; i < admin.DriversList.Count; i++)
                {

                    driver = (Driver)admin.DriversList[i];
                    distance = Math.Sqrt(Math.Pow((startLocation.Longitude - driver.LocationGS.Longitude), 2) + Math.Pow((startLocation.Latitude - driver.LocationGS.Latitude), 2));

                    if ((distance < min || distance == min) && driver.Availability == true)
                    {
                        min = distance;
                        a = i;
                        flag = true;
                    }
                }

                if (flag)
                {
                    driver = (Driver)admin.DriversList[a];
                    driver.Availability = false;

                }
            }

            if (admin.DriversList.Count == 1)
            {
                driver.Availability = false;
                flag = true;
            }

            return driver;

        }


        public void getLocation()
        {
            Console.ForegroundColor= ConsoleColor.Green;
            bool flag = false;
            Console.WriteLine("*Enter Location*");
            Console.WriteLine("*Range: -90 to 90 for latitude and -180 to 180 for longitude*");

            double startLatitude, startLongitude, endLatitude, endLongitude;
            while (flag != true)

            {
                Console.WriteLine("Enter Latitude for Start Location: ");
                startLatitude = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Enter Longitude for Start Location: ");
                startLongitude = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Enter Latitude for End Location: ");
                endLatitude = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Enter Longtiude for End Location: ");
                endLongitude = Convert.ToDouble(Console.ReadLine());

                if ((startLatitude >= (-90) && startLatitude <= 90) && (startLongitude >= (-180) && startLongitude <= 180) && (endLatitude >= (-90) && endLatitude <= 90) && (endLongitude >= (-180) && endLongitude <= 180))
                {
                    startLocation.setLocation(startLatitude, startLongitude);
                    endLocation.setLocation(endLatitude, endLongitude);
                    flag = true;
                    break;

                }
                else
                {
                    flag = false;
                    Console.WriteLine("*ReEnter Valid Location Parameters* ");
                }
                
            }

        }

        public double calculatePrice(string type)
        {
            double fuelPrice = 200.0;
            //distance of the ride.
            double distance = Math.Sqrt(Math.Pow((startLocation.Longitude - endLocation.Longitude), 2) + Math.Pow((startLocation.Latitude - endLocation.Latitude), 2));
            if (type == "Bike" || type == "bike" || type == "BIKE")
            {
                price = ((distance * fuelPrice) / 50) + 0.05;
            }

            else if (type == "Rickshaw" || type == "rickshaw" || type == "RICKSHAW")
            {
                price = ((distance * fuelPrice) / 35) + 0.1;
            }

            else if (type == "Car" || type == "car" || type == "CAR")
            {
                price = ((distance * fuelPrice) / 15) + 0.2;
            }

            return price;
        }

        public int giveRating()
        {
            int rating = 0;
          
            Console.Write("Give Rating to the Ride from 1 to 5: ");
            rating=Convert.ToInt32(Console.ReadLine());
            while (rating <1 || rating >5)
            {
                Console.WriteLine("*Kindly Enter Rating between 1 to 5*");
                rating = Convert.ToInt32(Console.ReadLine());

            }

            return rating;  
        }
    }
}


