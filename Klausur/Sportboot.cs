using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Klausur
{
    internal class Sportboot
    {
        private readonly int laenge;
        private readonly int gewicht;

        public int Laenge
        {
            get { return laenge; }
        }

        public double LaengeInFuss
        {
            get { return laenge / 0.3048; }
        }

        public int Gewicht
        {
            get { return gewicht; }
        }

        public Sportboot(int laenge, int gewicht)
        {
            if (laenge < 5 || laenge > 10)
            {
                throw new ArgumentOutOfRangeException("laenge", "Die Bootslänge muss zwischen 5m und 10m liegen.");
            }
            this.laenge = laenge;
            this.gewicht = gewicht;
        }

        public override string ToString()
        {
            return $"Die Länge des Sportbootes beträgt {laenge} Meter ({LaengeInFuss:F2} Fuß) und das Gewicht beträgt {gewicht} kg.";
        }
    }
    internal class Motorboot : Sportboot
    {
        private readonly int motorleistung;

        public int Motorleistung
        {
            get { return motorleistung; }
        }

        public bool Fuehrerscheinpflichtig
        {
            get { return motorleistung > 11; }
        }

        public Motorboot(int laenge, int gewicht, int motorleistung) : base(laenge, gewicht)
        {
            this.motorleistung = motorleistung;
        }

        public override string ToString()
        {
            return $"Das Motorboot hat eine Länge von {Laenge} Meter ({LaengeInFuss:F2} Fuß), ein Gewicht von {Gewicht} kg und eine Motorleistung von {Motorleistung} kW. Führerscheinpflichtig: {Fuehrerscheinpflichtig}";
        }
    }

    internal class Segelboot : Sportboot
    {
        private readonly int segelflaeche;
        public int Segelflaeche
        {
            get { return segelflaeche; }
        }

        public bool Fuehrerscheinpflichtig
        {
            get { return segelflaeche > 12; }
        }

        public Segelboot(int laenge, int gewicht, int segelflaeche) : base(laenge, gewicht)
        {
            this.segelflaeche = segelflaeche;
        }

        public override string ToString()
        {
            return $"Das Motorboot hat eine Länge von {Laenge} Meter ({LaengeInFuss:F2} Fuß), ein Gewicht von {Gewicht} kg und eine Segelfläche von {Segelflaeche} M. Führerscheinpflichtig: {Fuehrerscheinpflichtig}";
        }
    }
}
