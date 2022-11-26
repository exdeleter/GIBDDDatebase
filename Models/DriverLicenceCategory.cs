using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GIBDDDatebase.Models
{
    internal class DriverLicenceCategory : BaseEntity
    {

        /// <summary>
        /// Идентификатор водительских прав
        /// </summary>
        public int DriverLicenceId { get; set; }

        /// <summary>
        /// Водительские права
        /// </summary>
        [ForeignKey("DriverLicenceId")]
        public DriverLicence DriverLicence { get; set; }

        /// <summary>
        /// Наименование категории
        /// </summary>
        public string Name { get; set; }
    }
}
