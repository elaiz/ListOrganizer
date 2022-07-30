using System;
using System.Collections.Generic;

namespace ListOrganizer.Repo.Model
{
    public partial class Item
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public int? CategoryId { get; set; }
        public bool Own { get; set; }
        public int? Priority { get; set; }
    }
}
