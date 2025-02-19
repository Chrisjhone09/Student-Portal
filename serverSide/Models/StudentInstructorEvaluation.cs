namespace serverSide.Models
{
    public class StudentInstructorEvaluation
    {
        public Guid EvaluationId { get; set; }
        public string StudentId { get; set; }
        public int InstructorId { get; set; }
        public Evaluation Evaluation { get; set; }
        public Student Student { get; set; }
        public Instructor Instructor { get; set; }
    }
}
