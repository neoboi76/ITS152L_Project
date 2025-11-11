/**
 * Developed by Group 9:
     * Ken Aliling
     * Carl Norbi Felonia
     * Cedrick Miguel Kaneko
     * Amar Jacob Pajarito
     * Dino Alfred Timbol
 * 
 *  User Login DTO class for login operations
 **/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemDataLibrary.Models
{
    public class UserLogin
    {
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;


    }
}
