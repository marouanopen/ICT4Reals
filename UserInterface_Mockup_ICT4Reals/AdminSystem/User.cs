using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserInterface_Mockup_ICT4Reals.AdminSystem
{
    public class User
    {
        RoleType Role;
        public int RoleId { get { return (int)Role; } }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        

        public User(int id, string name, string username, int roleId)
        {
            this.Id = id;
            this.Name = name;
            this.Username = username;
            Role = (RoleType)roleId;
        }
    }
}
