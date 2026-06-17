using System.Xml.Linq;
using entitati;

namespace app1
{
    public class ServiciiMgr : ProduseAbstractMgr
    {
        public void AdaugaServiciu(Serviciu s)
        {
            elemente.Add(s);
        }

        public void SalveazaServiciiInXML(string path)
        {
            var servicii = elemente.OfType<Serviciu>();

            XElement xml = new XElement("servicii",
                from s in servicii
                select new XElement("Serviciu",
                    new XElement("Nume", s.Nume),
                    new XElement("CodIntern", s.CodIntern),
                    new XElement("Furnizor", s.Furnizor),
                    new XElement("Pret", s.Pret),
                    new XElement("Categorie", s.Categorie)
                )
            );

            xml.Save(path);
        }
    }
}
