
namespace PassengerLibrary
{
    public class Passenger
    {
        private string name;
        private string phoneNo;

        public Passenger(string name = null, string phoneNo = null)
        {
            this.name = name;
            this.phoneNo = phoneNo;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string PhoneNo
        {
            get { return phoneNo; }
            set { phoneNo = value; }
        }
    }
}