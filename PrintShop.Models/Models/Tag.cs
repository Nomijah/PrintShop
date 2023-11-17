namespace PrintShop.GlobalData.Models
{
    public class Tag
    {
        public string Name { get; set; } = String.Empty;
        public List<Picture>? Pictures { get; set; }
    }
}