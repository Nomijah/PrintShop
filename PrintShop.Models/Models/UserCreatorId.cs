﻿using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintShop.GlobalData.Models
{
    public class UserCreatorId
    {
        public string UserId { get; set; } = string.Empty;
        public string CreatorId { get; set; } = string.Empty;
    }
}
