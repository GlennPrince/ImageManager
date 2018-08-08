using ImageManager.Models;
using ImageManager.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace ImageManager.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public string Name { get; set; }

        public static ImageRepository repo = new ImageRepository();

        public ObservableCollection<Folder> Folders { get; set; } = new ObservableCollection<Folder>();
        public ObservableCollection<Image> Images { get; set; } = new ObservableCollection<Image>();

        public MainPageViewModel()
        {
            Name = "Image Manager";

            var folders = repo.GetAllFolders();

            foreach (var folder in folders)
                Folders.Add(folder);
        }

        public void LoadImagesFromFolder(int folderID = 1)
        {
            var folder = repo.GetFolder(folderID);

            Name = folder.Name;

            foreach (var image in folder.Images)
                Images.Add(image);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged([CallerMemberName] string caller="")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(caller));
            }
        }
    }
}
