using GearManagementProject;
using Microsoft.Win32;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace GearManagementProject
{
    class DataManager
    {
        #region Settings
        public string ConnectionString { get; set; }

        public DataManager(string connString)
        {
            ConnectionString = connString;
        }
        #endregion

        #region Execution
        private void ExecutionErrorHandler(MySql.Data.MySqlClient.MySqlCommand cmd)
        {
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region Display
        public ObservableCollection<Unit> ShowUnits()
        {
            ObservableCollection<Unit> ret = new ObservableCollection<Unit>();

            using (MySqlConnection conn = new MySqlConnection(ConnectionString))
            {
                conn.Open();
                string commandText = "SELECT * FROM Units";
                MySqlCommand cmd = new MySqlCommand(commandText, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ret.Add(new Unit(
                        reader[1].ToString(),
                        reader[3].ToString(),
                        reader[4].ToString(),
                        (UnitType)Convert.ToInt32(reader[5].ToString()),
                        Convert.ToInt32(reader[6].ToString()),
                        Convert.ToInt32(reader[7].ToString()),
                        Convert.ToInt32(reader[8].ToString()),
                        (FactoryType)Convert.ToInt32(reader[9].ToString()),
                        reader[10].ToString(),
                        (Side)Convert.ToInt32(reader[2].ToString())
                        ));
                }
                reader.Close();
            }

            return ret;
        }
        public ObservableCollection<Gear> ShowGear()
        {
            ObservableCollection<Gear> ret = new ObservableCollection<Gear>();
            using (MySqlConnection conn = new MySqlConnection(ConnectionString))
            {
                conn.Open();
                string commandText = "SELECT * FROM Gear";
                MySqlCommand cmd = new MySqlCommand(commandText, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ret.Add(new Gear(
                        reader[1].ToString(),
                        Convert.ToInt32(reader[3].ToString()),
                        Convert.ToInt32(reader[4].ToString()),
                        (Side)Convert.ToInt32(reader[2].ToString())
                        ));
                }
                reader.Close();
            }
            return ret;
        }
        #endregion

        #region Load
        internal void LoadGear(string filename, object side)
        {
            using (FileStream fs = new FileStream(filename, FileMode.Open))
            {
                String str;
                Gear g;
                StreamReader sr = new StreamReader(fs);
                List<String> myLines = new List<String>();
                while ((str = sr.ReadLine()) != null)
                {
                    if (!myLines.Contains(str))
                    {
                        myLines.Add(str);
                    }
                }
                foreach(String s in myLines) {
                    g = new Gear(s, 1, 10, (Side)side);
                    this.InsertGear(g);
                }
            }
        }

        internal void LoadUnit(string filename, object type, object side)
        {
            using (FileStream fs = new FileStream(filename, FileMode.Open))
            {
                String str;
                Unit u;
                StreamReader sr = new StreamReader(fs);
                List<String> myLines = new List<String>();
                while ((str = sr.ReadLine()) != null)
                {
                    if (!myLines.Contains(str))
                    {
                        myLines.Add(str);
                    }
                }
                foreach (String s in myLines)
                {
                    u = new Unit(s, "", "",(UnitType)type, 1000, 10, 1, (FactoryType)type, "", (Side)side);
                    this.InsertUnit(u);
                }
            }
        }

        #endregion

        #region Export
        public void Export()
        {
            ObservableCollection<Gear> gear = new ObservableCollection<Gear>();
            ObservableCollection<Unit> units = new ObservableCollection<Unit>();
            using (MySqlConnection conn = new MySqlConnection(ConnectionString))
            {
                conn.Open();
                string commandText = "SELECT * FROM Gear where SIDE = 0";
                MySqlCommand cmd = new MySqlCommand(commandText, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    gear.Add(new Gear(
                        reader[1].ToString(),
                        Convert.ToInt32(reader[2].ToString()),
                        Convert.ToInt32(reader[3].ToString()),
                        (Side)Convert.ToInt32(reader[4].ToString())
                        ));
                }
                reader.Close();
                commandText = "SELECT * FROM Units where SIDE = 0";
                cmd = new MySqlCommand(commandText, conn);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    units.Add(new Unit(
                        reader[1].ToString(),
                        reader[3].ToString(),
                        reader[4].ToString(),
                        (UnitType)Convert.ToInt32(reader[5].ToString()),
                        Convert.ToInt32(reader[6].ToString()),
                        Convert.ToInt32(reader[7].ToString()),
                        Convert.ToInt32(reader[8].ToString()),
                        (FactoryType)Convert.ToInt32(reader[9].ToString()),
                        reader[10].ToString(),
                        (Side)Convert.ToInt32(reader[2].ToString())
                        ));
                }
                reader.Close();
            }
                SaveFileDialog dlg = new SaveFileDialog();
                dlg.DefaultExt = ".txt";
                dlg.Filter = ".txt|*.txt";
                dlg.FileName = "West";
                if (Convert.ToBoolean(dlg.ShowDialog()))
                {
                    string filename = dlg.FileName;
                    StreamWriter sw = new StreamWriter(filename, false);
                    foreach (Gear g in gear)
                    {
                        sw.WriteLine("_i = _i  + [\"" + g.Classname + "\"];");
                        sw.WriteLine("_p = _p  + [" + g.Price + "];");
                        sw.WriteLine("_u = _u  + [" + g.UpgradeLevel + "];");
                        sw.WriteLine();
                    }
                    sw.WriteLine();
                    sw.WriteLine("------------------------------------------------");
                    sw.WriteLine("---------------------UNITS----------------------");
                    sw.WriteLine("------------------------------------------------");
                    sw.WriteLine();
                    
                    foreach (Unit u in units)
                    {
                        sw.WriteLine("_c = _c  + [\"" + u.Classname + "\"];");
                        sw.WriteLine("_p = _p  + [\"\"];");
                        sw.WriteLine("_n = _n  + [\"\"];");
                        sw.WriteLine("_o = _o  + [" + u.Price + "];");
                        sw.WriteLine("_t = _t  + [" + u.BuildTime + "];");
                        sw.WriteLine("_u = _u  + [" + u.UpgradeLevel + "];");
                        sw.WriteLine("_f = _f  + [" + u.Factory.ToString() + "];");
                        sw.WriteLine("_s = _s  + [\"\"];");
                        sw.WriteLine();
                    }
                    sw.Close();
                }
            }
        #endregion

        #region Insert
        public void InsertUnit(Unit u)
        {
            using (MySqlConnection conn = new MySqlConnection(this.ConnectionString))
            {
                conn.Open();
                string commandText = "INSERT INTO Units(CLASSNAME, IMAGE, NAME, TYPE, PRICE, BUILDTIME, UPGRADELEVEL, FACTORY, SCRIPT, SIDE) VALUES (?classname, ?image, ?name, ?type, ?price, ?buildtime, ?upgradelevel , ?factory, ?script, ?side)";
                MySqlCommand cmd = new MySqlCommand(commandText, conn);
                cmd.Parameters.AddWithValue("?classname", u.Classname);
                cmd.Parameters.AddWithValue("?image", u.Image);
                cmd.Parameters.AddWithValue("?name", u.Name);
                cmd.Parameters.AddWithValue("?type", u.Type);
                cmd.Parameters.AddWithValue("?price", u.Price);
                cmd.Parameters.AddWithValue("?buildtime", u.BuildTime);
                cmd.Parameters.AddWithValue("?upgradelevel", u.UpgradeLevel);
                cmd.Parameters.AddWithValue("?factory", u.Factory);
                cmd.Parameters.AddWithValue("?script", u.Script);
                cmd.Parameters.AddWithValue("?side", u.Side);
                ExecutionErrorHandler(cmd);
            }
        }

        public void InsertGear(Gear g)
        {
            using (MySqlConnection conn = new MySqlConnection(this.ConnectionString))
            {
                conn.Open();
                string commandText = "INSERT INTO Gear(CLASSNAME, UPGRADELEVEL, PRICE, SIDE) VALUES (?class, ?upgrade, ?price, ?side)";
                MySqlCommand cmd = new MySqlCommand(commandText, conn);
                cmd.Parameters.AddWithValue("?class", g.Classname);
                cmd.Parameters.AddWithValue("?upgrade", Convert.ToInt32(g.UpgradeLevel));
                cmd.Parameters.AddWithValue("?price", g.Price);
                cmd.Parameters.AddWithValue("?side", g.Side);
                ExecutionErrorHandler(cmd);
            }
        }

        public void InsertInBothTables(Gear g, Unit u)
        {
            InsertGear(g);
            InsertUnit(u);
        }
        #endregion

        #region Delete

        public void Delete(string tablename, string classname)
        {
            if (tablename == "Units")
            {
                using (MySqlConnection conn = new MySqlConnection(this.ConnectionString))
                {
                    conn.Open();
                    string commandText = "DELETE FROM Units WHERE classname = ?";
                    MySqlCommand cmd = new MySqlCommand(commandText, conn);
                    cmd.Parameters.AddWithValue("?", classname);
                    ExecutionErrorHandler(cmd);
                }
            }
            else
            {
                using (MySqlConnection conn = new MySqlConnection(this.ConnectionString))
                {
                    conn.Open();
                    string commandText = "DELETE FROM Gear WHERE classname = ?";
                    MySqlCommand cmd = new MySqlCommand(commandText, conn);
                    cmd.Parameters.AddWithValue("?", classname);
                    ExecutionErrorHandler(cmd);
                }
            }
        }
        #endregion

        #region Update
        public void UpdateUnit(Unit u)
        {
            using (MySqlConnection conn = new MySqlConnection(this.ConnectionString))
            {
                conn.Open();
                string commandText = "UPDATE Kunden SET CLASSNAME = ?, IMAGE = ?, NAME = ?, TYPE = ?, PRICE = ?, BUILDTIME = ?, UPGRADELEVEL = ?, FACTORY = ?, SCRIPT = ? WHERE id = ?";
                MySqlCommand cmd = new MySqlCommand(commandText, conn);
                cmd.Parameters.AddWithValue("?", u.Classname);
                cmd.Parameters.AddWithValue("?", u.Image);
                cmd.Parameters.AddWithValue("?", u.Name);
                cmd.Parameters.AddWithValue("?", u.Type);
                cmd.Parameters.AddWithValue("?", u.Price);
                cmd.Parameters.AddWithValue("?", u.BuildTime);
                cmd.Parameters.AddWithValue("?", u.UpgradeLevel);
                cmd.Parameters.AddWithValue("?", u.Factory);
                cmd.Parameters.AddWithValue("?", u.Script);
                ExecutionErrorHandler(cmd);
            }
        }

        public void UpdateGear(Gear g)
        {
            using (MySqlConnection conn = new MySqlConnection(this.ConnectionString))
            {
                conn.Open();
                string commandText = "UPDATE Geschaeftspartner SET CLASSNAME = ?, UPGRADELEVEL = ?, PRICE = ? WHERE id = ?";
                MySqlCommand cmd = new MySqlCommand(commandText, conn);
                cmd.Parameters.AddWithValue("?", g.Classname);
                cmd.Parameters.AddWithValue("?", g.UpgradeLevel);
                cmd.Parameters.AddWithValue("?", g.Price);
                ExecutionErrorHandler(cmd);
            }
        }
        #endregion
    }
}