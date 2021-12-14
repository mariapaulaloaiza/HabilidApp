using HabilidApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

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

        #region metodos

        public async Task LoadList()
        {
            this.ListViewSource = await App.Db.GetTableModel<ActividadesModel>();
        }

        public ActividadesViewModel()
        {
            LoadList();
        }


        

        #endregion

    }
}
