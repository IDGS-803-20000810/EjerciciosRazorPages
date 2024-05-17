using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EjerciciosRazorPages.Pages
{ 
    public class IgualdadModel : PageModel
    {
        [BindProperty]
        public string a { get; set; } = "0";
        [BindProperty]
        public string b { get; set; } = "0";
        [BindProperty]
        public string x { get; set; } = "0";
        [BindProperty]
        public string y { get; set; } = "0";
        [BindProperty]
        public string n { get; set; } = "0";

        public string resultado1 = "";
        public string resultado2 = "";
        public string resultado3 = "";

        public void OnPost()
        {
            int _a = int.Parse(a);
            int _b = int.Parse(b);
            int _x = int.Parse(x);
            int _y = int.Parse(y);
            int _n = int.Parse(n);

            double res1 = Math.Pow((_a * _x) + (_b * _y), _n);

            resultado1 = res1.ToString();

            double res2 = 0;

            for (int k = 0; k <= _n; k++)
            {
                double p1 = factorial(_n) / (factorial(k) * factorial(_n - k));
                double p2 = Math.Pow((_a * _x), _n - k);
                double p3 = Math.Pow((_b * _y), k);

                double ec = p1* p2* p3;

                res2 += ec;
            }

            resultado2 = res2.ToString();

            int _res1 = Convert.ToInt32(res1);
            int _res2 = Convert.ToInt32(res2);

            if (res1 == res2)
            {
                resultado3 = "Igual";
            }
            else
            {
                resultado3 = "No Igual";
            }
        }

        int factorial (int num)
        {
            int fact = 1;

            while (num>1)
            {
                fact = fact*num;
                num--;
            }

            return fact;
        }
    }
}
