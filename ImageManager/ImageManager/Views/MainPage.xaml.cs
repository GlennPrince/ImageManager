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

            var listView = new ListView()
            {
                ItemsSource = viewModel.Folders,
                RowHeight = 100,

                ItemTemplate = new DataTemplate(() =>
                {
                    // Create views with bindings for displaying each property.
                    Label nameLabel = new Label();
                    nameLabel.SetBinding(Label.TextProperty, "Name");
                    nameLabel.TextColor = new Color(0, 0, 0);
                    nameLabel.VerticalOptions = new LayoutOptions(LayoutAlignment.Center, true);

                    Image folderImage = new Image() { Source = "folder.jpg", HeightRequest = 96, Aspect = Aspect.AspectFit };

                    // Return an assembled ViewCell.
                    return new ViewCell
                    {
                        View = new StackLayout
                        {
                            Orientation = StackOrientation.Horizontal,
                            Children =
                            {
                                folderImage,
                                nameLabel
                            }
                        }
                    };
                }),
            };

            listView.ItemTapped += tapFolder_Tapped;

            Title = "Image Manager";

            var scrollView = new ScrollView();
            scrollView.Content = listView;

            Content = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                Padding = new Thickness(50,10,10,50),
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
