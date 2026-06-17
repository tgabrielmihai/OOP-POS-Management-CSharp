namespace entitati
{
    public class FiltruPretMaxim : ICriteriu
    {
        private int pretMax;

        public FiltruPretMaxim(int pretMax)
        {
            this.pretMax = pretMax;
        }

        public bool IsIndeplinit(ProdusAbstract element)
        {
            return element.Pret <= pretMax;
        }
    }
}
