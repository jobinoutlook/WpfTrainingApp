using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EvernoteClone.Model
{
    public class Note
    {
        [Key]
        public int Id { get; set; }
  
        [ForeignKey("Notebook")]
        public int NotebookId { get; set; }
        public Notebook Notebook { get; set; }
        public string Title { get; set; }
        public DateTime? CreatedTime { get; set; }
        public DateTime? UpdatedTime { get; set; }
        public string? FileLocation { get; set; }
    }
}
