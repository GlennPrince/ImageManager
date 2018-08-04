using System;
using System.Collections.Generic;
using System.Linq;

using ImageManager.Models;

namespace ImageManager.Services
{
    public class ImageRepository
    {

        public ImageRepository()
        {
            foreach(var image in Images)
            {
                ImageFolders.First().Images.Add(image);

                if (image.Id <= 11)
                    ImageFolders.Find(x => x.Id == 2).Images.Add(image);
                else
                    ImageFolders.Find(x => x.Id == 3).Images.Add(image);
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
            },
            new Image()
            {
                Id = 2,
                Name = "random02.jpg",
                Description = "Random Image 2",
                DateTaken = new DateTime(2018, 07, 21),
                Location = new Android.Gms.Maps.Model.LatLng(-27.4730102, 153.026996)
            },
            new Image()
            {
                Id = 3,
                Name = "random03.jpg",
                Description = "Random Image 3",
                DateTaken = new DateTime(2018, 07, 21),
                Location = new Android.Gms.Maps.Model.LatLng(-27.4730102, 153.026996)
            },
            new Image()
            {
                Id = 4,
                Name = "random04.jpg",
                Description = "Random Image 4",
                DateTaken = new DateTime(2018, 07, 21),
                Location = new Android.Gms.Maps.Model.LatLng(-27.4730102, 153.026996)
            },
            new Image()
            {
                Id = 5,
                Name = "random05.jpg",
                Description = "Random Image 5",
                DateTaken = new DateTime(2018, 07, 21),
                Location = new Android.Gms.Maps.Model.LatLng(-27.4730102, 153.026996)
            },
            new Image()
            {
                Id = 6,
                Name = "random06.jpg",
                Description = "Random Image 6",
                DateTaken = new DateTime(2018, 07, 21),
                Location = new Android.Gms.Maps.Model.LatLng(-27.4730102, 153.026996)
            },
            new Image()
            {
                Id = 7,
                Name = "random07.jpg",
                Description = "Random Image 7",
                DateTaken = new DateTime(2018, 07, 21),
                Location = new Android.Gms.Maps.Model.LatLng(-27.4730102, 153.026996)
            },
            new Image()
            {
                Id = 8,
                Name = "random08.jpg",
                Description = "Random Image 8",
                DateTaken = new DateTime(2018, 07, 21),
                Location = new Android.Gms.Maps.Model.LatLng(-27.4730102, 153.026996)
            },
            new Image()
            {
                Id = 9,
                Name = "random09.jpg",
                Description = "Random Image 9",
                DateTaken = new DateTime(2018, 07, 21),
                Location = new Android.Gms.Maps.Model.LatLng(-27.4730102, 153.026996)
            },
            new Image()
            {
                Id = 10,
                Name = "random10.jpg",
                Description = "Random Image 10",
                DateTaken = new DateTime(2018, 07, 21),
                Location = new Android.Gms.Maps.Model.LatLng(-27.4730102, 153.026996)
            },
            new Image()
            {
                Id = 11,
                Name = "random11.jpg",
                Description = "Random Image 11",
                DateTaken = new DateTime(2018, 07, 21),
                Location = new Android.Gms.Maps.Model.LatLng(-27.4730102, 153.026996)
            },
            new Image()
            {
                Id = 12,
                Name = "random12.jpg",
                Description = "Random Image 12",
                DateTaken = new DateTime(2018, 07, 21),
                Location = new Android.Gms.Maps.Model.LatLng(-27.4730102, 153.026996)
            },
            new Image()
            {
                Id = 13,
                Name = "random13.jpg",
                Description = "Random Image 13",
                DateTaken = new DateTime(2018, 07, 21),
                Location = new Android.Gms.Maps.Model.LatLng(-27.4730102, 153.026996)
            },
            new Image()
            {
                Id = 14,
                Name = "random14.jpg",
                Description = "Random Image 14",
                DateTaken = new DateTime(2018, 07, 21),
                Location = new Android.Gms.Maps.Model.LatLng(-27.4730102, 153.026996)
            },
            new Image()
            {
                Id = 15,
                Name = "random15.jpg",
                Description = "Random Image 15",
                DateTaken = new DateTime(2018, 07, 21),
                Location = new Android.Gms.Maps.Model.LatLng(-27.4730102, 153.026996)
            },
            new Image()
            {
                Id = 16,
                Name = "random16.jpg",
                Description = "Random Image 16",
                DateTaken = new DateTime(2018, 07, 21),
                Location = new Android.Gms.Maps.Model.LatLng(-27.4730102, 153.026996)
            },
            new Image()
            {
                Id = 17,
                Name = "random17.jpg",
                Description = "Random Image 17",
                DateTaken = new DateTime(2018, 07, 21),
                Location = new Android.Gms.Maps.Model.LatLng(-27.4730102, 153.026996)
            }
        };

        private static List<Folder> ImageFolders = new List<Folder>()
        {
            new Folder()
            {
                Id = 1, Name = "All Images", Description = "Default folder with all images within Image Manager", Images = new List<Image>()
            },
            new Folder()
            {
                Id = 2, Name = "People", Description = "All my People images", Images = new List<Image>()
            },
            new Folder()
            {
                Id = 3, Name = "Places", Description = "All my Places images", Images = new List<Image>()
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