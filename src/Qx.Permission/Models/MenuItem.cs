using System.Collections.Generic;
using Qx.Permission.Entity;

namespace Qx.Permission.Models
{
    public class MenuItem
    {
        public bool Selected { get; set; }
        public Menu Father { get; set; }
        public List<Menu> Children { get; set; }
       

      
    }
    
}