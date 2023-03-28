﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace _01_CaseManagementSystem.Models.Entities
{
    internal class CommentEntity
    {
        [Key]
        public int Id { get; set; }

        [StringLength(200)]
        public string? UpdateComment { get; set; } = null!;

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        [StringLength(50)]
        public string? Status { get; set; } = null!;

        public ICollection<TenantEntity> Tenants { get; set; } = new HashSet<TenantEntity>();
    }
}
