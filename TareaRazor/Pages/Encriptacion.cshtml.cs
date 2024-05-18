using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Linq;

namespace TareaRazor.Pages
{
    public class EncriptacionModel : PageModel
    {
        [BindProperty]
        public string MensajeOriginal { get; set; }

        [BindProperty]
        public string MensajeCifrado { get; set; }

        [BindProperty]
        public int Clave { get; set; }

        // Definimos el alfabeto como un arreglo de caracteres
        private readonly char[] alfabeto = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

        public void OnGet()
        {
        }

        public IActionResult OnPostCodificar()
        {
            MensajeCifrado = CodificarMensaje(MensajeOriginal, Clave);
            return Page();
        }

        public IActionResult OnPostDecodificar()
        {
            MensajeOriginal = DecodificarMensaje(MensajeCifrado, Clave);
            return Page();
        }

        private string CodificarMensaje(string mensaje, int clave)
        {
            return TransformarMensaje(mensaje, clave, true);
        }

        private string DecodificarMensaje(string mensaje, int clave)
        {
            return TransformarMensaje(mensaje, clave, false);
        }

        private string TransformarMensaje(string mensaje, int clave, bool cifrar)
        {
            char[] mensajeTransformado = mensaje.ToCharArray();

            for (int i = 0; i < mensajeTransformado.Length; i++)
            {
                if (char.IsLetter(mensajeTransformado[i]))
                {
                    // Encontrar el índice del caracter en el alfabeto
                    int indice = Array.IndexOf(alfabeto, char.ToUpper(mensajeTransformado[i]));

                    // Calcular el nuevo índice basado en la clave
                    int nuevoIndice = cifrar ? (indice + clave) % alfabeto.Length : (indice - clave + alfabeto.Length) % alfabeto.Length;

                    // Actualizar el caracter en el mensaje transformado
                    mensajeTransformado[i] = char.IsUpper(mensajeTransformado[i]) ? alfabeto[nuevoIndice] : char.ToLower(alfabeto[nuevoIndice]);
                }
            }

            return new string(mensajeTransformado);
        }
    }
}
