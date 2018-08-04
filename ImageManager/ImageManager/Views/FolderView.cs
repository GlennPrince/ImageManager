using ImageManager.ViewModels;
using System;
using Xamarin.Forms;

namespace ImageManager.Views
{
	public class FolderView : ContentPage
	{
        MainPageViewModel viewModel;

        public FolderView(int folderID = 1)
        {
            viewModel = new MainPageViewModel();
            viewModel.LoadImagesFromFolder(folderID);

            BindingContext = viewModel;

            var numPhotos = viewModel.Images.Count / 2;

            var gridView = new Grid();
            gridView.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(200) });
            gridView.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(200) });

            for (var i = 0; i < numPhotos; i++)
            {
                gridView.RowDefinitions.Add(new RowDefinition { Height = new GridLength(200) });
            }

            var count = 0;

            for (var i = 0; i < numPhotos; i++)
            {
                var loadedImage1 = new Image();
                loadedImage1.Source = viewModel.Images[count].Name;
                loadedImage1.Aspect = Aspect.AspectFill;
                var tapGesture1 = new TapGestureRecognizer();
                tapGesture1.Tapped += tapImage_Tapped;
                loadedImage1.GestureRecognizers.Add(tapGesture1);
                gridView.Children.Add(loadedImage1, 0, i);
                count++;
                var loadedImage2 = new Image();
                loadedImage2.Source = viewModel.Images[count].Name;
                loadedImage2.Aspect = Aspect.AspectFill;
                var tapGesture2 = new TapGestureRecognizer();
                tapGesture2.Tapped += tapImage_Tapped;
                loadedImage2.GestureRecognizers.Add(tapGesture2);
                gridView.Children.Add(loadedImage2, 1, i);
                count++;
            }

            var scrollView = new ScrollView();
            scrollView.Content = gridView;

            Content = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                Children =
                {
                    scrollView
                }
            };
        }

        public void tapImage_Tapped(object sender, EventArgs e)
        {
            if (sender.GetType() == typeof(Image))
            {
                var sentImage = (Image)sender;
                Device.BeginInvokeOnMainThread(async () => await Navigation.PushAsync(new ImageView(sentImage.Source)));
                //Device.BeginInvokeOnMainThread(async () => { await Application.Current.MainPage.DisplayAlert("Alert", "This image was tapped: " + sentImage.Source.ToString(), "Cancel"); });
            }
        }
    }
}