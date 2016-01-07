using GearManagementProject;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Shapes;
using System.Windows.Threading;

namespace GearManagementProject
{
    /// <summary>
    /// Interaction logic for InsertWindow.xaml
    /// </summary>
    public partial class InsertWindow : Window
    {
        MainWindow w1;
        public InsertWindow(MainWindow _w1)
        {
            InitializeComponent();
            w1 = _w1;
        }
        private void ComboBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (this.gridGear != null && this.gridUnit != null)
            {
                if (this.comboBox.SelectedItem.ToString().Contains("Unit"))
                {
                    this.gridUnit.Visibility = Visibility.Visible;
                    this.gridGear.Visibility = Visibility.Hidden;
                    this.InvalidateVisual();
                }
                else if (this.comboBox.SelectedItem.ToString().Contains("Gear"))
                {
                    this.gridUnit.Visibility = Visibility.Hidden;
                    this.gridGear.Visibility = Visibility.Visible;
                    this.InvalidateVisual();
                }
            }
        }

        private void btnCancle_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (this.comboBox.SelectedItem.ToString().Contains("Kunde"))
            {
                if (txtBoxID.Text.Length != 0 && txtBoxName.Text.Length != 0 && txtBoxAdresse.Text.Length != 0)
                {
                    //Unit u= new Unit(Convert.ToInt32(txtBoxID.Text), Convert.ToInt32(txtBoxJahresumsatz.Text), Convert.ToInt32(txtBoxKredit.Text), txtBoxBedingungen.Text);
                    //w1.UpdateKunde(k);
                }
                else
                {
                    MessageBox.Show("Missing values!");
                }
            }
            else
            {
                if (txtBoxID.Text.Length != 0 && txtBoxName.Text.Length != 0 && txtBoxAdresse.Text.Length != 0)
                {
                    //Gear g = new Gear(Convert.ToInt32(txtBoxID.Text), txtBoxName.Text, txtBoxAdresse.Text);
                   // w1.UpdateGeschäftspartner(g);
                }
                else
                {
                    MessageBox.Show("Missing values!");
                }
            }
        }
        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {          
                if (this.comboBox.SelectedItem.ToString().Contains("Kunde"))
                {
                    if (txtBoxID.Text.Length != 0 && txtBoxJahresumsatz.Text.Length != 0 && txtBoxKredit.Text.Length != 0 && txtBoxBedingungen.Text.Length != 0)
                    {
                       // Kunde k = new Kunde(Convert.ToInt32(txtBoxID.Text), Convert.ToInt32(txtBoxJahresumsatz.Text), Convert.ToInt32(txtBoxKredit.Text), txtBoxBedingungen.Text);
                       // w1.InsertCustomer(k);

                    }
                    else
                    {
                        MessageBox.Show("Missing values!");
                    }
                }
                else
                {
                    if (txtBoxID.Text.Length != 0 && txtBoxName.Text.Length != 0 && txtBoxAdresse.Text.Length != 0)
                    {
                        //Geschaeftspartner g = new Geschaeftspartner(Convert.ToInt32(txtBoxID.Text), txtBoxName.Text, txtBoxAdresse.Text);
                        //w1.InsertGeschäftspartner(g);
                    }
                    else
                    {
                        MessageBox.Show("Missing values!");
                    }
                }
            this.Close();
        }
    }
}
