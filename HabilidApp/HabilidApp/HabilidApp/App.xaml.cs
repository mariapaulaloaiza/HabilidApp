using HabilidApp.DataBase;
using HabilidApp.Views;
using HabilidApp.Models;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.Generic;

namespace HabilidApp
{
    public partial class App : Application
    {
        static DataBaseQuery database;
        public static DataBaseQuery Db
        {
            get
            {
                if (database == null)
                {
                    database = new DataBaseQuery(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "DBHabilidApp.db"));
                }
                return database;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Login()) {

                BarBackgroundColor = Color.FromHex("#beaee2")
            };
        }

        protected override void OnStart()
        {
            ActividadesModel actividad = new ActividadesModel();
            actividad.idHabilidad = 1;
            actividad.NombreActividad = "Hacer un formulario";
            actividad.Terminada = false;
            actividad.duracion = 1;
            var result = Db.SaveModel<ActividadesModel>(actividad, true);
           
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
