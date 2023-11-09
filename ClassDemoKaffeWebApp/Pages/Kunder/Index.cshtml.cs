using ClassDemoKaffeWebApp.model;
using ClassDemoKaffeWebApp.services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ClassDemoKaffeWebApp.Pages.Kunder
{
    public class IndexModel : PageModel
    {
        // instans af kunde repository
        private IBurgerRepository _repo;

        // Dependency Injection
        public IndexModel(IBurgerRepository repository)
        {
            _repo = repository;
        }





        // property til View'et
        public List<Burger> burgers { get;  set; }

        public void OnGet()
        {

            //IBurgerRepository repo = new IBurgerRepositry(true);

            burgers = _repo.HentAlleBurger();

        }

        public IActionResult OnPost()
        {
            return RedirectToPage("NyBurger");
        }
    }
}
