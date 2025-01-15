using System.ComponentModel.DataAnnotations;

namespace FamilyBudgetCalculator.Models
{
    /// <summary>
    /// Представление сущности Трансакции в базе банных
    /// </summary>
    public class Transaction
    {
        /// <summary>
        /// ID трансакции
        /// </summary>
        [Key]
        public int TransactionID {  get; set; }
        /// <summary>
        /// ID типа трансакции
        /// </summary>
        public int TransactionTypeID { get; set; }
        /// <summary>
        /// ID категории трансакции
        /// </summary>
        public int TransactionCategoryID { get; set; }
        /// <summary>
        /// Сумма трансакции
        /// </summary>
        public float TransactionAmount { get; set; }
        /// <summary>
        /// ID пользователя, совершившего трансакцию
        /// </summary>
        public int TransactionUserID { get; set; }
    }
}
