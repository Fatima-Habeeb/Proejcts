 using System.Collections;
using System.Data.Common;
using System.Linq;
using VehicleLibrary;
using LocationLibrary;

namespace DriverLibrary
{
    public class Driver
    {
        private int driverID;
        private string name;
        private int age;
        private string gender;
        private string address;
        private string phoneNo;
        private bool availability;
        private ArrayList rating;
        private Vehicle vehicle;
        private Location currLocation;

        public Driver(int aDriverID = 1, string aName = null, int aAge = 0, string aGender = null, string aAddress = null, string aPhoneNo = null)
        {
            driverID = aDriverID;
            name = aName;
            age = aAge;
            gender = aGender;
            address = aAddress;
            phoneNo = aPhoneNo;
            Availability = false;
            vehicle = new Vehicle();
            currLocation = new Location();
            rating = new ArrayList();

        }

        public int DriverID
        {
            get { return driverID; }
            set
            {
                if (value > 0)
                {
                    driverID = value;
                }

            }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Gender
        {
            get { return gender; }
            set { gender = value; }
        }

        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public string PhoneNo
        {
            get { return phoneNo; }
            set { phoneNo = value; }

        }

        public bool Availability
        {
            get { return availability; }
            set { availability = value; }

        }
        public string Address
        {
            get { return address; }
            set
            {
                address = value;
            }
        }

        public Vehicle VehicleGS
        {
            get { return vehicle; }
            set
            {
                vehicle = new Vehicle();
                vehicle = value;
            }
        }

        public Location LocationGS
        {
            get { return currLocation; }
            set { currLocation = value; }
        }


        public ArrayList Rating
        {
            get { return rating; }
            set { rating = value; }

        }

        public void updateAvailability()
        {
            if (availability == true)
            {
                availability = false;
            }

            else
            {
                availability = true;
            }
        }

        public double getRating()
        {
            double average = rating.Cast<float>().Average();
            return average;
        }

        public void updateLocation()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            bool flag = false;
            Console.WriteLine("*Enter Location*");
            Console.WriteLine("*Range: -90 to 90 for latitude and -180 to 180 for longitude*");
            while (flag != true)
            {
                Console.Write("Enter Latitude of your location: ");
                double latitude = Convert.ToDouble(Console.ReadLine());
                Console.Write("Enter Longitude of your location: ");
                double longitude = Convert.ToDouble(Console.ReadLine());
                if ((latitude >= (-90) && latitude <= 90) && (longitude >= (-180) && longitude <= 180))
                {

                    currLocation.setLocation(latitude, longitude);
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

    }
}
