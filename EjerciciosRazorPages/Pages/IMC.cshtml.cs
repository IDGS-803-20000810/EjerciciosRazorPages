using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EjerciciosRazorPages.Pages
{
    public class IMCModel : PageModel
    {
        [BindProperty]
        public string peso { get; set; } = "";
        [BindProperty]
        public string altura { get; set; } = "";

        public double imc = 0;
        public string mensaje = "";
        public void OnPost()
        {
            double pso = Convert.ToDouble(peso);
            double alt = Convert.ToDouble(altura);

            imc += pso/Math.Pow(alt,2);

            if (imc < 18)
            {
                mensaje = "Peso bajo";
            }
            else if (imc > 18 && imc < 25)
            {
                mensaje = "Peso normal";
            }
            else if (imc > 25 && imc < 27)
            {
                mensaje = "Sobre peso";
            }
            else if (imc > 27 && imc < 30)
            {
                mensaje = "Obesidad Grado 1";
            }
            else if (imc > 30 && imc < 40)
            {
                mensaje = "Obesidad Grado 2";
            }
            else if (imc >= 40)
            {
                mensaje = "Obesidad Grado 3";
            }

            ModelState.Clear();
        }
    }
}
