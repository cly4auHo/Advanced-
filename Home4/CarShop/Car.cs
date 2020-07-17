namespace Home4.CarShop
{
    public class Car
    {
        private Owner owner;
        private int releaseDate;
        private string mark = "DEFAULT_MARK";
        private string model = "DEFAULT_MODEL";
        private string colour = "DEFAULT_COLOUR";

        public Owner Owner { get => owner; set => owner = value; }
        public int ReleaseDate => releaseDate;
        public string Mark => mark;
        public string Model => model;
        public string Colour { get => colour; set => colour = value ?? "DEFAULR_COLOUR"; }

        public Car() { }

        public Car(Owner owner, int releaseDate, string mark, string model, string colour)
        {
            this.owner = owner;
            this.releaseDate = releaseDate;
            this.mark = mark;
            this.model = model;
            this.colour = colour;
        }

        public override string ToString()
        {
            return "Owher: {" + owner.ToString() + "}, releaseDate: " + releaseDate + ", mark: " + mark + ", model: " + model + ", colour: " + colour;
        }
    }
}
