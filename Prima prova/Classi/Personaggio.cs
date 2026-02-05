using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prima_prova.Classi
{
    public class Personaggio
    {
        public string Nome { get; set; } = "";
        private int PuntiVita { get; set; } = 0;
        private int PuntiVitaMassimi { get; set; } = 0;
        private int PuntiMana { get; set; } = 0;
        private int PuntiManaMassimi { get; set; } = 0;
        private int Attacco { get; set; } = 0; 
        public int Difesa { get; set; } = 0;
        public int Velocità { get; set; } = 0;
        public List<Mossa> ListaMosse { get; set; } = new List<Mossa>();
        public Personaggio() { }
        public Personaggio(string nome, int puntiVita, int puntiMana, int attacco, int difesa)
        {
            Nome = nome;
            PuntiVita = puntiVita;
            PuntiVitaMassimi = puntiVita;
            PuntiMana = puntiMana;
            PuntiManaMassimi = puntiMana;
            Attacco = attacco;
            Difesa = difesa;
        }

        public Personaggio(string[] statistiche)
        {
            if (statistiche.Length < 5) return; 
            Nome = statistiche[0]; 
            PuntiVita = int.Parse(statistiche[1]);
            PuntiVitaMassimi = PuntiVita;
            PuntiMana = int.Parse(statistiche[2]);
            PuntiManaMassimi = PuntiMana;
            Attacco = int.Parse(statistiche[3]);
            Difesa = int.Parse(statistiche[4]); 
        }

        public void InitMosse(List<Mossa> listaMosse)
        {
            ListaMosse = listaMosse;
        }

        public int GetPuntiVita() => PuntiVita;
        public int GetPuntiMana() => PuntiMana;
        public int GetAttacco() => Attacco;
        public void SetPuntiVita(int nuovoValore)
        {
            PuntiVita = ClampaValore(PuntiVita, nuovoValore, 0, PuntiVitaMassimi);
        }

        public void SetPuntiMana(int nuovoValore)
        {
            PuntiMana = ClampaValore(PuntiMana, nuovoValore, 0, PuntiManaMassimi); 
        }

        public bool CheckPuntiMana()
        {
            return PuntiMana > 0; 
        }

        public void SetAttacco(int valore)
        {
            Attacco = valore;
        }

    

        public int ClampaValore(int valoreAttuale, int nuovoValore, int minimo, int massimo)
        {
            if (nuovoValore >= minimo && nuovoValore <= massimo)
            {
                valoreAttuale = nuovoValore;
            }
            else
            {
                if (nuovoValore < minimo) valoreAttuale = minimo;
                if (nuovoValore > massimo) valoreAttuale = massimo;
            }
            return valoreAttuale; 
        }

        public override string ToString()
        {
            string testo = $"{Nome}\n";
            testo += CreaTemplate("HP", PuntiVita);
            testo += CreaTemplate("MP", PuntiMana);
            testo += CreaTemplate("ATK", Attacco);
            testo += CreaTemplate("DEF", Difesa); 
            return testo; 
        }

        public string CreaTemplate(string nomeStat, int stat)
        {
            return $"- {nomeStat}:\t{stat}\n"; 
        }
    }
}
