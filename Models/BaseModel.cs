using System;

namespace EShopService.Models
{
    public abstract class BaseModel
    {
        public int Id { get; set; } // Unikalny identyfikator
        public bool Deleted { get; set; } = false; // Soft-delete
        public DateTime CreatedAt { get; set; } // Data utworzenia
        public Guid CreatedBy { get; set; } // Autor
        public DateTime? UpdatedAt { get; set; } // Ostatnia edycja
        public Guid? UpdatedBy { get; set; } // Edytor
    }
}