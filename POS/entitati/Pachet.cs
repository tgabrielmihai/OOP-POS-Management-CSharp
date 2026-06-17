using System.Collections.Generic;
using System.Linq;

namespace entitati
{
    public class Pachet : ProdusAbstract
    {
        private List<IPackageable> elem_pachet { get; set; } = new();

        public Pachet() : base() { }

        public Pachet(uint id, string? nume, string? codIntern, int pret, string? categorie)
            : base(id, nume, codIntern, pret, categorie)
        {
        }

        public void Adauga(IPackageable element)
        {
            if (element.canAddToPackage(this))
                elem_pachet.Add(element);
        }

        public bool ContineProdus() =>
            elem_pachet.Any(e => e is Produs);

        public int PretTotal() =>
            elem_pachet.Sum(e => (e as ProdusAbstract)?.Pret ?? 0);

        public override string Descriere() =>
            $"PACHET: {Nume} (Total: {PretTotal()} lei)";

        public override string AltaDescriere() =>
            $"{Descriere()} - Elemente: {elem_pachet.Count}";

        public override bool canAddToPackage(Pachet p) => false;
    }
}
