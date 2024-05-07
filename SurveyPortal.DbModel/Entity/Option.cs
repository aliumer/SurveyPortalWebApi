using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SurveyPortal.DbModel.Entity
{
    public class Option
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Label { get; set; }
        public string? StartText { get; set; }
        public string? EndText { get; set; }
        public int? Min { get; set; }
        public int? Max { get; set; }
        public int? Interval { get; set; }

        [JsonIgnore]
        public Question? Question { get; set; }
        [JsonIgnore]
        public int? QuestionId { get; set; }
    }
}
