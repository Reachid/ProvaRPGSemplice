using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prima_prova.Classi.Mosse
{
    public class Morso : Mossa
    {
        public override string Nome { get; set; } = "Morso";
        public override int Costo { get; set; } = 10;
        public override int Potenza { get; set; } = 40; 
        public Morso(Personaggio utilizzatore) : base(utilizzatore) { }

        public override void Attiva(Board board)
        {
            Personaggio? target = base.TrovaTarget(board);
            if (target == null)
            {
                Console.WriteLine($"Non esiste alcun giocatore a cui lanciare {Nome}");
                return; 
            }

            if (!utilizzatore.CheckPuntiMana())
            {
                Console.WriteLine($"{utilizzatore.Nome} non ha abbastanza punti mana per lanciare {Nome}");
                return; 
            }

            base.Danneggia(target);
            base.ScalaCosto();
            base.StampaMossa();
        }
    }
}
