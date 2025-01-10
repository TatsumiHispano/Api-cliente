using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatagridView
{
    public class ContactModel
    {
        public int Id { get; set; }
        /// <summary>
        ///		Nombre del contacto
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Tlf del contacto
        /// </summary>
        public string PhoneNumber { get; set; }
        /// <summary>
        /// Email del contacto
        /// </summary>
        public string Email { get; set; }
    }
}

