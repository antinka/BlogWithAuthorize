using System.ComponentModel.DataAnnotations;
namespace BlogUsingEF.DAL.Entities
{
    public class Tag
    {
        [Key]
        public int Id { get; set; }
        public string Text { get; set; }
    }
}
