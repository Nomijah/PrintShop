using PrintShop.GlobalData.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintShop.BLL.Services.Interfaces
{
    public interface IEmailService
    {
        void SendEmail(Message message);
    }
}
