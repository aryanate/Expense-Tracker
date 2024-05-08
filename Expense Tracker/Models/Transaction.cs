using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Expense_Tracker.Models
{
    public class Transaction
    {
        [Key]
        public int TransactionId { get; set; }

        //CategoryId
        public int CategoryId { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Please Select Appropiate Category")]
        public Category? Category { get; set; }

        [Range(0,int.MaxValue,ErrorMessage ="Amount should be greater than 0")]
        public int Amount { get; set; }

        [Column(TypeName = "nvarchar(75)")]
        public string? Note { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;

        [NotMapped] 
        public string? CategoriesWithIcon {
            get
            {
                return Category == null ? "" : Category.Icon+ " "+Category.Title;
            }
        }
        [NotMapped]
        public string? FormatedAmount
        {
            get
            {
                return (Category == null || Category.Type == "Income" ? "+" : "-")+ "₹" + Amount;
            }
        }
    }
}
