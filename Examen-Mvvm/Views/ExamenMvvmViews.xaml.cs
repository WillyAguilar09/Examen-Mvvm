using Examen_Mvvm.ViewModels;

namespace Examen_Mvvm.Views
{
    public partial class ExamenMvvmViews : ContentPage
    {
        public ExamenMvvmViews()
        {
            InitializeComponent();
            BindingContext = new ExamenMvvmViewModel();
        }
    }
}