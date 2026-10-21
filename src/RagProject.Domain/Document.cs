using System;
using System.Collections.Generic;
using System.Text;

namespace RagProject.Domain
{
    public class Document
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Content { get; set; } = string.Empty;
    }
}
