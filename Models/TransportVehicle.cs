using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GIBDDDatebase.Models
{
    internal class TransportVehicle : BaseEntity
    {
        /// <summary>
        /// Модель
        /// </summary>
        public string Model { get; set; }

        /// <summary>
        /// Цвет
        /// </summary>
        public string Color { get; set; }

        /// <summary>
        /// Государственные номера
        /// </summary>
        public string LicencePlate { get; set; }


        /// <summary>
        /// Объем двигателя
        /// </summary>
        public int EngineVolume { get; set; }

        /// <summary>
        /// Тип ТС
        /// </summary>
        public int Type { get; set; }

        /// <summary>
        /// Год выпуска
        /// </summary>
        public int ReleaseYear { get; set; }
    }
}
