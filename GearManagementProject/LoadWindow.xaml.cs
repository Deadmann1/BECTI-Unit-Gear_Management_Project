using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GearManagementProject
{
    /// <summary>
    /// Interaction logic for LoadWindow.xaml
    /// </summary>
    public partial class LoadWindow : Window
    {
        private MainWindow mainWindow;
        public LoadWindow(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
        }

        private void rbGear_Checked(object sender, RoutedEventArgs e)
        {
            this.btnLoad.Visibility = Visibility.Visible;
            this.panelType.Visibility = Visibility.Hidden;
            this.InvalidateVisual();
        }

        private void rbUnit_Checked(object sender, RoutedEventArgs e)
        {
            this.btnLoad.Visibility = Visibility.Hidden;
            this.panelType.Visibility = Visibility.Visible;
            this.InvalidateVisual();
        }

        private void rbInfantry_Checked(object sender, RoutedEventArgs e)
        {
            this.btnLoad.Visibility = Visibility.Visible;
            this.InvalidateVisual();
        }

        private void rbLightVehicles_Checked(object sender, RoutedEventArgs e)
        {
            this.btnLoad.Visibility = Visibility.Visible;
            this.InvalidateVisual();
        }

        private void rbHeavyVehicles_Checked(object sender, RoutedEventArgs e)
        {
            this.btnLoad.Visibility = Visibility.Visible;
            this.InvalidateVisual();
        }

        private void rbRepairVehicles_Checked(object sender, RoutedEventArgs e)
        {
            this.btnLoad.Visibility = Visibility.Visible;
            this.InvalidateVisual();
        }

        private void rbAmmunitionVehicles_Checked(object sender, RoutedEventArgs e)
        {
            this.btnLoad.Visibility = Visibility.Visible;
            this.InvalidateVisual();
        }

        private void rbAirVehicles_Checked(object sender, RoutedEventArgs e)
        {
            this.btnLoad.Visibility = Visibility.Visible;
            this.InvalidateVisual();
        }

        private void rbNavalVehicles_Checked(object sender, RoutedEventArgs e)
        {
            this.btnLoad.Visibility = Visibility.Visible;
            this.InvalidateVisual();
        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            Side side;
            // Create OpenFileDialog
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            // Set filter for file extension and default file extension
            dlg.DefaultExt = ".txt";
            dlg.Filter = "Text documents (.txt)|*.txt";
            // Display OpenFileDialog by calling ShowDialog method
            Nullable<bool> result = dlg.ShowDialog();
            if (Convert.ToBoolean(rbBlufor.IsChecked))
                side = Side.BLUFOR;
            else
                side = Side.OPFOR;
            //Realtive Path to Users Data
            if (result == true)
            {

                if (Convert.ToBoolean(rbGear.IsChecked))
                {
                    this.mainWindow.LoadGear(dlg.FileName, side);
                }
                else
                {
                    UnitType retType;
                    if(Convert.ToBoolean(rbInfantry.IsChecked))
                    {
                        retType = UnitType.Infantry;
                    }
                    else if (Convert.ToBoolean(rbLightVehicles.IsChecked))
                    {
                        retType = UnitType.Light_Vehicles;
                    }
                    else if (Convert.ToBoolean(rbHeavyVehicles.IsChecked))
                    {
                        retType = UnitType.Heavy_Vehicles;
                    }
                    else if (Convert.ToBoolean(rbRepairVehicles.IsChecked))
                    {
                        retType = UnitType.Repair_Vehicles;
                    }
                    else if (Convert.ToBoolean(rbAmmunitionVehicles.IsChecked))
                    {
                        retType = UnitType.Ammunition_Vehicles;
                    }
                    else if (Convert.ToBoolean(rbAirVehicles.IsChecked))
                    {
                        retType = UnitType.Air_Vehicles;
                    }
                    else
                    {
                        retType = UnitType.Naval_Vehicles;
                    }
                    this.mainWindow.LoadUnit(dlg.FileName, retType, side);
                }
                MessageBox.Show("Finished loading!");
                this.Close();
            }
        }
    }
}
