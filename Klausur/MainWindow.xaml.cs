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
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            TestBoote();
        }

        private void TestBoote()
        {
            Random random = new Random();
            List<Sportboot> boote = new List<Sportboot>();

            for (int i = 0; i < 15; i++)
            {
                int laenge = random.Next(5, 11); // Länge zwischen 5 und 10 Metern
                int gewicht = 275 * laenge - 1125; // Gewicht nach der Funktion g(x)=275*x-1125

                if (random.Next(2) == 0)
                {
                    // Motorboot
                    int motorleistung = random.Next(5, 21); // Motorleistung zwischen 5 und 20 kW
                    boote.Add(new Motorboot(laenge, gewicht, motorleistung));
                }
                else
                {
                    // Segelboot
                    int segelflaeche = random.Next(5, 21); // Segelfläche zwischen 5 und 20 m²
                    boote.Add(new Segelboot(laenge, gewicht, segelflaeche));
                }
            }

            List<Sportboot> fuehrerscheinfreieBoote = new List<Sportboot>();
            List<Sportboot> fuehrerscheinpflichtigeBoote = new List<Sportboot>();

            foreach (var boot in boote)
            {
                if (boot is Motorboot motorboot)
                {
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

            // Annahme: listBoxFuehrerscheinfrei und listBoxFuehrerscheinpflichtig sind ListBox-Elemente im XAML
            listBoxFuehrerscheinfrei.ItemsSource = fuehrerscheinfreieBoote;
            listBoxFuehrerscheinpflichtig.ItemsSource = fuehrerscheinpflichtigeBoote;
        }
    }
}