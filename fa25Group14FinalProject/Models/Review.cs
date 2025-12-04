using System.ComponentModel.DataAnnotations;

namespace fa25Group14FinalProject.Models
{
    public enum DisputeStatus
    {
        Approve,
        Reject
    }
    public class Review
    {
        // Primary Key
        public int ReviewID { get; set; }

        // Scalar Properties

        // 1. Rating (Scale of 1-5, whole numbers)
        [Display(Name = "Rating (1-5)")]
        [Required(ErrorMessage = "Rating is required.")]
        [Range(1, 5, ErrorMessage = "Rating must be a whole number between 1 and 5.")]
        public int Rating { get; set; }

        // 2. Review Text (Limited to 100 characters) 
        [Display(Name = "Review Text")]
        [StringLength(100, ErrorMessage = "Review cannot exceed 100 characters.")]
        public string ReviewText { get; set; }

        // 3. Approval Status (True if approved, False if rejected, Null if pending)
        [Display(Name = "Is Approved?")]
        public bool? IsApproved { get; set; }

        // 4. Dispute Status (Optional field from ERD - for tracking issues) 
        public DisputeStatus? DisputeStatus { get; set; }

        // 5. Review Date (Helpful for tracking/sorting approvals)
        public DateTime ReviewDate { get; set; }

        // Navigational Properties (Foreign Keys)

        // 1. Foreign Key to the Reviewer (Customer) 
        public string ReviewerID { get; set; }
        public virtual AppUser? Reviewer { get; set; }

        // 2. Foreign Key to the Book [cite: 16]
        public int BookID { get; set; }
        public virtual Book? Book { get; set; }

        // 3. Foreign Key to the Approver (Employee/Admin) 
        // Nullable if the review is still pending approval
        public string? ApproverID { get; set; }
        public virtual AppUser? Approver { get; set; }

    }
}