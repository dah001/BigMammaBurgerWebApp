using ClassDemoKaffeWebApp.model;
using System.Text;

namespace ClassDemoKaffeWebApp.services
{
    public interface IBurgerRepository
    {
        public Dictionary<int,Burger> Katalog { get; set; }

        List<Burger> HentAlleBurger();
        Burger HentBurger(int pris);
        Burger HentBurgerUdFraNavn(string Navn);
        Burger Opdater(Burger burger);
        Burger Slet(int pris);
        Burger Tilføj(Burger burger);
    }
}