﻿using System.ComponentModel.DataAnnotations;

namespace webproject.Models

{
    public class KarachiKings : Audit
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string path { get; set; }
    }
}
