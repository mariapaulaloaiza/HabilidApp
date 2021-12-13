using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using HabilidApp.Models;
using HabilidApp.Views;

namespace HabilidApp.ViewModel
{
    class LoginViewModel:BaseViewModel
    {
        #region Atributos

        public string Correo;

        public string Clave;

        #endregion

        #region Propiedades

        public String CorreoEntry 
        {
            get
            {
                return this.Correo;
            }
            set
            {
                SetValue(ref this.Correo, value);
            } 
        }

        public String ClaveEntry
        {
            get
            {
                return this.Clave;
            }
            set
            {
                SetValue(ref this.Clave, value);
            }
        }

        #endregion

        #region Comandos

        public ICommand LoginCommand
        {
            get
            {
                return new RelayCommand(LoginMethod);
            }
            set { }
        }
        #endregion

        #region Metodos

        public async void LoginMethod()
        {
            List<UserModel> ListUser = App.Db.ValidateUserModel(Correo, Clave).Result;

            UserModel user = App.Db.GetUserModel(Correo, Clave).Result;

            //if(user==null)
            //{

            //}
            //else
            //{

            //}

            if(ListUser.Count >0)
            {
                await Application.Current.MainPage.DisplayAlert("Bienvenido", "app", "OK");

                await Application.Current.MainPage.Navigation.PushAsync(new Inicio());
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Error", "app", "OK");

            }
        }
        #endregion


    }
}
