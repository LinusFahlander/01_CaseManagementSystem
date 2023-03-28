using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace _01_CaseManagementSystem.Models.Entities
{
    internal class ErrorEntity
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string ErrorTitle { get; set; } = null!;

        [StringLength(200)]
        public string Description { get; set; } = null!;

        [Column("created_at")]
        public DateTime CreatedAt = DateTime.Now;

        [StringLength(200)]
        public string? UpdateComment { get; set; } = null!;

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public ICollection<TenantEntity> Tenants { get; set; } = new HashSet<TenantEntity>();
        public ICollection<AddressEntity> Addresses { get; set; } = new HashSet<AddressEntity>();
        public ICollection<CommentEntity> Comments { get; set; } = new HashSet<CommentEntity>();
    }
}
