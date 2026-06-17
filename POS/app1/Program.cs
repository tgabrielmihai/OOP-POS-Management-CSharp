using app1;
using entitati;
using System;
using System.Linq;

internal class Program
{
    private static void Main(string[] args)
    {
        ProduseMgr produseMgr = new();
        ServiciiMgr serviciiMgr = new();
        PachetMgr pachetMgr = new();

        while (true)
        {
            Console.WriteLine("\n--- MENIU ---");
            Console.WriteLine("1. Adauga produs");
            Console.WriteLine("2. Adauga serviciu");
            Console.WriteLine("3. Afiseaza toate");
            Console.WriteLine("4. Salveaza in XML (produse/servicii)");
            Console.WriteLine("5. Incarca din XML (produse/servicii)");
            Console.WriteLine("6. Interogari LINQ");
            Console.WriteLine("7. Adauga pachet");
            Console.WriteLine("8. Sorteaza pachetele dupa pret");
            Console.WriteLine("9. Filtrare dupa categorie");
            Console.WriteLine("10. Filtrare dupa pret maxim");
            Console.WriteLine("11. Serializare lista completa in XML");
            Console.WriteLine("12. Deserializare lista completa din XML");
            Console.WriteLine("13. Serializare serviciu individual");
            Console.WriteLine("14. Deserializare serviciu individual");
            Console.WriteLine("0. Iesire");
            Console.Write("Optiune: ");
            string? opt = Console.ReadLine();

            switch (opt)
            {
                case "1":
                    var p = CitesteProdus();
                    produseMgr.AdaugaProdus(p);
                    break;

                case "2":
                    var s = CitesteServiciu();
                    serviciiMgr.AdaugaServiciu(s);
                    break;

                case "3":
                    Console.WriteLine("\n--- Elemente introduse ---");
                    produseMgr.Write2Console();
                    break;

                case "4":
                    produseMgr.SalveazaProduseInXML("Produse.xml");
                    serviciiMgr.SalveazaServiciiInXML("Servicii.xml");
                    Console.WriteLine("Datele au fost salvate.");
                    break;

                case "5":
                    ProduseAbstractMgr mgr1 = produseMgr;
                    ProduseAbstractMgr mgr2 = serviciiMgr;
                    mgr1.InitProduseFromXML("Produse.xml");
                    mgr2.InitServiciiFromXML("Servicii.xml");
                    Console.WriteLine("Datele au fost incarcate din XML.");
                    break;

                case "6":
                    InterogariLINQ();
                    break;

                case "7":
                    pachetMgr.ReadPachet();
                    break;

                case "8":
                    var pachete = ProduseMgr.GetElemente().OfType<Pachet>().ToList();
                    pachete.Sort((a, b) => a.PretTotal().CompareTo(b.PretTotal()));
                    Console.WriteLine("\nPachete sortate dupa pret total:");
                    foreach (var pk in pachete)
                        Console.WriteLine(pk.AltaDescriere());
                    break;

                case "9":
                    Console.Write("Categorie: ");
                    string? cat = Console.ReadLine();
                    var fc = new FiltruCategorie(cat ?? "");
                    var fs = new FiltrareStandard();
                    var rezultatCat = fs.Filtrare(ProduseMgr.GetElemente(), fc);
                    Console.WriteLine("\nRezultatul filtrarii:");
                    foreach (var e in rezultatCat)
                        Console.WriteLine(e.AltaDescriere());
                    break;

                case "10":
                    Console.Write("Pret maxim: ");
                    int max = int.Parse(Console.ReadLine() ?? "0");
                    var fp = new FiltruPretMaxim(max);
                    var rezultatPret = new FiltrareStandard().Filtrare(ProduseMgr.GetElemente(), fp);
                    Console.WriteLine("\nRezultatul filtrarii:");
                    foreach (var e in rezultatPret)
                        Console.WriteLine(e.AltaDescriere());
                    break;

                case "11":
                    produseMgr.SaveListaToXML("ListaElemente");
                    break;

                case "12":
                    produseMgr.LoadListaFromXML("ListaElemente");
                    break;

                case "13":
                    var serv = CitesteServiciu();
                    serv.save2XML("ServiciuTest");
                    break;

                case "14":
                    var sLoaded = Serviciu.loadFromXML("ServiciuTest");
                    if (sLoaded != null)
                        Console.WriteLine("Serviciu deserializat: " + sLoaded.Descriere());
                    break;

                case "0":
                    return;

                default:
                    Console.WriteLine("Optiune invalida.");
                    break;
            }
        }
    }

    public static Produs CitesteProdus()
    {
        Console.Write("Nume: ");
        string? nume = Console.ReadLine();
        Console.Write("Cod intern: ");
        string? cod = Console.ReadLine();
        Console.Write("Producator: ");
        string? prod = Console.ReadLine();
        Console.Write("Pret: ");
        int pret = int.Parse(Console.ReadLine() ?? "0");
        Console.Write("Categorie: ");
        string? cat = Console.ReadLine();

        return new Produs(0, nume, cod, prod, pret, cat);
    }

    public static Serviciu CitesteServiciu()
    {
        Console.Write("Nume: ");
        string? nume = Console.ReadLine();
        Console.Write("Cod intern: ");
        string? cod = Console.ReadLine();
        Console.Write("Furnizor: ");
        string? furn = Console.ReadLine();
        Console.Write("Pret: ");
        int pret = int.Parse(Console.ReadLine() ?? "0");
        Console.Write("Categorie: ");
        string? cat = Console.ReadLine();

        return new Serviciu(0, nume, cod, furn, pret, cat);
    }

    private static void InterogariLINQ()
    {
        var toate = ProduseMgr.GetElemente();

        var ieftineIT = toate
            .Where(e => e.Categorie == "IT" && e.Pret <= 2000)
            .OrderBy(e => e.Nume);

        Console.WriteLine("\n--- Produse/servicii IT sub 2000 lei ---");
        foreach (var e in ieftineIT)
            Console.WriteLine(e.AltaDescriere());

        var grupate = from e in toate
                      group e by e.Categorie into gr
                      select gr;

        Console.WriteLine("\n--- Grupare pe categorii ---");
        foreach (var gr in grupate)
        {
            Console.WriteLine($"Categoria: {gr.Key}");
            foreach (var e in gr)
                Console.WriteLine("  " + e.AltaDescriere());
        }
    }
}
