using System.ComponentModel.DataAnnotations;

namespace PrintShop.GlobalData.Models
{
    public class Tag
    {
        [Key]
        public string Title { get; set; } = String.Empty;
        public List<Picture>? Pictures { get; set; }
    }
}