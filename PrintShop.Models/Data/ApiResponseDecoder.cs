namespace PrintShop.GlobalData.Data
{
    public class ApiResponseDecoder<T>
    {
        public bool isSuccess { get; set; }
        public T? result { get; set; }
        public int statusCode { get; set; }
        public List<string> errorMessages { get; set; } = new();
    }
}
