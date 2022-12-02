using Microsoft.EntityFrameworkCore;

namespace GIBDDDatebase.Models;

internal class Driver : BaseEntity
{
    /// <summary>
    /// Имя
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Фамилия
    /// </summary>
    public string Surname { get; set; }

    /// <summary>
    /// Отчество
    /// </summary>
    public string Patronymic { get; set; }

    /// <summary>
    /// Дата рождения
    /// </summary>
    public DateTime DateBirth { get; set; }

    /// <summary>
    /// Место рождения
    /// </summary>
    public string BirthTown { get; set; }

    /// <summary>
    /// Серия и номер
    /// </summary>
    public string SeriesNumber { get; set; }
}