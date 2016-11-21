using ModelEtudiant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWrapper
{
    class Program
    {
        static void Main(string[] args)
        {
            var algo = new Algo();
            var res = algo.CreateMap(42);
            foreach (var tile in res.Tiles)
                Console.WriteLine(tile); 
            Console.ReadLine();
        }
    }
}
