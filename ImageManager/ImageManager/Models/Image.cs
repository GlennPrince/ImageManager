using System;

using Android.Gms.Maps.Model;

namespace ImageManager.Models
{
    public class Image
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime DateTaken { get; set; }

        public LatLng Location { get; set; }
    }
}