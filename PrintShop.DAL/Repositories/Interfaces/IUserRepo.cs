﻿using PrintShop.GlobalData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintShop.DAL.Repositories.Interfaces
{
    public interface IUserRepo
    {
        Task<User> GetByIdAsync(string id);
    }
}
