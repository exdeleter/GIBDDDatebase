using System.ComponentModel.DataAnnotations.Schema;
namespace GIBDDDatebase.Models;

/// <summary>
/// Водительское удостоверение
/// </summary>
internal class DriverLicence : BaseEntity
{
    /// <summary>
    /// Идентификатор водителя
    /// </summary>
    public int DriverId { get; set; }

    /// <summary>
    /// Водитель
    /// </summary>
    [ForeignKey("DriverId")]
    public Driver Driver { get; set; }

    /// <summary>
    /// Дата начала действия
    /// </summary>
    public DateTime StartDate { get; set; }

    /// <summary>
    /// Дата окончания действия
    /// </summary>
    public DateTime EndDate { get; set;}

    /// <summary>
    /// Наименование выдающего подразделения
    /// </summary>
    public string IssuerName { get; set; }

    /// <summary>
    /// Номер региона
    /// </summary>
    public int RegionNum { get; set; }
}