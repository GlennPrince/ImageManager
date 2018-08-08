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

            Title = viewModel.Name;

            BindingContext = viewModel;

            var numPhotos = viewModel.Images.Count;

            var gridView = new Grid();
            gridView.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });
            gridView.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });

            for (var i = 0; i < numPhotos / 2 + 1; i++)
            {
                gridView.RowDefinitions.Add(new RowDefinition { Height = new GridLength(200) });
            }

            for (var i = 0; i < numPhotos; i++)
            {
                var loadedImage = new Image();
                loadedImage.Source = viewModel.Images[i].Name;
                loadedImage.Aspect = Aspect.AspectFill;
                var tapGesture = new TapGestureRecognizer();
                var details = new ImageEventArgs();
                details.ImageName = viewModel.Images[i].Name;

                tapGesture.Tapped += (sender, arg) =>
                {
                    tapImage_Tapped(loadedImage, details);
                };
                loadedImage.GestureRecognizers.Add(tapGesture);

                var position = i / 2;

                if(i % 2 == 0)
                    gridView.Children.Add(loadedImage, 0, i/2);
                else
                    gridView.Children.Add(loadedImage, 1, i/2);
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
                var imageEvent = (ImageEventArgs)e;
                var imageName = imageEvent.ImageName;

                Device.BeginInvokeOnMainThread(async () => await Navigation.PushAsync(new ImageView(sentImage.Source, imageName)));
                //Device.BeginInvokeOnMainThread(async () => { await Application.Current.MainPage.DisplayAlert("Alert", "This image was tapped: " + sentImage.Source.ToString(), "Cancel"); });
            }
        }
    }

    public class ImageEventArgs : EventArgs
    {
        public string ImageName { get; set; }
    }
}