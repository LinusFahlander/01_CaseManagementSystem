using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _01_CaseManagementSystem.Models.Entities
{
    internal class AddressEntity
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string StreetName { get; set; } = null!;

        [Column(TypeName = "char(5)")]
        public string PostalCode { get; set; } = null!;

        [Column(TypeName = "nvarchar(50)")]
        public string City { get; set; } = null!;

        public ICollection<TenantEntity> Tenants = new HashSet<TenantEntity>();
    }
}
