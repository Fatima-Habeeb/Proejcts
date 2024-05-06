using System.Security.Cryptography.X509Certificates;

namespace LocationLibrary
{
    public class Location
    {
        private double latitude;
        private double longitude;

        public double Latitude
        {
            get { return latitude; }
            set { latitude = value; }
        }

        public double Longitude
        {
            get { return longitude; }
            set { longitude = value; }
        }
        public void setLocation(double latitude, double longitude)
        {
            this.latitude = latitude;
            this.longitude = longitude;
        }
    }
}