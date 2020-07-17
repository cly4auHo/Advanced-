namespace Home4.FitnesCenter
{
    public class Customer
    {
        private int number;
        private int year;
        private int month;
        private int session;

        public int Number { get => number; set => number = value; }
        public int Year { get => year; set => year = value; }
        public int Month { get => month; set => month = value; }
        public int Session { get => session; set => session = value; }

        public Customer() { }

        public Customer(int number, int year, int month, int session)
        {
            if (number < 0) number = 0;
            if (year < 1900 || year > 2020) year = 1900;
            if (month <= 0 || month > 12) month = 1;
            if (session < 0) session = 0;

            this.number = number;
            this.year = year;
            this.month = month;
            this.session = session;
        }

        public override string ToString()
        {
            return "Number :" + number + " year: " + year + " month: " + month + " session: " + session;
        }
    }
}
