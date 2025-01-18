using System.ComponentModel.DataAnnotations;

namespace FamilyBudgetCalculator.Models
{
    /// <summary>
    /// Сущность пользователя в базе данных
    /// </summary>
    public class User
    {
        /// <summary>
        /// ID пользователя
        /// </summary>
        [Key]
        public int UserID { get; set; }

        /// <summary>
        /// Логин пользователя
        /// </summary>
        public string? UserName { get; set; }

        /// <summary>
        /// Пароль пользователя
        /// </summary>
        public string? UserPassword { get; set; }
    }
}
