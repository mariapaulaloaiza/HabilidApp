﻿using GalaSoft.MvvmLight.Command;
using HabilidApp.Models;
using HabilidApp.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace HabilidApp.ViewModel
{
    class HabilidadesViewModel:BaseViewModel
    {
        #region Atributos

        public int idHabilidad;

        public string NombreHabilidad;

        public int HorasInvertidas;

        public bool Terminado;

        public bool Notificacion;

        public TimeSpan HoraNotificacion;

        public object listViewSource;
        #endregion

        #region Propiedades
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
        public String NombreHabilidadEntry
        {
            get
            {
                return this.NombreHabilidad;
            }
            set
            {
                SetValue(ref this.NombreHabilidad, value);
            }
        }

        public int HorasInvertidasEntry
        {
            get
            {
                return this.HorasInvertidas;
            }
            set
            {
                SetValue(ref this.HorasInvertidas, value);
            }
        }

        public Boolean TerminadoEntry
        {
            get
            {
                return this.Terminado;
            }
            set
            {
                SetValue(ref this.Terminado, value);
            }
        }

        public bool NotificacionEntry
        {
            get
            {
                return this.Notificacion;
            }
            set
            {
                SetValue(ref this.Notificacion, value);
            }
        }

        public TimeSpan HoraNotificacionEntry
        {
            get
            {
                return this.HoraNotificacion;
            }
            set
            {
                SetValue(ref this.HoraNotificacion, value);
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

        public ICommand DeleteCommand
        {
            get
            {
                return new RelayCommand(DeleteHabilidadMethod);
            }
            set { }
        }



        #endregion


        #region Metodos

        public async Task LoadList()
        {
            this.ListViewSource = await App.Db.GetHabilidadesModel(false);
        }

        public async void UpdateHabilidadMethod()
        {
            var Habilidad = new HabilidadesModel();

            Habilidad.idHabilidad = idHabilidad;

            Habilidad.NombreHabilidad = NombreHabilidad;

            Habilidad.Notificacion = Notificacion;

            Habilidad.HoraNotificacion = HoraNotificacion;

            await App.Db.SaveModel<HabilidadesModel>(Habilidad, false);

            await Application.Current.MainPage.DisplayAlert("Editado exitoso", "Se guardaron los cambios", "Aceptar");

            await Application.Current.MainPage.Navigation.PushAsync(new Inicio(), true);

        }

        public async void SaveHabilidadMethod()
        {
            var Habilidad = new HabilidadesModel();

            Habilidad.NombreHabilidad = NombreHabilidad;

            Habilidad.HorasInvertidas = 0;

            Habilidad.Terminado = false;

            Habilidad.Notificacion = Notificacion;

            Habilidad.HoraNotificacion = HoraNotificacion;

            await App.Db.SaveModel<HabilidadesModel>(Habilidad,true);

            await Application.Current.MainPage.DisplayAlert("Registro exitoso", "Se guardaron los datos", "Aceptar");

            await Application.Current.MainPage.Navigation.PushAsync(new Inicio(), true);

        }

        public async void DeleteHabilidadMethod()
        {
            var Habilidad = new HabilidadesModel();

            Habilidad.idHabilidad = idHabilidad;

            Habilidad.NombreHabilidad = NombreHabilidad;

            Habilidad.HorasInvertidas = 0;

            Habilidad.Terminado = false;

            Habilidad.Notificacion = Notificacion;

            Habilidad.HoraNotificacion = HoraNotificacion;

            await App.Db.DeleteModelAsync<HabilidadesModel>(Habilidad);

            await Application.Current.MainPage.DisplayAlert("Eliminado exitoso", "Se elimino exitosamente", "Aceptar");

            await Application.Current.MainPage.Navigation.PushAsync(new Inicio(), true);
        }



        #endregion

        #region Constructor

        public HabilidadesViewModel()
        {
            LoadList();
        }

        public HabilidadesViewModel(HabilidadesModel item)
        {
            idHabilidadEntry = item.idHabilidad;

            NombreHabilidadEntry = item.NombreHabilidad;

            NotificacionEntry = item.Notificacion;

            HoraNotificacionEntry = item.HoraNotificacion;

            TerminadoEntry = item.Terminado;

        }

        #endregion
    }
}
