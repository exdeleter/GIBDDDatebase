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
        /// Дата начала действия
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Дата окончания действия
        /// </summary>
        public DateTime EndDate { get; set;}

        /// <summary>
        /// Идентификатор категории ВП
        /// </summary>
        public int CategoryId { get; set; }

        /// <summary>
        /// Категория
        /// </summary>
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
    }
}
