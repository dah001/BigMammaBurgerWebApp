using ClassDemoKaffeWebApp.model;
using ClassDemoKaffeWebApp.services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ClassDemoKaffeWebApp.Pages.Kunder
{
    public class DeleteBurgerModel : PageModel
    {

        private IBurgerRepository _repo;
        public DeleteBurgerModel(IBurgerRepository repo)
        {
            _repo = repo;
        }

        public Burger burger { get; private set; }

        public IActionResult OnGet(int pris)
        {

            burger = _repo.HentBurger(pris);

            return Page();
        }

        public IActionResult OnPostDelete(int pris)
        {
            _repo.Slet(pris);

            return RedirectToPage("Index");
        }

        public IActionResult OnPostCancel()
        {
            return RedirectToPage("Index");
        }

        public void OnGet()
        {
        }
    }
}
