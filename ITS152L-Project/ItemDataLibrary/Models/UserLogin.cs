/*

Developed by: 

    Ken Aliling
    Carl Norbi Felonia
    Cedrick Miguel Kaneko
    Amar Jacob Pajarito
    Dino Alfred Timbol

*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//User Login Model. Facilitates in the log in function. Not an entity.

namespace ItemDataLibrary.Models
{
    public class UserLogin
    {
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;


    }
}
