using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TareaRazor.Pages
{
    public class IMCModel : PageModel
    {
        //Definimos propiedades
        [BindProperty]
        public string peso { get; set; } = "";
        [BindProperty]
        public string altura { get; set; } = "";

        public double result;

        public void OnPost()
        {



            double p = double.Parse(peso);
            double h = double.Parse(altura);

            result = p / (h * h);

            ModelState.Clear();


        }
    }
}
