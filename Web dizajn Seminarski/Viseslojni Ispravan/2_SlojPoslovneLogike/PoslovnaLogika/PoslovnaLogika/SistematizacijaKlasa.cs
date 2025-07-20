using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PoslovnaLogika
{
    public class SistematizacijaKlasa
    {
        public int DajMaxMestaZaRadnoMesto(String IdZvanjeWSParametar)
        {
            WSKadrovskiPodaci.OgranicenjaZaposljavanja objOgranicenja = new WSKadrovskiPodaci.OgranicenjaZaposljavanja();
            int pomMaxBrojNastavnika = objOgranicenja.DajMaxBrojNastavnika(IdZvanjeWSParametar);
            return pomMaxBrojNastavnika;
        }

    }
}
