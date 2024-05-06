using DriverLibrary;
using VehicleLibrary;
using System.Collections;
using System.Buffers;

namespace AdminLibrary
{
    public class Admin
    {
        private ArrayList driversList;
        public Admin()
        {
            driversList = new ArrayList();
        }

        public ArrayList DriversList
        {
            get { return driversList; }
            set { driversList = value; }
        }
        public void addDriver()
        {
            Driver driver = new Driver();
            Vehicle vehicle = new Vehicle();
            Console.Write("Enter Driver ID: ");
            driver.DriverID = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Name of driver: ");
            driver.Name = Console.ReadLine();
            Console.Write("Enter Age of driver: ");
            driver.Age = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Gender of driver: ");
            driver.Gender = Console.ReadLine();
            Console.Write("Enter Address of Driver: ");
            driver.Address = Console.ReadLine();
            Console.Write("Enter Phone Number(11-Digits): ");
            string phoneNo = Console.ReadLine();
            while(phoneNo.Length != 11)
            {
                Console.Write("ReEnter Phone Number in Valid Format(11-Digits): ");
                phoneNo = Console.ReadLine();
            }

            driver.PhoneNo = phoneNo;
            Console.WriteLine("*Enter Vehicle Info* ");
            Console.Write("Enter Type of Vehicle:");
            vehicle.Type = Console.ReadLine();
            Console.Write("Enter Model of Vehicle:");
            vehicle.Model = Console.ReadLine();
            Console.Write("Enter License Plate of Vehicle:");
            vehicle.LicensePlate = Console.ReadLine();
            driver.VehicleGS = vehicle;

            driversList.Add(driver);
            Console.WriteLine("Driver has been added to the List");
        }

        public void updateDriver(int driverID)
        {
            int i = 0;
            bool flag = false;
            Driver driver = new Driver();
            Vehicle vehicle = new Vehicle();
            for (i = 0; i < driversList.Count; i++)
            {
                driver = (Driver)driversList[i];
                if (driver.DriverID == driverID)
                {
                    flag = true;
                    break;
                }
            }

            if (flag)
            {
                Console.WriteLine($"Driver with ID {driverID} exists");
                Console.Write("Enter Name: ");
                string name = Console.ReadLine();
                if (name != "")
                {
                    driver.Name = name;
                }

                Console.Write("Enter Age: ");
                string age = Console.ReadLine();
                if (age != "")
                {
                    driver.Age = Convert.ToInt32(age);
                }

                Console.Write("Enter Gender: ");
                
                string gender = Console.ReadLine();
                if (gender != "")
                {
                    driver.Gender = gender;
                }

                Console.Write("Enter Address ");
                string address = Console.ReadLine();
                if (address != "")
                {
                    driver.Address = address;
                }

                Console.Write("Enter Phone Number: ");
                string phoneNo = Console.ReadLine();
                if (phoneNo != "")
                {
                    driver.PhoneNo = phoneNo;
                }

                Console.Write("Enter Vehicle Type: ");
                string type = Console.ReadLine();
                if (type != "")
                {
                    driver.VehicleGS.Type = type;
                }

                Console.Write("Enter Vehicle Model: ");
                string model = Console.ReadLine();
                if (model != "")
                {
                    driver.VehicleGS.Model = model;
                }

                Console.Write("Enter Vehicle License Plate: ");
                string licensePlate = Console.ReadLine();
                if (licensePlate != "")
                {
                    driver.VehicleGS.LicensePlate = licensePlate;
                }

                Console.WriteLine("*Driver has been updated*");
            }

            else
            {
                Console.WriteLine("Invalid Driver ID");
            }


        }

        public void removeDriver(int driverID)
        {
            int i = 0;
            bool flag = false;
            Driver driver = new Driver();
            for (i = 0; i < driversList.Count; i++)
            {
                driver = (Driver)driversList[i];
                if (driver.DriverID == driverID)
                {
                    flag = true;
                    break;
                }

            }

            if (flag)
            {
                driver = null;
                driversList.RemoveAt(i);
                Console.WriteLine("Driver has been Removed");
            }

            else
            {
                Console.WriteLine("Invalid Driver ID");
            }


        }

        public void searchDriver()
        {
            Console.Write("Enter Driver ID: ");
            int driverID = Convert.ToInt32(Console.ReadLine());

            int i = 0;
            bool flag = false, flag2 = true;
            Driver driver = new Driver();
            for (i = 0; i < driversList.Count; i++)
            {
                driver = (Driver)driversList[i];
                if (driver.DriverID == driverID)
                {
                    flag = true;
                    break;

                    break;
                }

            }
            if (flag)
            {
                Console.Write("Enter Driver Name: ");
                string name = Console.ReadLine();
                Console.Write("Enter Driver Age: ");
                string age = Console.ReadLine();
                Console.Write("Enter Driver Gender: ");
                string gender = Console.ReadLine();
                Console.Write("Enter Driver Vehicle Type: ");
                string type = Console.ReadLine();
                Console.Write("Enter Driver Vehicle model: ");
                string model = Console.ReadLine();
                Console.Write("Enter Driver Vehicle License Plate: ");
                string licensePlate = Console.ReadLine();




                if (name.Length > 0)
                {
                    if (name != driver.Name)
                    {
                        //Console.WriteLine("Enterd Wrong Data.");
                        flag2 = false;
                    }
                }

                if (age.Length > 0)
                {
                    if (Convert.ToInt32(age) != driver.Age)
                    {
                      //  Console.WriteLine("Enterd Wrong Data. No driver with this data exists.");
                        flag2 = false;
                    }
                }

                if (gender.Length > 0)
                {
                    if (gender != driver.Gender)
                    {
                    //    Console.WriteLine("Enterd Wrong Data. No driver with this data exists.");
                        flag2 = false;
                    }
                }

                if (type.Length > 0)
                {
                    if (type != driver.VehicleGS.Type)
                    {
                        flag2 = false;
                    }
                }

                if (model.Length > 0)
                {
                    if (model != driver.VehicleGS.Model)
                    {
                      //  Console.WriteLine("Enterd Wrong Data. No driver with this data exists.");
                        flag2 = false;
                    }
                }

                if (licensePlate.Length > 0)
                {
                    if (licensePlate != driver.VehicleGS.LicensePlate)
                    {
                      //  Console.WriteLine("Enterd Wrong Data. No driver with this data exists.");
                        flag2 = false;
                    }
                }

                if (flag2 == true)
                {
                    Console.WriteLine("-------------------------------------------------------------------------------------------");
                    Console.WriteLine("   Name   \t   Age   \t  Gender  \t  V.Type \t V.Model  \t   V.License");
                    Console.WriteLine("-------------------------------------------------------------------------------------------");
                    Console.WriteLine($"   {driver.Name,-10} \t  {driver.Age,-10} \t {driver.Gender,-10} \t {driver.VehicleGS.Type,-10} \t {driver.VehicleGS.Model,-10} \t {driver.VehicleGS.LicensePlate,10}");
                }

                if(flag2 == false)
                {
                    Console.WriteLine("Enterd Wrong Data. No driver with this data exists.");
                }

            }

            else
            {
                Console.WriteLine("Driver Doesnt Exist");
            }
        }

    }
}