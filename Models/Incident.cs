using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GIBDDDatebase.Models
{
    /// <summary>
    /// Инцидент нарушения
    /// </summary>
    internal class Incident : BaseEntity
    {
        /// <summary>
        /// Идентификатор водителя
        /// </summary>
        public int? DriverId { get; set; }

        /// <summary>
        /// Водитель
        /// </summary>
        [ForeignKey("DriverId")]
        public Driver? Driver { get; set; }

        /// <summary>
        /// Идентификатор транспортного средства
        /// </summary>
        public int? TransportVehicleId { get; set; }

        /// <summary>
        /// Транспортное средство
        /// </summary>
        [ForeignKey("TransportVehicleId")]
        public TransportVehicle? TransportVehicle { get; set; }

        /// <summary>
        /// Идентификатор нарушения
        /// </summary>
        public int ViolationId { get; set; }

        /// <summary>
        /// Нарушение
        /// </summary>
        [ForeignKey("ViolationId")]
        public Violation Violation { get; set; }

        /// <summary>
        /// Дата нарушения
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Дата погашения
        /// </summary>
        public DateTime? RepaymentDate { get; set; }

        /// <summary>
        /// Описание
        /// </summary>
        public string Description { get; set; }
    }
}
