using System.Collections.ObjectModel;
using RESTDemo.Models;

namespace RESTDemo.ViewModels;

public class OnBoardingViewModel
{
    #region Properties
    public ObservableCollection<Screen> Screens { get; set; } = new ObservableCollection<Screen>();
    #endregion

    public OnBoardingViewModel()
    {
        Screens.Add(new Screen
        {
            Title = "Bienvenido a SIMET",
            Description = "La conexión directa al mundo del transporte terrestre desde la palma de tu mano. Nuestra app te permite contratar u ofrecer servicios de transporte con facilidad, seguridad y eficiencia",
            ImageUrl = "firstscreen"
        });
        
        Screens.Add(new Screen
        {
            Title = "Subastas en tiempo real",
            Description = "Participa en tiempo real en subastas relacionadas al mundo del transporte terrestre de productos y mercancías.",
            ImageUrl = "secondscreen"
        });
        
        Screens.Add(new Screen
        {
            Title = "Beneficios de usar SIMET",
            Description = "Con SIMET, estás siempre en control. Para los transportistas, ofrecemos acceso a un mercado más amplio lleno de oportunidades de negocios. Para los demandantes de servicios de transporte, garantizamos opciones de transporte seguras y rentables.",
            ImageUrl = "thirdscreen"
        });
        
    }
}