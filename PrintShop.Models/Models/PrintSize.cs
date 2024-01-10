namespace PrintShop.GlobalData.Models
{
    public class PrintSize
    {
        public int Id { get; set; }
        public string? Size { get; set; } // String description of size, e.g. 50x100
        public int Height { get; set; }
        public int Width { get; set; }

        public PrintSize(int id, int height, int width)
        {
            Id = id;
            Height = height;
            Width = width;
            Size = Convert.ToString(Height) + "x" + Convert.ToString(Width);
        }
    }
}