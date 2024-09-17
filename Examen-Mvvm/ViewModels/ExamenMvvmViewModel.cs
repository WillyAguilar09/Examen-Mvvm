using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.ComponentModel;

namespace Examen_Mvvm.ViewModels
{
    public partial class ExamenMvvmViewModel : ObservableObject
    {
        [ObservableProperty]
        private decimal producto1;

        [ObservableProperty]
        private decimal producto2;

        [ObservableProperty]
        private decimal producto3;

        [ObservableProperty]
        private decimal subtotal;

        [ObservableProperty]
        private decimal descuento;

        [ObservableProperty]
        private decimal total;

        private void Alerta(string Titulo, string Mensaje)
        {
            MainThread.BeginInvokeOnMainThread(async () => await App.Current!.MainPage!.DisplayAlert(Titulo, Mensaje, "Aceptar"));
        }
        public ExamenMvvmViewModel()
        {
            CalcularCommand = new RelayCommand(CalcularTotal);
            LimpiarCommand = new RelayCommand(LimpiarCampos);
        }

        public IRelayCommand CalcularCommand { get; }
        public IRelayCommand LimpiarCommand { get; }

        private void CalcularTotal()
        {
            // Validar que los productos no sean menores o iguales a 0
            if (Producto1 <= 0 || Producto2 <= 0 || Producto3 <= 0)
            {
                Alerta("Advertencia", "El valor de Producto1, Producto2 o Producto3 no puede ser menor o igual a 0");
                return; // Detener la ejecución si hay valores inválidos
            }

            // Calcular el subtotal
            Subtotal = Producto1 + Producto2 + Producto3;

            // Calcular el descuento basado en el subtotal
            if (Subtotal >= 0 && Subtotal < 1000)
            {
                Descuento = 0;
            }
            else if (Subtotal >= 1000 && Subtotal < 5000)
            {
                Descuento = 0.10m * Subtotal;
            }
            else if (Subtotal >= 5000 && Subtotal < 10000)
            {
                Descuento = 0.20m * Subtotal;
            }
            else if (Subtotal >= 10000)
            {
                Descuento = 0.30m * Subtotal;
            }

            // Calcular el total
            Total = Subtotal - Descuento;
        }

        private void LimpiarCampos()
        {
            Producto1 = 0;
            Producto2 = 0;
            Producto3 = 0;
            Subtotal = 0;
            Descuento = 0;
            Total = 0;
        }
    }
}
