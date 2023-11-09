using ClassDemoKaffeWebApp.model;
using ClassDemoKaffeWebApp.services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace ClassDemoKaffeWebApp.Pages.Kunder
{
    public class NyBurgerModel : PageModel
    {
        private IBurgerRepository _repo;

        public NyBurgerModel(IBurgerRepository repo)
        {
            _repo = repo;
        }

        [BindProperty]
        public int pris { get; set; }


        [BindProperty]
        [Required(ErrorMessage = "Der skal v�re et navn")]
        [StringLength(10, MinimumLength = 2, ErrorMessage = "Der skal v�re mindst to tegn i et navn")]
        public string navn { get; set; }



        [BindProperty]
        public string st�rrelse { get; set; }


        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Burger nyBurger = new Burger(pris, navn, st�rrelse);

            //IBurgerRepository repo = new BurgerRepository(true);
            _repo.Tilf�j(nyBurger);

            return RedirectToPage("Index");
        }
    }
}