using System;

namespace entitati
{
    public class Produs : ProdusAbstract
    {
        public string? Producator { get; set; }

        public Produs() { }

        public Produs(uint id, string? nume, string? codIntern, string? producator, int pret, string? categorie)
            : base(id, nume, codIntern, pret, categorie)
        {
            Producator = producator;
        }

        public override string Descriere()
        {
            return $"Produs: {Nume} [{CodIntern}] - {Producator}, {Pret} lei ({Categorie})";
        }

        public override bool canAddToPackage(Pachet pachet)
        {
            // acceptăm doar UN singur produs într-un pachet
            return !pachet.ContineProdus();
        }

        public override int GetHashCode() =>
            HashCode.Combine(CodIntern, Nume, Producator);

        public override bool Equals(object? obj) =>
            obj is Produs p && CodIntern == p.CodIntern;
    }
}
