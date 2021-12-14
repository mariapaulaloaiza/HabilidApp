using HabilidApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using HabilidApp.Views.PopUp;
using HabilidApp.Models;

namespace HabilidApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ActividadXhabilidad : ContentPage
    {
        public HabilidadesModel habilidad;

        public ActividadXhabilidad()
        {
            InitializeComponent();
           

        }
        public ActividadXhabilidad(HabilidadesModel item)
        {
            InitializeComponent();
            habilidad = item;
            BindingContext = new ActividadesViewModel(habilidad);


        }

        private void ListItemSelected(object sender, SelectedItemChangedEventArgs e)
        {   
            PopupNavigation.Instance.PushAsync(new PopUpUpdateActividad(e.SelectedItem as ActividadesModel, habilidad));
        }

        private void Nueva_Clicked(object sender, EventArgs e)
        {
            PopupNavigation.Instance.PushAsync(new PopUpCreateActividad(habilidad));
        }
    }
}