using System.ComponentModel.DataAnnotations;

namespace GymBE.Core.Entities
{
    public abstract class BaseEntity
    {
        [Key]
        public long ID { get; set; }

    }
}
