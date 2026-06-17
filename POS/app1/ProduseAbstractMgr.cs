using entitati;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace app1
{
    public abstract class ProduseAbstractMgr
    {
        protected static List<ProdusAbstract> elemente = new();

        public void Write2Console()
        {
            foreach (var elem in elemente)
                Console.WriteLine(elem.ToString());
        }

        public static List<ProdusAbstract> GetElemente() => elemente;

        public void InitProduseFromXML(string path)
        {
            try
            {
                XmlDocument doc = new();
                doc.Load(path);
                XmlNodeList? noduri = doc.SelectNodes("/produse/Produs");

                if (noduri != null)
                {
                    foreach (XmlNode nod in noduri)
                    {
                        string nume = nod["Nume"]?.InnerText ?? "";
                        string codIntern = nod["CodIntern"]?.InnerText ?? "";
                        string producator = nod["Producator"]?.InnerText ?? "";
                        int pret = int.Parse(nod["Pret"]?.InnerText ?? "0");
                        string categorie = nod["Categorie"]?.InnerText ?? "";

                        elemente.Add(new Produs((uint)elemente.Count + 1, nume, codIntern, producator, pret, categorie));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Eroare la incarcare produse din XML: " + ex.Message);
            }
        }

        public void InitServiciiFromXML(string path)
        {
            try
            {
                XmlDocument doc = new();
                doc.Load(path);
                XmlNodeList? noduri = doc.SelectNodes("/servicii/Serviciu");

                if (noduri != null)
                {
                    foreach (XmlNode nod in noduri)
                    {
                        string nume = nod["Nume"]?.InnerText ?? "";
                        string codIntern = nod["CodIntern"]?.InnerText ?? "";
                        string furnizor = nod["Furnizor"]?.InnerText ?? "";
                        int pret = int.Parse(nod["Pret"]?.InnerText ?? "0");
                        string categorie = nod["Categorie"]?.InnerText ?? "";

                        elemente.Add(new Serviciu((uint)elemente.Count + 1, nume, codIntern, furnizor, pret, categorie));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Eroare la incarcare servicii din XML: " + ex.Message);
            }
        }

        public void SaveListaToXML(string fileName)
        {
            try
            {
                Type[] types = { typeof(Produs), typeof(Serviciu), typeof(Pachet) };
                XmlSerializer xs = new XmlSerializer(typeof(List<ProdusAbstract>), types);
                using StreamWriter sw = new StreamWriter(fileName + ".xml");
                xs.Serialize(sw, elemente);
                Console.WriteLine("Lista serializata cu succes.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Eroare la salvarea listei XML: " + ex.Message);
            }
        }

        public void LoadListaFromXML(string fileName)
        {
            try
            {
                Type[] types = { typeof(Produs), typeof(Serviciu), typeof(Pachet) };
                XmlSerializer xs = new XmlSerializer(typeof(List<ProdusAbstract>), types);
                using FileStream fs = new FileStream(fileName + ".xml", FileMode.Open);
                List<ProdusAbstract>? lista = (List<ProdusAbstract>?)xs.Deserialize(fs);

                if (lista != null)
                {
                    elemente.Clear();
                    elemente.AddRange(lista);
                    Console.WriteLine("Lista incarcata din XML.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Eroare la incarcarea listei XML: " + ex.Message);
            }
        }
    }
}
