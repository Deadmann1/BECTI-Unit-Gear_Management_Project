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
using Microsoft.VisualBasic;
using GearManagementProject;
using System.IO;

namespace GearManagementProject
{
    public partial class MainWindow : Window
    {
        DataManager dm;

        public MainWindow()
        {
            InitializeComponent();
            dm = new DataManager(AppSettings.ConnectionString);
        }
        private Boolean IsTableSelected()
        {
            return cboxTableName.Text.Length > 0;
        }
        private void ShowContent()
        {
            if (IsTableSelected())
            {
                if (cboxTableName.Text == "Units")
                    dataGrid.DataContext = dm.ShowUnits();
                else
                    dataGrid.DataContext = dm.ShowGear();
            }
        }
        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            ShowContent();
        }
        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            InsertWindow w1 = new InsertWindow(this);
            w1.Show();
            ShowContent();
        }
        public void InsertUnit(Object o)
        {
            dm.InsertUnit((Unit)o);
            ShowContent();
        }
        public void InsertGear(Object o)
        {
            dm.InsertGear((Gear)o);
            ShowContent();
        }
        public void UpdateGear(Object o)
        {
            dm.UpdateGear((Gear)o);
            ShowContent();
        }
        public void UpdateUnit(Object o)
        {
            dm.UpdateUnit((Unit)o);
            ShowContent();
        }
        public void LoadUnit(String filename, object type, object side)
        {
            dm.LoadUnit(filename, type, side);
            ShowContent();
        }
        public void LoadGear(String filename, object side)
        {
            dm.LoadGear(filename, side);
            ShowContent();
        }
        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            InsertWindow w1 = new InsertWindow(this);
            w1.Show();
        }
        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            LoadWindow w1 = new LoadWindow(this);
            w1.Show();
        }
        private void btnExport_Click(object sender, RoutedEventArgs e)
        {
            dm.Export();
        }
        private void DataGrid_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            var grid = (DataGrid)sender;
            if (Key.Delete == e.Key)
            {
                if (IsTableSelected())
                {
                    if (cboxTableName.Text == "Units")
                    {
                        foreach (Unit u in grid.SelectedItems)
                        {

                        }
                    }
                    else {
                        foreach (Gear g in grid.SelectedItems)
                        {
                            this.dm.Delete("Gear", g.Classname);
                        }
                    }
                }
            }
        }
    }
}