using _27_FrontToBackSqlConnection.Models;

namespace _27_FrontToBackSqlConnection.Areas.AdminPanel.ViewModels
{
    public class ProductCreateVM
    {
        public IFormFile MainPhoto { get; set; }
        public IFormFile HoverPhoto { get; set; }
        public List<IFormFile>? AdditionalPhotos { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string SKU { get; set; }
        public string Description { get; set; }
        public int? CatagoryId { get; set; }
        public List<int>? TagIds { get; set; }
        public List<Catagory>? Categories { get; set; }
        public List<Tag>? Tags { get; set; }
    }
}
