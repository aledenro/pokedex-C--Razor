using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PokedexWeb.Models;
using PokedexWeb.Services;
using System.Security.Policy;

namespace PokedexWeb.Pages.Views.Batalla
{
    public class BatallaModel : PageModel
    {

        private readonly RetoService _retoService;

        public BatallaModel(RetoService retoService)
        {
            _retoService = retoService;
        }

        public IEnumerable<RetoModel> Retos { get; set; }

        public void OnGet()
        {
            Retos = _retoService.GetRetos();
        }
    }
}
