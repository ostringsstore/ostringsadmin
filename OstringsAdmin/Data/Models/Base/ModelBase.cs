﻿namespace OstringsAdmin.Data.Models.Base
{
    public class ModelBase
    {
        public Guid Id { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public bool IsDeleted { get; set; }
    }
}
