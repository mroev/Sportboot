using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Klausur
{
    // Basisklasse für Sportboote
    internal class Sportboot
    {
        // Felder für die Länge und das Gewicht des Boots (nur lesbar)
        private readonly int laenge;
        private readonly int gewicht;

        // Eigenschaft für die Länge des Boots in Metern
        public int Laenge
        {
            get { return laenge; }
        }

        // Eigenschaft für die Länge des Boots in Fuß (umgerechnet von Metern)
        public double LaengeInFuss
        {
            get { return laenge / 0.3048; } // 1 Meter = 0.3048 Fuß
        }

        // Eigenschaft für das Gewicht des Boots
        public int Gewicht
        {
            get { return gewicht; }
        }

        // Konstruktor, der die Länge und das Gewicht setzt und die Längenbeschränkung prüft
        public Sportboot(int laenge, int gewicht)
        {
            // Prüfung der Länge (zwischen 5 und 10 Metern)
            if (laenge < 5 || laenge > 10)
            {
                throw new ArgumentOutOfRangeException("laenge", "Die Bootslänge muss zwischen 5m und 10m liegen.");
            }
            this.laenge = laenge;
            this.gewicht = gewicht;
        }

        // Überschreibt die ToString-Methode für eine formatierte Ausgabe
        public override string ToString()
        {
            return $"Die Länge des Sportbootes beträgt {laenge} Meter ({LaengeInFuss:F2} Fuß) und das Gewicht beträgt {gewicht} kg.";
        }
    }

    // Abgeleitete Klasse Motorboot mit zusätzlicher Eigenschaft Motorleistung
    internal class Motorboot : Sportboot
    {
        // Nur lesbares Feld für die Motorleistung
        private readonly int motorleistung;

        // Eigenschaft für die Motorleistung
        public int Motorleistung
        {
            get { return motorleistung; }
        }

        // Bestimmt, ob das Motorboot führerscheinpflichtig ist (Motorleistung über 11 kW)
        public bool Fuehrerscheinpflichtig
        {
            get { return motorleistung > 11; }
        }

        // Konstruktor für Motorboot, setzt Länge, Gewicht und Motorleistung
        public Motorboot(int laenge, int gewicht, int motorleistung) : base(laenge, gewicht)
        {
            this.motorleistung = motorleistung;
        }

        // Überschreibt ToString für eine detaillierte Ausgabe mit Führerscheinpflicht-Status
        public override string ToString()
        {
            return $"Das Motorboot hat eine Länge von {Laenge} Meter ({LaengeInFuss:F2} Fuß), ein Gewicht von {Gewicht} kg und eine Motorleistung von {Motorleistung} kW. Führerscheinpflichtig: {Fuehrerscheinpflichtig}";
        }
    }

    // Abgeleitete Klasse Segelboot mit zusätzlicher Eigenschaft Segelfläche
    internal class Segelboot : Sportboot
    {
        // Nur lesbares Feld für die Segelfläche
        private readonly int segelflaeche;

        // Eigenschaft für die Segelfläche
        public int Segelflaeche
        {
            get { return segelflaeche; }
        }

        // Bestimmt, ob das Segelboot führerscheinpflichtig ist (Segelfläche über 12 m²)
        public bool Fuehrerscheinpflichtig
        {
            get { return segelflaeche > 12; }
        }

        // Konstruktor für Segelboot, setzt Länge, Gewicht und Segelfläche
        public Segelboot(int laenge, int gewicht, int segelflaeche) : base(laenge, gewicht)
        {
            this.segelflaeche = segelflaeche;
        }

        // Überschreibt ToString für eine detaillierte Ausgabe mit Führerscheinpflicht-Status
        public override string ToString()
        {
            return $"Das Segelboot hat eine Länge von {Laenge} Meter ({LaengeInFuss:F2} Fuß), ein Gewicht von {Gewicht} kg und eine Segelfläche von {Segelflaeche} m². Führerscheinpflichtig: {Fuehrerscheinpflichtig}";
        }
    }
}