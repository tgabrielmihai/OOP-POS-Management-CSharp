using System;
using System.Xml.Serialization;
using System.IO;

namespace entitati
{
    [XmlRoot("ServiciuParticularizat")]
    public class Serviciu : ProdusAbstract
    {
        public string? Furnizor { get; set; }

        public Serviciu() { }

        public Serviciu(uint id, string? nume, string? codIntern, string? furnizor, int pret, string? categorie)
            : base(id, nume, codIntern, pret, categorie)
        {
            Furnizor = furnizor;
        }

        public override string Descriere()
        {
            return $"Serviciu: {Nume} [{CodIntern}] - {Furnizor}, {Pret} lei ({Categorie})";
        }

        public override bool canAddToPackage(Pachet pachet) => true;

        public void save2XML(string fileName)
        {
            try
            {
                XmlSerializer xs = new XmlSerializer(typeof(Serviciu));
                using StreamWriter sw = new StreamWriter(fileName + ".xml");
                xs.Serialize(sw, this);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Eroare la salvare XML: " + ex.Message);
            }
        }

        public static Serviciu? loadFromXML(string fileName)
        {
            try
            {
                XmlSerializer xs = new XmlSerializer(typeof(Serviciu));
                using FileStream fs = new FileStream(fileName + ".xml", FileMode.Open);
                return (Serviciu?)xs.Deserialize(fs);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Eroare la incarcare XML: " + ex.Message);
                return null;
            }
        }
    }
}
