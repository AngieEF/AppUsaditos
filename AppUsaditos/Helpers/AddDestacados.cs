using AppUsaditos.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace AppUsaditos.Helpers
{
    public class AddDestacados
    {
        public ObservableCollection<Destacados> destacados { get; set; }
        public AddDestacados()
        {
            destacados = new ObservableCollection<Destacados>
            {
                new Destacados
                {
                    Imagendes = "favorito.png"
                }
            };
        }
    }
}

