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
        [Required(ErrorMessage = "Der skal være et navn")]
        [StringLength(10, MinimumLength = 2, ErrorMessage = "Der skal være mindst to tegn i et navn")]
        public string navn { get; set; }



        [BindProperty]
        public string størrelse { get; set; }


        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Burger nyBurger = new Burger(pris, navn, størrelse);

            //IBurgerRepository repo = new BurgerRepository(true);
            _repo.Tilføj(nyBurger);

            return RedirectToPage("Index");
        }
    }
}