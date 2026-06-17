using System.Xml.Linq;
using entitati;

namespace app1
{
    public class ProduseMgr : ProduseAbstractMgr
    {
        public void AdaugaProdus(Produs p)
        {
            elemente.Add(p);
        }

        public void SalveazaProduseInXML(string path)
        {
            var produse = elemente.OfType<Produs>();

            XElement xml = new XElement("produse",
                from p in produse
                select new XElement("Produs",
                    new XElement("Nume", p.Nume),
                    new XElement("CodIntern", p.CodIntern),
                    new XElement("Producator", p.Producator),
                    new XElement("Pret", p.Pret),
                    new XElement("Categorie", p.Categorie)
                )
            );

            xml.Save(path);
        }

        public new static List<ProdusAbstract> GetElemente() => ProduseAbstractMgr.GetElemente();
    }
}
