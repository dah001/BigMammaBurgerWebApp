using ClassDemoKaffeWebApp.model;


namespace ClassDemoKaffeWebApp.services
{
    public class BurgerRepository: IBurgerRepository
    {
        // instans felt
        Dictionary<string, Burger> _burgerkatalog;

        public Dictionary<string, Burger> Burgerkatalog
        {
            get { return _burgerkatalog; }
            set { _burgerkatalog = value; }
        }

        public Dictionary<int, Burger> Katalog { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        // konstruktør
        public BurgerRepository(bool mockData = false)
        {
            _burgerkatalog = new Dictionary<string,Burger>();


            if (mockData)
            {
                PopulateburgerRepository();
            }
        }

        private void PopulateburgerRepository()
        {
            _burgerkatalog.Clear();

            _burgerkatalog.Add("1", new Burger(79, "Big mamma", "Small"));
            _burgerkatalog.Add("2", new Burger(79, "Big papa", "Small"));
            _burgerkatalog.Add("3", new Burger(79, "Mexicano", "Small"));
            _burgerkatalog.Add("4", new Burger(95, "Barbecue", "Large"));
            _burgerkatalog.Add("5", new Burger(87, "American", "Medium"));

        }

        public List<Burger> HentAlleBurger()
        {
            return _burgerkatalog.Values.ToList();
        }
        public Burger HentBurger(int pris)
        {
            if (_burgerkatalog.ContainsKey(pris))
            {
                return _burgerkatalog[pris];
            }
            else
            {
            }
            {
                // opdaget en fejl
                throw new KeyNotFoundException($"pris {pris} findes ikke");
            }
        }

        public Burger HentBurgerUdFraNavn(string Navn)
        {
        Burger resBurger = null;

        foreach (Burger b in _burgerkatalog.Values)
         
             if (b.Navn == Navn)
             {
               return b;
             }
               
        }
        public Burger Opdater(Burger burger)
        {
            Burger editBurger = HentBurger(burger.pris);
            _burgerkatalog[burger.Navn] = burger;
            return burger;
        }

        public Burger Slet(int pris)
        {
            Burger slettetBurger = HentBurger(pris);
            _burgerkatalog.Remove(pris);
            return slettetBurger;
        }

        public Burger Tilføj(Burger burger)
        {
            if (!_burgerkatalog.ContainsKey(burger.Navn))
            {
                _burgerkatalog.Add(burger.Navn, burger);

                return burger;
            }

            throw new ArgumentException($"navn {burger.Navn} findes i forvejen");
        }
    }
}

