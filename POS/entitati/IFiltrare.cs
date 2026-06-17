using System.Collections.Generic;

namespace entitati
{
    public interface IFiltrare
    {
        IEnumerable<ProdusAbstract> Filtrare(IEnumerable<ProdusAbstract> elemente, ICriteriu criteriu);
    }
}
