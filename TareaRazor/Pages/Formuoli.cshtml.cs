using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace TareaRazor.Pages
{
    public class FormuoliModel : PageModel
    {
        [BindProperty]
        [Required]
        public double A { get; set; }

        [BindProperty]
        [Required]
        public double B { get; set; }

        [BindProperty]
        [Required]
        public double X { get; set; }

        [BindProperty]
        [Required]
        public double Y { get; set; }

        [BindProperty]
        [Required]
        public int N { get; set; }

        public double Result { get; set; }

        public void OnGet()
        {
        }

        public void OnPost()
        {
            if (ModelState.IsValid)
            {
                Result = CalcularBinomial(A, B, X, Y, N);
            }
        }

        private double CalcularBinomial(double a, double b, double x, double y, int n)
        {
            double result = 0;
            for (int k = 0; k <= n; k++)
            {
                result += BinomioCoeficiente(n, k) * Math.Pow(a * x, n - k) * Math.Pow(b * y, k);
            }
            return result;
        }

        private double BinomioCoeficiente(int n, int k)
        {
            return Factorial(n) / (Factorial(k) * Factorial(n - k));
        }

        private double Factorial(int number)
        {
            double result = 1;
            for (int i = 1; i <= number; i++)
            {
                result *= i;
            }
            return result;
        }
    }
}
