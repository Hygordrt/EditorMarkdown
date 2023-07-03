using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EditorMarkdown.ModelMkd
{
    public class Modelmkd
    {
        [Key]
        public int Id { get; set; }

        public string ConteudoMkd { get; set; }
    } 
}
