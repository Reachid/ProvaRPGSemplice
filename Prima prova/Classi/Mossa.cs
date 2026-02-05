using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prima_prova.Classi
{
    public abstract class Mossa
    {
        public virtual string Nome { get; set; } = "";
        public virtual int Costo { get; set; } = 0; 
        public virtual int Potenza { get; set; } = 0;
        public Personaggio utilizzatore { get; set; } = new Personaggio();

        public Mossa() { }

        public Mossa(Personaggio u)
        {
            utilizzatore = u;
        }

        public abstract void Attiva(Board board); 

        public Personaggio? TrovaTarget(Board board)
        {
            return board.Personaggi.FirstOrDefault(x => x.Nome != utilizzatore.Nome); 
        }

        public void StampaMossa()
        {
            Console.WriteLine($"{utilizzatore.Nome} ha usato {Nome}!"); 
        }

        public void Danneggia(Personaggio target)
        {
            if (target.Difesa < Potenza + utilizzatore.GetAttacco())
            {
                target.SetPuntiVita(target.GetPuntiVita() - (this.Potenza - target.Difesa + utilizzatore.GetAttacco()));
            }
        }

        public void ScalaCosto()
        {
            utilizzatore.SetPuntiMana(utilizzatore.GetPuntiMana() - Costo); 
        }

        public void SetAttacco(Personaggio target)
        {
            target.SetAttacco(target.GetAttacco() + Potenza);
        }

        public void Cura(Personaggio target) 
        {
            target.SetPuntiVita(target.GetPuntiVita() + Potenza); 
        }

        public override string ToString()
        {
            return $"{Nome} [Potenza: {Potenza}, Costo: {Costo}MP]"; 
        }
    }
}
