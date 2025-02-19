using System.ComponentModel.DataAnnotations.Schema;

namespace serverSide.Models
{
    public class Evaluation
    {
        public Guid EvaluationId { get; set; }
        public string? Feedback { get; set; }
        public DateTime Date { get; set; }
        [Column(TypeName = "decimal(2, 1)")]
        public required decimal Rating { get; set; }
        public string? Status { get; set; }
    }
}
