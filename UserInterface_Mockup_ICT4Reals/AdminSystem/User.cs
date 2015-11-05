using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserInterface_Mockup_ICT4Reals.AdminSystem
{
    public class User
    {
        /// <summary>
        /// fields
        /// </summary>
        RoleType Role;
        public int RoleId { get { return (int)Role; } }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="id">id of the user</param>
        /// <param name="name">name of the user</param>
        /// <param name="username">username of the user (represented by email)</param>
        /// <param name="roleId">role represented by the enum</param>
        public User(int id, string name, string username, int roleId)
        {
            this.Id = id;
            this.Name = name;
            this.Username = username;
            Role = (RoleType)roleId;
        }
    }
}
