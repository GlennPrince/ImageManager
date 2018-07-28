using ImageManager.ViewModels;
using Xamarin.Forms;

namespace ImageManager.Views
{
	public partial class MainPage : ContentPage
	{
        MainPageViewModel viewModel;

		public MainPage()
		{
			InitializeComponent();

            viewModel = new MainPageViewModel();
            BindingContext = viewModel;
		}
	}
}
