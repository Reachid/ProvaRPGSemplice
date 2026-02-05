using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prima_prova.Classi
{
    public class Board
    {
        public List<Personaggio> Personaggi { get; set; } = new List<Personaggio>();
        public Personaggio? Vincitore { get; set; } = null; 

        public Board()
        {

        }

        public Board(List<Personaggio> personaggi)
        {
            Personaggi = personaggi; 
        }

        public void InizializzaCombattimento()
        {
            Personaggi = Personaggi.OrderBy(x => x.Velocità).ToList(); 
        }

        public void CreaTestoScelta(Personaggio p)
        {
            string testo = "Scegli una mossa: \n";
            foreach (Mossa m in p.ListaMosse)
            {
                testo += $"{p.ListaMosse.IndexOf(m) + 1} - {m}\n";
            }
            testo += "Scelta: ";
            Console.Write(testo);
        }

        public int ScegliIdMossa(Personaggio p)
        {
            string? numero = Console.ReadLine();
            if (int.TryParse(numero, out int risultato)) 
            {
                return risultato - 1; 
            }
            return -1; 
        }
        public void ResetSchermo()
        {
            Console.Clear();
            Personaggi.ForEach(Console.WriteLine);
        }

        public void ScegliMossaPersonaggio(Personaggio p)
        {
            Mossa? scelta = null; 
            while(scelta == null)
            {
                ResetSchermo();
                CreaTestoScelta(p); 
                int idMossa = ScegliIdMossa(p);
                scelta = p.ListaMosse.FirstOrDefault(x => p.ListaMosse.IndexOf(x) == idMossa);
            }
            scelta.Attiva(this);
        }

        public void Combatti()
        {
            InizializzaCombattimento(); 

            while(Vincitore == null)
            {
                foreach (Personaggio p in Personaggi)
                {
                    ScegliMossaPersonaggio(p); 
                    Vincitore = Personaggi.FirstOrDefault(x => x.GetPuntiVita() == 0);
                    if(Vincitore != null)
                    {
                        break; 
                    }
                    Console.ReadLine();
                }
            }
            Console.WriteLine($"{Vincitore.Nome} ha vinto la partita!"); 
        }
    }
}
