﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCAuthentication.Models
{
    public class LoginModel
    {
        public String Email {  get; set; }
        public String Password { get; set; }
        public bool RememberMe { get; set; }
    }
}