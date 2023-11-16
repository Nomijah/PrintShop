using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PrintShop.GlobalData.Data
{
    public class ApiResponse
    {
        public bool IsSuccess { get; set; }
        public object? Result { get; set; }
        public int StatusCode { get; set; }
        public List<string> ErrorMessages { get; set; } = new();
    }
}
