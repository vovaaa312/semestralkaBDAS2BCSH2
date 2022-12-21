﻿using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using VetClinic.Model;

namespace VetClinic.ViewModel
{
    internal class VeterinariVysledkyPohledViewModel
    {
        public VeterinariVysledkyPohledViewModel() {
            LoadVeterinariVysledky();
        }

        public ObservableCollection<VeterinariVysledkyPohled> VeterinariVysledky
        {
            get;
            set;
        }

        private void LoadVeterinariVysledky()
        {
            ObservableCollection<VeterinariVysledkyPohled> veterinariVysledky = new ObservableCollection<VeterinariVysledkyPohled>();

            string constr = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=fei-sql1.upceucebny.cz)(PORT=1521)))(CONNECT_DATA=(SID=IDAS)));" +
                        "user id=st64150;password=vova0107;" +
                        "Connection Timeout=120;Validate connection=true;Min Pool Size=4;";

            OracleConnection con = new OracleConnection(constr);
            con.Open();
            MessageBox.Show("Connected to Oracle Database From Tab3", con.ServerVersion);



            OracleCommand getView = new OracleCommand();
            getView.Connection = con;
            getView.CommandText = "SELECT JMENO_MAZLICEK, JEHOTOVY, JEPLANOVANA, DATUM_ZACATKU, DATUM_UKONCENI, GLUKOZA, BILKOVINY, MOCOVINA, BILIRUBIN, RBC, HGB, HCT" +
                " FROM VETERINARI_VYSLEDKY_VIEW";
            OracleDataReader readerView = getView.ExecuteReader();

            if (readerView.HasRows) {
                while (readerView.Read()) {
                    veterinariVysledky.Add(new VeterinariVysledkyPohled { 
                        Jmeno_mazlicek = readerView["JMENO_MAZLICEK"].ToString(),
                        JeHotovy = Boolean.Parse(readerView["JEHOTOVY"].ToString()), 
                        JePlanovany = Boolean.Parse(readerView["JEPLANOVANA"].ToString()),
                        Datum_zacatku = readerView["DATUM_ZACATKU"].ToString(),
                        Datum_ukonceni = readerView["DATUM_UKONCENI"].ToString(),
                        Glukoza = int.Parse(readerView["GLUKOZA"].ToString()),
                        Bilkovina = int.Parse(readerView["BILKOVINY"].ToString()),
                        Mocovina = int.Parse(readerView["MOCOVINA"].ToString()),
                        Bilirubin = int.Parse(readerView["BILIRUBIN"].ToString()),
                        RBC = int.Parse(readerView["RBC"].ToString()),
                        HCT = int.Parse(readerView["HGB"].ToString()),
                        HGB = int.Parse(readerView["HCT"].ToString())
                    });
                    VeterinariVysledky = veterinariVysledky;
                }
            }
            con.Close();
        }
    }
}
