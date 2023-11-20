using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SurveyPortal.DbModel.Entity
{
    public class Question
    {
        public Question() 
        {
            Options = new HashSet<Option>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string QuestionType { get; set; }
        public string QuestionText { get; set; } = string.Empty;
        public virtual ICollection<Option> Options { get; set; }
        public virtual Survey Survey { get; set; }
    }

    public class Option
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public string Label { get; set; }
        public virtual Question Question { get; set; }
    }
}
