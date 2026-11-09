using System;
using System.Collections.Generic;
using System.Text;

namespace RagProject.Domain
{
    public class DocumentChunk
    {
        public int Id { get; set; }

        public int DocumentId { get; set; }

        public string Content { get; set; } = string.Empty;

        public int ChunkIndex { get; set; }

        public required Document Document { get; set; }

    }
}
