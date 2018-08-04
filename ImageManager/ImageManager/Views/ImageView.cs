using ImageManager.ViewModels;
using System;
using Xamarin.Forms;

namespace ImageManager.Views
{
	public class ImageView : ContentPage
	{
        MainPageViewModel viewModel;

        public ImageView(ImageSource imageSource)
        {
            viewModel = new MainPageViewModel();
            BindingContext = viewModel;

            var scrollView = new ScrollView();
            scrollView.Content = new Image() { Source = imageSource, Aspect = Aspect.AspectFill };

            Content = new StackLayout
            {
                Children =
                {
                    scrollView
				}
			};
		}
	}
}