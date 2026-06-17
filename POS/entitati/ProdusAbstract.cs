namespace entitati
{
    public abstract class ProdusAbstract : IPackageable
    {
        public uint Id { get; set; }
        public string? Nume { get; set; }
        public string? CodIntern { get; set; }
        public int Pret { get; set; }
        public string? Categorie { get; set; }

        protected ProdusAbstract() { }

        protected ProdusAbstract(uint id, string? nume, string? codIntern, int pret, string? categorie)
        {
            Id = id;
            Nume = nume;
            CodIntern = codIntern;
            Pret = pret;
            Categorie = categorie;
        }

        public abstract string Descriere();

        public virtual string AltaDescriere()
        {
            return $"{Nume} [{CodIntern}] - {Pret} lei / {Categorie}";
        }

        public override string ToString()
        {
            return Descriere();
        }

        public virtual bool canAddToPackage(Pachet pachet) => true;
    }
}
