﻿using GalaSoft.MvvmLight.Command;
using HabilidApp.Models;
using HabilidApp.Views;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace HabilidApp.ViewModel
{
    class ActividadesViewModel:BaseViewModel
    {
        #region Atributos

        public int idActividad;

        public int idHabilidad;

        public string NombreActividad;

        public bool Terminada;

        public int duracion;

        public object listViewSource;

        #endregion

        #region Propiedades

        public int idActividadEntry
        {
            get
            {
                return this.idActividad;
            }
            set
            {
                SetValue(ref this.idActividad, value);
            }
        }
        public int idHabilidadEntry
        {
            get
            {
                return this.idHabilidad;
            }
            set
            {
                SetValue(ref this.idHabilidad, value);
            }
        }

        public string NombreActividadEntry
        {
            get
            {
                return this.NombreActividad;
            }
            set
            {
                SetValue(ref this.NombreActividad, value);
            }
        }

        public bool TerminadaEntry
        {
            get
            {
                return this.Terminada;
            }
            set
            {
                SetValue(ref this.Terminada, value);
            }
        }

        public int duracionEntry
        {
            get
            {
                return this.duracion;
            }
            set
            {
                SetValue(ref this.duracion, value);
            }
        }

        public object ListViewSource
        {
            get
            {
                return this.listViewSource;
            }
            set
            {
                SetValue(ref this.listViewSource, value);
            }
        }

        #endregion

        #region Comandos

        public ICommand UpdateCommand
        {
            get
            {
                return new RelayCommand(UpdateHabilidadMethod);
            }
            set { }
        }

        public ICommand SaveCommand
        {
            get
            {
                return new RelayCommand(SaveHabilidadMethod);
            }
            set { }
        }



        #endregion

        #region metodos

        public async Task LoadList()
        {
            this.ListViewSource = await App.Db.GetActividadesModel(idHabilidad);
        }

        public ActividadesViewModel(HabilidadesModel habilidad)
        {
            idHabilidadEntry = habilidad.idHabilidad;
            LoadList();
        }

        public ActividadesViewModel()
        {
            LoadList();
        }

        public async void UpdateHabilidadMethod()
        {
            var Actividad = new ActividadesModel();

            Actividad.idHabilidad = idHabilidad;

            Actividad.NombreActividad = NombreActividad;

            Actividad.Terminada = false;

            Actividad.duracion = duracion;

            await App.Db.SaveModel<ActividadesModel>(Actividad, false);

            await Application.Current.MainPage.DisplayAlert("Registro exitoso", "Se guardaron los cambios", "Aceptar");

            //await Application.Current.MainPage.Navigation.PushAsync(new Actividades(), true); 

        }


        public async void SaveHabilidadMethod()
        {
            var Actividad = new ActividadesModel();

            Actividad.idHabilidad = idHabilidad;

            Actividad.NombreActividad = NombreActividadEntry;

            Actividad.Terminada = false;

            Actividad.duracion = duracion;

            await App.Db.SaveModel<ActividadesModel>(Actividad, true);

            await Application.Current.MainPage.DisplayAlert("Registro exitoso", "Se guardaron los datos", "Aceptar");

            await Application.Current.MainPage.Navigation.PushAsync(new Actividades(), true);

           await PopupNavigation.Instance.PopAsync(true);

        }


        public ActividadesViewModel(ActividadesModel item, HabilidadesModel habilidad)
        {
            idHabilidadEntry = habilidad.idHabilidad;

            idActividadEntry = item.idActividad;

            NombreActividadEntry = item.NombreActividad;

            TerminadaEntry = item.Terminada;

            duracionEntry = item.duracion;

        }




        #endregion

    }
}
