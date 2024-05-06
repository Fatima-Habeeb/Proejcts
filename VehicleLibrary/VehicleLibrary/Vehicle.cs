namespace VehicleLibrary
{
    public class Vehicle
    {
        private string type;
        private string model;
        private string licensePlate;

       /* public Vehicle(string type = null, string model = null, string licensePlate = null)
        {
            this.type = type;
            this.model = model;
            this.licensePlate = licensePlate;
        }*/
        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        public string Model
        {
            get { return model; }   
            set { model = value; }
        }

        public string LicensePlate
        {
            get { return licensePlate; }
            set { licensePlate = value; }
        }
    }
}