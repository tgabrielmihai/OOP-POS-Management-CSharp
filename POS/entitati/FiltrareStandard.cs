using System.Collections.Generic;
using System.Linq;

namespace entitati
{
    public class FiltrareStandard : IFiltrare
    {
        public IEnumerable<ProdusAbstract> Filtrare(IEnumerable<ProdusAbstract> elemente, ICriteriu criteriu)
        {
            return elemente.Where(e => criteriu.IsIndeplinit(e));
        }
    }
}
