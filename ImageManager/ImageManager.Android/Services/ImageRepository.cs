using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using ImageManager.Droid.Model;

namespace ImageManager.Droid.Repository
{
    public class ImageRepository
    {

        public ImageRepository()
        {
            foreach(var image in Images)
            {
                ImageFolders.First().Images.Add(image);
            }
        }

        // Hard Coded Image Repository
        private static List<Image> Images = new List<Image>()
        {
            new Image()
            {
                Id = 1,
                Name = "random01.jpg",
                Description = "Random Image 1",
                DateTaken = new DateTime(2018, 07, 21),
                Location = new Android.Gms.Maps.Model.LatLng(-27.4730102, 153.026996)
            }
        };

        private static List<Folder> ImageFolders = new List<Folder>()
        {
            new Folder()
            {
                Id = 1, Name = "All Images", Description = "Default folder with all images within Image Manager", Images = new List<Image>()
            }
        };

        public List<Folder> GetAllFolders()
        {
            return ImageFolders;
        }

        public Folder GetFolder(int folderId)
        {
            IEnumerable<Folder> folders =
                from folder in ImageFolders
                where folder.Id == folderId
                select folder;

            return folders.FirstOrDefault();
        }

        public List<Image> GetImages()
        {
            return Images;
        }

        public Image GetImage(int imageId)
        {
            IEnumerable<Image> images =
                from image in Images
                where image.Id == imageId
                select image;

            return images.FirstOrDefault();
        }
    }
}