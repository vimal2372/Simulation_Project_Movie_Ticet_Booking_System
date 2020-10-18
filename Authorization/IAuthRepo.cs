﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Authorization
{
  public interface IAuthRepo
    {
        string GenerateJSONWebToken();
    }
}
