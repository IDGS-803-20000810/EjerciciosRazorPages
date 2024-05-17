using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Runtime.InteropServices.Marshalling;

namespace EjerciciosRazorPages.Pages
{
    public class CesarModel : PageModel
    {
        [BindProperty]
        public string texto { get; set; } = "";
        [BindProperty]
        public string n { get; set; } = "";

        public string resultado = "";

        char[] letras = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'X', 'Y', 'Z' };
        
        public void OnPostEncriptar()
        {
            texto = texto.ToUpper();
            char[] arrayTexto = texto.ToCharArray();
            int num = int.Parse(n);

            for (int i = 0; i < arrayTexto.Length; i++)
            {
                if (arrayTexto[i] != ' ')
                {
                    int index = Array.IndexOf(letras, arrayTexto[i]);

                    if ((index + num) >= letras.Length)
                    {
                        index = (index + num) - letras.Length;
                    }
                    else
                    {
                        index += num;
                    }

                    arrayTexto[i] = letras[index];
                }

                
            }

            resultado = new string(arrayTexto);
            ModelState.Clear();
        }

        public void OnPostDesencriptar()
        {
            texto = texto.ToUpper();
            char[] arrayTexto = texto.ToCharArray();
            int num = int.Parse(n);

            for (int i = 0; i < arrayTexto.Length; i++)
            {
                if (arrayTexto[i] != ' ')
                {
                    int index = Array.IndexOf(letras, arrayTexto[i]);

                    if ((index - num) < 0)
                    {
                        index = (index - num) + letras.Length;
                    }
                    else
                    {
                        index -= num;
                    }

                    arrayTexto[i] = letras[index];
                }
            }

            resultado = new string(arrayTexto);
            ModelState.Clear();
        }
    }
}
