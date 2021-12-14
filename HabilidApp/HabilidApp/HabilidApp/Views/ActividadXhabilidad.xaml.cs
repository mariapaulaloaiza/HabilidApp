using HabilidApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HabilidApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ActividadXhabilidad : ContentPage
    {
        public ActividadXhabilidad()
        {
            InitializeComponent();
            BindingContext = new ActividadesViewModel();

        }
    }
}