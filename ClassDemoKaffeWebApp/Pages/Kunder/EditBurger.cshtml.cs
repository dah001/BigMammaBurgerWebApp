using ClassDemoKaffeWebApp.model;
using ClassDemoKaffeWebApp.services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ClassDemoKaffeWebApp.Pages.Kunder
{
    public class EditBurgerModel : PageModel
    {
        private IBurgerRepository _repo;

        public EditBurgerModel(IBurgerRepository repo)
        {
            _repo = repo;
        }


        [BindProperty]
        public int pris { get; set; }


        [BindProperty]
        [Required(ErrorMessage = "Der skal være et navn")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Der skal være mindst to tegn i et navn")]
        public string Navn { get; set; }



        [BindProperty]
        public string Størrelse { get; set; }


        public string ErrorMessage { get; private set; }
        public bool Error { get; private set; }



        public void OnGet(int pris)
        {
            ErrorMessage = "";
            Error = false;

            try
            {
                Burger burger = _repo.HentBurger(pris);

                pris = burger.pris;
                Navn = burger.Navn;
                Størrelse = burger.størrelse;
            }
            catch (KeyNotFoundException knfe)
            {
                ErrorMessage = knfe.Message;
                Error = true;
            }
        }


        public IActionResult OnPostChange()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Burger burger = _repo.Opdater(new Burger(pris, Navn, Størrelse));
            return RedirectToPage("Index");
        }



        public IActionResult OnPostCancel()
        {
            return RedirectToPage("Index");
        }
    }
}