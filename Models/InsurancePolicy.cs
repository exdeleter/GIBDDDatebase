using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GIBDDDatebase.Models
{
    /// <summary>
    /// Страховой полис
    /// </summary>
    internal class InsurancePolicy : BaseEntity
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
        /// Идентификатор транспортного средства
        /// </summary>
        public int TransportVehicleId { get; set; }

        /// <summary>
        /// Транспортное средство
        /// </summary>
        [ForeignKey("TransportVehicleId")]
        public TransportVehicle TransportVehicle { get; set; }

        /// <summary>
        /// Дата начала действия
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Дата окончания действия
        /// </summary>
        public DateTime EndDate { get; set; }

        /// <summary>
        /// Страховая сумма
        /// </summary>
        public decimal InsuranseSum { get; set; }
    }
}
