using System.ComponentModel.DataAnnotations;

namespace FamilyBudgetCalculator.Models
{
    /// <summary>
    /// Представление типа трансакции в базе данных
    /// </summary>
    public class Type
    {
        /// <summary>
        /// ID типа
        /// </summary>
        [Key]
        public int CategoryID { get; set; }

        /// <summary>
        /// Название типа
        /// </summary>
        public string? CategoryName { get; set; }
    }
}
