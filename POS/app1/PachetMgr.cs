using entitati;
using System.Collections.Generic;

namespace app1
{
    internal class PachetMgr : ProduseAbstractMgr
    {
        public void ReadPachet()
        {
            Console.WriteLine("Creeaza un pachet:");

            Console.Write("Nume: ");
            string? nume = Console.ReadLine();

            Console.Write("Cod intern: ");
            string? codIntern = Console.ReadLine();

            Console.Write("Categorie: ");
            string? categorie = Console.ReadLine();

            var pachet = new Pachet((uint)elemente.Count + 1, nume, codIntern, 0, categorie);

            Console.Write("Pret total estimat: ");
            int pret = int.Parse(Console.ReadLine() ?? "0");
            pachet.Pret = pret;

            Console.Write("Cate produse sa adaugi in pachet? ");
            int nrProduse = int.Parse(Console.ReadLine() ?? "0");

            for (int i = 0; i < nrProduse; i++)
            {
                Console.WriteLine($"Produs #{i + 1}:");
                var p = Program.CitesteProdus();
                if (p.canAddToPackage(pachet))
                    pachet.Adauga(p);
            }

            Console.Write("Cate servicii sa adaugi in pachet? ");
            int nrServicii = int.Parse(Console.ReadLine() ?? "0");

            for (int i = 0; i < nrServicii; i++)
            {
                Console.WriteLine($"Serviciu #{i + 1}:");
                var s = Program.CitesteServiciu();
                if (s.canAddToPackage(pachet))
                    pachet.Adauga(s);
            }

            elemente.Add(pachet);
        }
    }
}
