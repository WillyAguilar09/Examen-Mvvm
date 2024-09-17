using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;

namespace Examen_Mvvm.ViewModels;

partial class ExamenMvvmViewModels : ObservableObject
{
    [ObservableProperty]
    private double producto1;
    [ObservableProperty]
    private double producto2;
    [ObservableProperty]
    private double producto3;
    [ObservableProperty]
    private double descuento;
    [ObservableProperty]
    private double total;
    private void Alerta(string Titulo, string Mensaje)
    {
        MainThread.BeginInvokeOnMainThread(async () => await App.Current!.MainPage!.DisplayAlert(Titulo, Mensaje, "Aceptar"));
    }
    [RelayCommand]
    private void Calcular()
    {
        try
        {
            double discriminante;
            if (Producto1 == 0 || Producto2 == 0 || Producto3 == 0)
            {
                Alerta("Advertencia el", "El valor no puede ser cero");
            }
            else
            {
                Total=producto1 + producto2+producto3;
                if (Total < 1000)
                {
                    Descuento = 0;
                }
                else if (Total < 5000) 
                {
                        Descuento = Total * 0.1;

                }
                else if (Total<10000){
                    Descuento = Total * 0.2;
                }else if (Total > 10000)
                {
                    Descuento = Total * 0.3;
                }
            }
        }
        catch (Exception ex)
        {
            Alerta("ERROR", ex.Message);
        }

    }
    private void Limpiar()
    {
        Producto1 = 0;
        Producto2 = 0;
        Producto3 = 0;
        Total = 0;
        Descuento = 0;
    }
}

