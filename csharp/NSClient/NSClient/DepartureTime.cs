using System;

namespace NSClient
{
    internal class DepartureTime
    {
        public string EindBestemming { get; set; }
        public string Ritnummer { get; set; }
        public string Routetekst { get; set; }
        public string Treinsoort { get; set; }
        public string VertrekSpoor { get; set; }
        public bool VertrekSpoorWijziging { get; set; }
        public DateTime Vertrektijd { get; set; }
        public string VertrekVertragingsTekst { get; set; }


        public override string ToString()
        {
            return EindBestemming;
        }
    }
}