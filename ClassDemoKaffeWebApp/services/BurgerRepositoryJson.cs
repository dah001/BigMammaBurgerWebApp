using ClassDemoKaffeWebApp.model;
using System.Collections.Generic;
using System.Text.Json;

namespace ClassDemoKaffeWebApp.services
{
    public class BurgerRepositoryJson:IBurgerRepository
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
        public BurgerRepositoryJson()
        {
            _burgerkatalog = ReadFromJson();
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
            WriteToJson();
            return burger;
        }

        public Burger Slet(int pris)
        {
            Burger slettetBurger = HentBurger(pris);
            _burgerkatalog.Remove(pris);
            WriteToJson();
            return slettetBurger;
        }

        public Burger Tilføj(Burger burger)
        {
            if (!_burgerkatalog.ContainsKey(burger.Navn))
            {
                _burgerkatalog.Add(burger.Navn, burger);
                WriteToJson();
                return burger;
            }

            throw new ArgumentException($"navn {burger.Navn} findes i forvejen");
        }

        /*
         * Hjælpe metoder til at læse og skrive til en fil i json format
         * Const betyder konstant og kan ikke ændres
         */

        private const string FILENAME = "BurgerRepository.json";
        private Dictionary<string, Burger>? ReadFromJson()
        {
            if (File.Exists(FILENAME))
            {
                StreamReader sr = File.OpenText(FILENAME);
                return JsonSerializer.Deserialize<Dictionary<string, Burger>>(sr.ReadToEnd));
            }
            else  
            {
                return new Dictionary<string, Burger>();
            } 
        }   

        private void WriteToJson()
        {
            FileStream fs= new FileStream(FILENAME, FileMode.Create);
            Utf8JsonWriter writer = new Utf8JsonWriter(fs);
            JsonSerializer.Serialize(writer, _burgerkatalog );
            fs.Close();
        }

    }
}





    

