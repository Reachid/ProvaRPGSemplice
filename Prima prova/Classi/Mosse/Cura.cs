using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prima_prova.Classi.Mosse
{
    public class Cura : Mossa
    {
        public override string Nome { get; set; } = "Cura";
        public override int Costo { get; set; } = 20;
        public override int Potenza { get; set; } = 10;
        public Cura()
        {
        }

        public Cura(Personaggio u) : base(u)
        {
        }

        public override void Attiva(Board board)
        {
            if (!utilizzatore.CheckPuntiMana())
            {
                Console.WriteLine($"{utilizzatore.Nome} non ha abbastanza punti mana per lanciare {Nome}");
                return;
            }
            base.Cura(base.utilizzatore);
            base.ScalaCosto();
            base.StampaMossa();
        }
    }
}
