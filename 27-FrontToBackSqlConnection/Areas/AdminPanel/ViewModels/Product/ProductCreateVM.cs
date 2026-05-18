using _27_FrontToBackSqlConnection.Models;

namespace _27_FrontToBackSqlConnection.Areas.AdminPanel.ViewModels
{
    public class ProductCreateVM
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string SKU { get; set; }
        public string Description { get; set; }
        public int? CatagoryId { get; set; }
        public List<Catagory>? Categories { get; set; }
    }
}
