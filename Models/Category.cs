using System.ComponentModel.DataAnnotations;

namespace FamilyBudgetCalculator.Models
{
    /// <summary>
    /// Представление категории трансакции в базе данных
    /// </summary>
    public class Category
    {
        /// <summary>
        /// ID категории
        /// </summary>
        [Key]
        public int CategoryID {  get; set; }

        /// <summary>
        /// Название категории
        /// </summary>
        public string? CategoryName { get; set; }
    }
}
