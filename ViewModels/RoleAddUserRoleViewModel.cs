using Microsoft.AspNetCore.Mvc.Rendering;
using Project1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.ViewModels
{
    public class RoleAddUserRoleViewModel
    {
            public ApplicationUser User { get; set; }
            public string Role { get; set; }
            public SelectList RoleList { get; set; }
        
    }
}
