namespace ClassDemoKaffeWebApp.model
{
    public class Burger
    {
        /*
         * Instans felter
         */
        private int _pris;
        private string _navn;
        private string _størrelse;

        /*
         * Properties
         */
        public int pris
        {
            get { return _pris; }
            set { _pris = value; }
        }

        public string Navn
        {
            get { return _navn; }
            set { _navn = value; }
        }

        public string størrelse
        {
            get { return _størrelse; }
            set { _størrelse = value; }
        }

        public string Pris { get; internal set; }

        /*
         * Constructor
         */
        public Burger()
        {
            _pris = 0;
            _navn = "";
            _størrelse = "";
        }
        public Burger(int pris, string navn, string størrelse)
        {
              _pris = pris;
              _navn = navn;
              _størrelse = størrelse;
        }   
    }
}
