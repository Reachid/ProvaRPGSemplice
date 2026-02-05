using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prima_prova.Classi.Mosse;

namespace Prima_prova.Classi
{
    public static class MoveFactory
    {
        public static List<Mossa> CreaMosse(Personaggio p, string NomiMosse)
        {
            List<Mossa> mosse = new List<Mossa>();
            string[] mosseSplit = NomiMosse.Split(",");
            foreach(string mossa in mosseSplit)
            {
                Mossa? presa = PrendiMossaDaStringa(p, mossa.Trim());
                if (presa != null)
                {
                    mosse.Add(presa);
                }
            }
            return mosse; 
        }

        private static Mossa? PrendiMossaDaStringa(Personaggio p, string nomeMossa)
        {
            Mossa mossa;
            switch (nomeMossa.ToLower())
            {
                case "morso":
                    mossa = new Morso(p); 
                    break;
                case "provocazione": 
                    mossa = new Provocazione(p);
                    break;
                case "cura": 
                    mossa = new Cura(p);
                    break;
                default: return null; 
            }
            return mossa; 
        }
    }
}
