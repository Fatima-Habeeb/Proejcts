using DriverLibrary;
using PassengerLibrary;
using VehicleLibrary;
using RideLibrary;
using LocationLibrary;
using AdminLibrary;
using System;
using System.Buffers;
using System.Linq.Expressions;
using System.Collections;

class MyClass
{

    static public void Main(String[] args)
    {
        Ride ride = new Ride();
        Admin admin = new Admin();
        Driver driver = new Driver();
        int input = -1;
        while (input < 4)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n------------------------------------------------------------------------------------");
            Console.WriteLine("\t\t\t\tWELCOME TO MY RIDE");
            Console.WriteLine("------------------------------------------------------------------------------------");
            Console.WriteLine("1. Book a Ride");
            Console.WriteLine("2. Enter as Driver");
            Console.WriteLine("3. Enter as Admin");
            Console.WriteLine("4. Exit");
            Console.Write("Press 1 to 4 to select an Option: ");
            input = Convert.ToInt32(Console.ReadLine());

            if (input == 1)
            {

                Console.WriteLine("\n*Book A Ride*");
                ride.assignPassenger();
                ride.getLocation();
                Console.Write("Enter Ride Type(Car, Bike, Rickshaw): ");
                string type = Console.ReadLine();
                while (type != "Car" && type != "car" && type != "CAR" && type != "Bike" && type != "bike" && type != "bike" && type != "Rickshaw" && type != "rickshaw" && type != "RICKSHAW")
                {
                    Console.Write("Renter Valid Ride type: ");
                    type = Console.ReadLine();
                }
                Console.WriteLine("\n--------------THANK YOU--------------\n");
                Driver driver1 = ride.assignDriver(admin);
                if (driver1 != null)
                {
                    Console.WriteLine("\n*Congratulations! We found a driver for you*");
                    int price = (int)ride.calculatePrice(type);
                    Console.WriteLine("Price for this ride is " + price);
                    Console.WriteLine("Enter 'Y' or 'y' if you want to Book the ride");
                    Console.WriteLine(" Enter 'N' or 'n' if you want to cancel operation: ");
                    char IN = Convert.ToChar(Console.ReadLine());
                    if (IN == 'Y' || IN == 'y')
                    {
                        Console.WriteLine("\nHappy Travel....!");
                        int rating = ride.giveRating();
                        Driver driver2 = new Driver();
                        for(int i=0; i<admin.DriversList.Count; i++)
                        {
                            driver2 = (Driver)admin.DriversList[i];
                            if(driver2.DriverID == driver1.DriverID)
                            {
                                driver1.Rating.Add(rating);
                                break;
                            }
                        }


                    }

                    if (IN == 'N' || IN == 'n')
                    {
                        Console.WriteLine("\nNo ride has been booked.");

                    }
                }

                else if (driver1 == null)
                {
                    Console.WriteLine("\nSorry, No driver is availbale at this moment. Kindly try Later!");

                }


            }

            else if (input == 2)
            {
                bool flag = true;
                Console.WriteLine("\n*Enter as Driver*");
                Console.Write("Enter ID: ");
                int ID = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter Name: ");
                string name = Console.ReadLine();
                for (int i = 0; i < admin.DriversList.Count; i++)
                {
                    driver = (Driver)admin.DriversList[i];
                    if (ID == driver.DriverID)
                    {
                        flag = true;
                        break;
                    }


                }

                if (!flag)
                {
                    Console.WriteLine("\n*Invalid Credentials*");

                }

                else
                {
                    Console.WriteLine("Hello " + driver.Name);

                    int input2 = -1;
                    while (input2 < 3)
                    {
                        Console.WriteLine("\n1. Change Availability");
                        Console.WriteLine("2. Change Location");
                        Console.WriteLine("3. Exit as Driver");
                        Console.Write("Input: ");
                        input2 = Convert.ToInt32(Console.ReadLine());

                        if (input2 == 1)
                        {
                            bool availability = driver.Availability;
                            if (availability == true)
                                Console.WriteLine("Your Current Availability: Available");
                            else
                                Console.WriteLine("Your Current Availability: Not Available");
                            Console.WriteLine("Updating availability");
                            driver.updateAvailability();
                            Console.WriteLine("Your Availabilty has been changed");

                        }


                        if (input2 == 2)
                        {
                            Console.WriteLine("\n*Changing Location*");
                            driver.updateLocation();
                        }
                    }
                }
            }

            else if (input == 3)
            {
                int input1 = -1;
                Console.WriteLine("\n*Enter as Admin*");
                while (input1 < 5)
                {
                    Console.WriteLine("\n1. Add Driver");
                    Console.WriteLine("2. Remove Driver");
                    Console.WriteLine("3. Update Driver");
                    Console.WriteLine("4. Search Driver");
                    Console.WriteLine("5. Exit as Admin");
                    Console.Write("Input: ");
                    input1 = Convert.ToInt32(Console.ReadLine());

                    if (input1 == 1)
                    {
                        admin.addDriver();

                    }

                    else if (input1 == 2)
                    {
                        Console.Write("Enter Driver ID To be Removed: ");
                        int ID = Convert.ToInt32(Console.ReadLine());
                        admin.removeDriver(ID);
                    }

                    else if (input1 == 3)
                    {
                        Console.Write("Enter Driver ID To be Updates: ");
                        int ID = Convert.ToInt32(Console.ReadLine());
                        admin.updateDriver(ID);
                    }

                    else if (input1 == 4)
                    {
                        admin.searchDriver();
                    }

                    else if (input1 == 5)
                    {
                        Console.WriteLine("*Exiting from Admin Menu*");
                    }
                }
            }
        }
    }
}
