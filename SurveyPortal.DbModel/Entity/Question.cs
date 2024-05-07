using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

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
        public ICollection<Option> Options { get; set; }

        [JsonIgnore]
        public Survey? Survey { get; set; }
        public int SurveyId { get; set; }
    }

    
}
