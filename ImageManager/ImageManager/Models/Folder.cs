using System.Collections.Generic;

namespace ImageManager.Models
{
    public class Folder
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public List<Image> Images { get; set; }
    }
}