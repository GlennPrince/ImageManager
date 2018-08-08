using ImageManager.ViewModels;
using System;
using Xamarin.Forms;

namespace ImageManager.Views
{
	public class ImageView : ContentPage
	{
        MainPageViewModel viewModel;

        public ImageView(ImageSource imageSource, string imageName)
        {
            viewModel = new MainPageViewModel();
            BindingContext = viewModel;

            Title = imageName;

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