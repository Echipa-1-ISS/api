﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs {
    public class LoginResponse {
        public string Token { get; set; }
        public int UserId { get; set; }
    }
}
