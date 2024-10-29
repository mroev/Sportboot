using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Klausur
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent(); // Initialisiert die grafische Oberfläche des Fensters
        }

        // Event-Handler für den Button-Klick "StartAusgabe"
        private void btnStartAusgabe_Click(object sender, RoutedEventArgs e)
        {
            TestBoote(); // Startet die Methode, die Boote erstellt und nach Führerscheinpflicht sortiert
        }

        // Methode zur Erstellung und Verwaltung von Booten
        private void TestBoote()
        {
            Random random = new Random();
            List<Sportboot> boote = new List<Sportboot>(); // Liste, die alle Boote speichert

            // Erstellen von 15 Sportbooten mit zufälligen Eigenschaften
            for (int i = 0; i < 15; i++)
            {
                int laenge = random.Next(5, 11); // Länge des Boots zwischen 5 und 10 Metern
                int gewicht = 275 * laenge - 1125; // Gewicht basierend auf der Funktion g(x)=275*x-1125

                if (random.Next(2) == 0)
                {
                    // Erstellen eines Motorboots mit zufälliger Motorleistung
                    int motorleistung = random.Next(5, 21); // Motorleistung zwischen 5 und 20 kW
                    boote.Add(new Motorboot(laenge, gewicht, motorleistung));
                }
                else
                {
                    // Erstellen eines Segelboots mit zufälliger Segelfläche
                    int segelflaeche = random.Next(5, 21); // Segelfläche zwischen 5 und 20 m²
                    boote.Add(new Segelboot(laenge, gewicht, segelflaeche));
                }
            }

            // Zwei Listen für führerscheinpflichtige und führerscheinfreie Boote
            List<Sportboot> fuehrerscheinfreieBoote = new List<Sportboot>();
            List<Sportboot> fuehrerscheinpflichtigeBoote = new List<Sportboot>();

            // Sortieren der Boote nach Führerscheinpflicht
            foreach (var boot in boote)
            {
                if (boot is Motorboot motorboot)
                {
                    // Führerscheinpflicht abhängig von Motorleistung
                    if (motorboot.Fuehrerscheinpflichtig)
                    {
                        fuehrerscheinpflichtigeBoote.Add(motorboot);
                    }
                    else
                    {
                        fuehrerscheinfreieBoote.Add(motorboot);
                    }
                }
                else if (boot is Segelboot segelboot)
                {
                    // Führerscheinpflicht abhängig von Segelfläche
                    if (segelboot.Fuehrerscheinpflichtig)
                    {
                        fuehrerscheinpflichtigeBoote.Add(segelboot);
                    }
                    else
                    {
                        fuehrerscheinfreieBoote.Add(segelboot);
                    }
                }
            }

            // Überprüfung, ob die Checkbox für führerscheinpflichtige Boote aktiviert ist
            if (checkBoxFuehrerscheinpflichtig.IsChecked == true)
            {
                // Anzeige nur der führerscheinpflichtigen Boote
                listBoxFuehrerscheinfrei.ItemsSource = null;
                listBoxFuehrerscheinpflichtig.ItemsSource = fuehrerscheinpflichtigeBoote;
            }
            else
            {
                // Anzeige beider Listen: führerscheinfreie und führerscheinpflichtige Boote
                listBoxFuehrerscheinfrei.ItemsSource = fuehrerscheinfreieBoote;
                listBoxFuehrerscheinpflichtig.ItemsSource = fuehrerscheinpflichtigeBoote;
            }
        }
    }
}