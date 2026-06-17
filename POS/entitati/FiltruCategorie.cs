namespace entitati
{
    public class FiltruCategorie : ICriteriu
    {
        private string categorie;

        public FiltruCategorie(string categorie)
        {
            this.categorie = categorie;
        }

        public bool IsIndeplinit(ProdusAbstract element)
        {
            return element.Categorie == categorie;
        }
    }
}
