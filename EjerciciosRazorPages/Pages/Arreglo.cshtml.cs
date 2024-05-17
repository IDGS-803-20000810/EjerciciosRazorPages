using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EjerciciosRazorPages.Pages
{
    public class ArregloModel : PageModel
    {
        public string resArreglo = "";
        public string suma = "";
        public string media = "";
        public string mediana = "";
        public string moda = "";


        public void OnPost()
        {
            int[] arreglo = new int[20];
            
            int _suma = 0;
            double _media = 0;
            int _mediana = 0;

            for (int i = 0; i < 20; i++)
            {
                Random random = new Random();
                int numRandom = random.Next(1, 100);

                arreglo[i] = numRandom;

                _suma += numRandom;

            }

            _media = arreglo.Average();
            
            suma = _suma.ToString();
            media = _media.ToString();
            mediana = Mediana(arreglo).ToString();

            foreach (var num in Moda(arreglo))
            {
                moda = moda + ", " + num;
            }

            foreach (var num in arreglo)
            {
                resArreglo = resArreglo +','+ num.ToString();
            }

            ModelState.Clear();
        }

        static double Mediana(int[] nums)
        {
            int[] sortedNums = (int[])nums.Clone();
            Array.Sort(sortedNums);

            int size = sortedNums.Length;
            int mid = size / 2;

            if (size % 2 == 0)
            {
                return (sortedNums[mid - 1] + sortedNums[mid]) / 2.0;
            }
            else
            {
                return sortedNums[mid];
            }
        }

        static List<int> Moda(int[] nums)
        {
            Dictionary<int, int> counts = new Dictionary<int, int>();

            foreach (int num in nums)
            {
                if (counts.ContainsKey(num))
                {
                    counts[num]++;
                }
                else
                {
                    counts[num] = 1;
                }
            }

            int max = counts.Values.Max();
            List<int> modas = counts.Where(pair => pair.Value == max).Select(pair => pair.Key).ToList();

            return modas;
        }
    }
}
