namespace serverSide.Models
{
    public class StudentInstructorEvaluation
    {
        public Guid EvaluationId { get; set; }
        public string StudentId { get; set; }
        public string FacultyId { get; set; }
        public Evaluation Evaluation { get; set; }
        public Student Student { get; set; }
        public Faculty Faculty { get; set; }
    }
}
