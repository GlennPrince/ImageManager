using ImageManager.ViewModels;
using System;
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

            var listView = new ListView();
            listView.ItemsSource = viewModel.Folders;
            listView.ItemTemplate = new DataTemplate(typeof(ImageCell));
            listView.ItemTemplate.SetBinding(ImageCell.TextProperty, "Name");
            var folderImage = new Image() { Source = "folder.jpg" };
            listView.ItemTemplate.SetValue(ImageCell.ImageSourceProperty, folderImage.Source);

            listView.ItemTapped += tapFolder_Tapped;

            var scrollView = new ScrollView();
            scrollView.Content = listView;

            Content = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                Children =
                {
                    scrollView
                }
            };
		}

        public void tapFolder_Tapped(object sender, ItemTappedEventArgs e)
        {
            var listItem = e.Item as Models.Folder;
            var listView = (ListView)sender;

            listView.SelectedItem = null;

            Device.BeginInvokeOnMainThread(async () => await Navigation.PushAsync(new FolderView(listItem.Id)));

            //Device.BeginInvokeOnMainThread(async () => { await Application.Current.MainPage.DisplayAlert("Alert", "This image was tapped: " + listItem.Name, "Cancel"); });
        }
	}
}
