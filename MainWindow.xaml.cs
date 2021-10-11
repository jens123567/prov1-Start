using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Text.RegularExpressions;

namespace Prov1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Filens namn
        string filen = "./kontakter.tsv";

        // Kontaktlistan
        List<string> kontaktLista = new List<string>();


        public MainWindow()
        {
            InitializeComponent();

            //körs bara om filen redan finns
            if (File.Exists(filen))
            {
                // Läs in alla rader ur filen
                kontaktLista = System.IO.File.ReadLines(filen).ToList();

                //skriv ut varje namn+telnummer på varsinn rad
                foreach (var item in kontaktLista)
                {
                    rutaAllaKontakter.Text += $"{item}\n";

                }

            }

            // Lägg fokus i första inmatningsrutan
            rutaNamn.Focus();

        }

        /// <summary>
        /// körs när användaren klickar
        /// </summary>
        private void ClickSpara(object sender, RoutedEventArgs e)
        {
            //definiera variabler
            string namn = rutaNamn.Text;
            string nummer = rutaMobil.Text;
            string kontaktInfo = $"{namn}\t{nummer}";

            //kontrollera så att namn inte är tomt
            if (namn != "")
            {
                //kontrollera så att nummret är korrekt format
                Regex rx = new Regex(@"^\(?([0-9]{3})\)?[-]([0-9]{7})$");
                if (rx.IsMatch(nummer))
                {
                    //kolla så att kontakten inte redan finns
                    if (kontaktLista.Contains(kontaktInfo))
                    {
                        rutaStatus.Text = "kontakten finns redan";
                    }
                    else
                    {
                        rutaStatus.Text = "inga fel";
                        //lägg till kontakten i listan 
                        kontaktLista.Add(kontaktInfo);
                        //visa  kontakten på skärmen
                        rutaAllaKontakter.Text += $"{kontaktInfo}\n";

                        //spara listan i filen
                        File.WriteAllLines(filen, kontaktLista);
                    }

                }
                else
                {
                    rutaStatus.Text = "fel format på nummer, korrekt format xxx-xxxxxxx";
                }
            }
            else
            {
                rutaStatus.Text = "namn kan ej vara tomt";

            }


        }


    }
}