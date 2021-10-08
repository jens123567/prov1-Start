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
        // Gästboksfilen
        string filen = "./kontakter.tsv";

        // Kontaktlistan
        List<string> kontaktLista = new List<string>();

        public MainWindow()
        {
            InitializeComponent();

            // Lägg fokus i första inmatningsrutan
            rutaNamn.Focus();

        }


    }
}