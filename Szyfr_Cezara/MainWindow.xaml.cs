using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace Szyfr_Cezara
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        char[] alfabet = new char[32] { 'a', 'ą', 'b', 'c', 'ć', 'd', 'e', 'ę', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'ł', 'm', 'n', 'ń', 'o', 'ó', 'p', 'r', 's', 'ś', 't', 'u', 'w', 'y', 'z', 'ź', 'ż', };

        private void szyfruj(object sender, RoutedEventArgs e)
        {
            int przesuniecie = 0;
            char znak = '0';
            if (Int32.Parse(TxtBoxPrzesuniecie.Text) > 31)
                TxtBoxPrzesuniecie.Text = "31";

            if (Int32.Parse(TxtBoxPrzesuniecie.Text) != 0)
            {
                    TxtBoxSzyf.Text = "";
                    foreach (char c in TxtBoxNieszyf.Text)
                    {
                        znak = c;

                        if (Char.IsLetter(znak))
                        {
                            przesuniecie = Array.IndexOf(alfabet, znak) + int.Parse(TxtBoxPrzesuniecie.Text);

                            if (przesuniecie >= 32)
                                przesuniecie = przesuniecie - 32;

                            TxtBoxSzyf.Text += alfabet[przesuniecie];
                        }
                        else
                        {
                            TxtBoxSzyf.Text += znak;
                        }
                    }                
            }
            else
            {
                TxtBoxSzyf.Text = TxtBoxNieszyf.Text;
            }
        }

        private void TxtBoxPrzesuniecie_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(TxtBoxPrzesuniecie.Text, "[^0-9]"))
            {
                TxtBoxPrzesuniecie.Text = TxtBoxPrzesuniecie.Text.Remove(TxtBoxPrzesuniecie.Text.Length - 1);
            }
        }

        private void deszyfruj(object sender, RoutedEventArgs e)
        {
            int przesuniecie = 0;
            char znak = '0';
            if (Int32.Parse(TxtBoxPrzesuniecie.Text) > 31)
                TxtBoxPrzesuniecie.Text = "31";

            if (Int32.Parse(TxtBoxPrzesuniecie.Text) != 0)
            {
                    TxtBoxNieszyf_Copy.Text = "";
                    foreach (char c in TxtBoxSzyf_Copy.Text)
                    {
                        znak = c;

                        if (Char.IsLetter(znak))
                        {
                            przesuniecie = Array.IndexOf(alfabet, znak) - int.Parse(TxtBoxPrzesuniecie.Text);

                            if (przesuniecie < 0)
                                przesuniecie = przesuniecie + 32;
                            if (przesuniecie == 0)
                            przesuniecie = 0;

                        TxtBoxNieszyf_Copy.Text += alfabet[przesuniecie];
                        }
                        else
                        {
                            TxtBoxNieszyf_Copy.Text += znak;
                        }
                    }         
            }
            else
            {
                TxtBoxNieszyf_Copy.Text = TxtBoxSzyf_Copy.Text;
            }
        }
    }
}
