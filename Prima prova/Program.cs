using Prima_prova.Classi;
using Prima_prova.Classi.Mosse;

internal class Program
{
    private static void Main(string[] args)
    {

        List<Personaggio> personaggi = CaricaPersonaggiDaFile(@"ProvaRPG.txt");       
        Board b = new Board(personaggi);
        b.Combatti(); 
    }

    private static List<Personaggio> CaricaPersonaggiDaFile(string path)
    {
        List<Personaggio> personaggi = new List<Personaggio>();

        string testoPersonaggi = File.ReadAllText(path);
        string[] datiPersonaggi = testoPersonaggi.Split("---");
        
        foreach (string dp in datiPersonaggi)
        {
            string[] campi = dp.Trim().Split("\r\n");

            if (campi.Length < 2) continue; 
            string[] statPersonaggio = campi[0].Split(",");
            Personaggio p = new Personaggio(statPersonaggio);
            p.InitMosse(MoveFactory.CreaMosse(p, campi[1]));
            personaggi.Add(p);
        }
        return personaggi; 
    }
}