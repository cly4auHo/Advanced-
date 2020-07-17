namespace Home4.CarShop
{
    public class Owner
    {
        private string name = "DEFAULT_NAME";
        private long phoneNumber;

        public string Name { get => name; set => name = value ?? "DEFAULT_NAME"; }
        public long PhoneNumber { get => phoneNumber; set => phoneNumber = value; }

        public Owner() { }

        public Owner(string name, long phoneNumber)
        {
            this.name = name;
            this.phoneNumber = phoneNumber;
        }

        public override string ToString()
        {
            return "Name: " + name + ", phoneNumber: " + phoneNumber;
        }
    }
}
