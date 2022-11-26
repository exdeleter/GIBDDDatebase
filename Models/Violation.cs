using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GIBDDDatebase.Models
{
    /// <summary>
    /// Нарушение
    /// </summary>
    internal class Violation : BaseEntity
    {
        /// <summary>
        /// Код нарушения
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Наименование
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Штраф
        /// </summary>
        public string Fine { get; set; }
    }
}
