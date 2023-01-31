using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BMISBLayer.Entities
{
   public class Person :IdentityUser
    {
        public String FullName { get; set; }
    }
}
