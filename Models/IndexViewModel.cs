namespace FamilyBudgetCalculator.Models
{
    public class IndexViewModel
    {
        public IEnumerable<FamilyBudgetCalculator.Models.User>? Users { get; set; } = new List<User>();
        public IEnumerable<FamilyBudgetCalculator.Models.Category>? Categories { get; set; } = new List<Category>();
        public IEnumerable<FamilyBudgetCalculator.Models.Type>? Types { get; set; } = new List<Type>();
        public IEnumerable<FamilyBudgetCalculator.Models.Transaction>? Transactions { get; set; } = new List<Transaction>();
    }
}
