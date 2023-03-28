using _01_CaseManagementSystem.Contexts;
using _01_CaseManagementSystem.Models;
using _01_CaseManagementSystem.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace _01_CaseManagementSystem.Services
{
    internal class ErrorService
    {
        private static readonly DataContext _context = new DataContext();
        public static async Task SaveAsync(Tenant tenant)
        {
            var _tenantEntity = new TenantEntity
            {
                Id = tenant.Id,
                FirstName = tenant.FirstName,
                LastName = tenant.LastName,
                Email = tenant.Email,
                PhoneNumber = tenant.PhoneNumber,
            };
            var _erorrEntity = await _context.Errors.FirstOrDefaultAsync(x => x.ErrorTitle == tenant.ErrorTitle && x.Description == tenant.Description);
            if (_erorrEntity != null)
                _tenantEntity.ErrorId = _erorrEntity.Id;
            else
                _tenantEntity.Errors = new ErrorEntity
                {
                    ErrorTitle = tenant.ErrorTitle,
                    Description = tenant.Description,
                    CreatedAt = DateTime.UtcNow,
                };
            var _adressEntity = await _context.Addresses.FirstOrDefaultAsync(x => x.StreetName == tenant.StreetName && x.PostalCode == tenant.PostalCode && x.City == tenant.City);
            if (_adressEntity != null)
                _tenantEntity.AddressId = _adressEntity.Id;
            else
                _tenantEntity.Addresses = new AddressEntity
                {
                    StreetName = tenant.StreetName,
                    PostalCode = tenant.PostalCode,
                    City = tenant.City,
                };

            var _commentEntity = await _context.Comments.FirstOrDefaultAsync(x => x.UpdateComment == tenant.UpdateComment && x.UpdatedAt == tenant.UpdatedAt && x.Status == tenant.Status);
            if (_commentEntity != null)
                _tenantEntity.CommentsId = _commentEntity.Id;
            else
                _tenantEntity.Comments = new CommentEntity
                {
                    UpdateComment = tenant.UpdateComment,
                    UpdatedAt = DateTime.UtcNow,
                    Status = tenant.Status,
                };


            _context.Add(_tenantEntity);
            await _context.SaveChangesAsync();
        }

        public static async Task<IEnumerable<Tenant>> GetAllAsync()
        {
            var _tenants = new List<Tenant>();

            foreach (var _tenant in await _context.Tenants.Include(x => x.Errors).ThenInclude(x => x.Addresses).Include(x => x.Comments).ToListAsync())

                _tenants.Add(new Tenant

                {
                    Id = _tenant.Id,
                    FirstName = _tenant.FirstName,
                    LastName = _tenant.LastName,
                    Email = _tenant.Email,
                    PhoneNumber = _tenant.PhoneNumber,
                    ErrorTitle = _tenant.Errors.ErrorTitle,
                    Description = _tenant.Errors.Description,
                    CreatedAt = DateTime.Now,
                    UpdateComment = _tenant.Comments.UpdateComment,
                    Status = _tenant.Comments.Status,
                    UpdatedAt = DateTime.Now,
                    StreetName = _tenant.Addresses.StreetName,
                    PostalCode = _tenant.Addresses.PostalCode,
                    City = _tenant.Addresses.City,
                });
            return _tenants;
        }


        public static async Task<Tenant> GetAsync(string email)
        {
            var _tenant = await _context.Tenants.Include(x => x.Errors).ThenInclude(x => x.Addresses).Include(x => x.Comments).FirstOrDefaultAsync(x => x.Email == email);
            if (_tenant != null)
                return new Tenant
                {
                    Id = _tenant.Id,
                    FirstName = _tenant.FirstName,
                    LastName = _tenant.LastName,
                    Email = _tenant.Email,
                    PhoneNumber = _tenant.PhoneNumber,
                    ErrorTitle = _tenant.Errors.ErrorTitle,
                    Description = _tenant.Errors.Description,
                    CreatedAt = DateTime.Now,
                    UpdateComment = _tenant.Comments.UpdateComment,
                    UpdatedAt = DateTime.Now,
                    StreetName = _tenant.Addresses.StreetName,
                    PostalCode = _tenant.Addresses.PostalCode,
                    City = _tenant.Addresses.City,
                    Status = _tenant.Comments.Status,
                };
            else
                return null!;
        }

        public static async Task UpdateAsync(Tenant tenant)
        {
            var _tenantEntity = await _context.Tenants.Include(x => x.Errors).FirstOrDefaultAsync(x => x.Id == tenant.Id);
            if (_tenantEntity != null)
            {
                if (!string.IsNullOrEmpty(tenant.FirstName)) _tenantEntity.FirstName = tenant.FirstName;
                if (!string.IsNullOrEmpty(tenant.LastName)) _tenantEntity.LastName = tenant.LastName;
                if (!string.IsNullOrEmpty(tenant.Email)) _tenantEntity.Email = tenant.Email;
                if (!string.IsNullOrEmpty(tenant.PhoneNumber)) _tenantEntity.PhoneNumber = tenant.PhoneNumber;

                if (!string.IsNullOrEmpty(tenant.ErrorTitle) || !string.IsNullOrEmpty(tenant.Description) || !string.IsNullOrEmpty(tenant.UpdateComment) || !string.IsNullOrEmpty(tenant.Status))
                    if (!string.IsNullOrEmpty(tenant.StreetName) || !string.IsNullOrEmpty(tenant.PostalCode) || !string.IsNullOrEmpty(tenant.City))
                    {

                        var _commentEntity = await _context.Comments.FirstOrDefaultAsync(x => x.UpdateComment == tenant.UpdateComment && x.UpdatedAt == tenant.UpdatedAt && x.Status == tenant.Status);
                        if (_commentEntity != null)
                            _tenantEntity.CommentsId = _commentEntity.Id;
                        else
                            _tenantEntity.Comments = new CommentEntity
                            {
                                UpdateComment = tenant.UpdateComment,
                                UpdatedAt = DateTime.UtcNow,
                                Status = tenant.Status,

                            };
                        var _errorEntity = await _context.Errors.FirstOrDefaultAsync(x => x.ErrorTitle == tenant.ErrorTitle && x.Description == tenant.Description);
                        if (_errorEntity != null)
                            _tenantEntity.ErrorId = _errorEntity.Id;
                        else
                            _tenantEntity.Errors = new ErrorEntity
                            {
                                ErrorTitle = tenant.ErrorTitle,
                                Description = tenant.Description,
                                CreatedAt = DateTime.Now,
                            };
                        var _adressEntity = await _context.Addresses.FirstOrDefaultAsync(x => x.StreetName == tenant.StreetName && x.PostalCode == tenant.PostalCode && x.City == tenant.City);
                        if (_adressEntity != null)
                            _tenantEntity.AddressId = _adressEntity.Id;

                        else
                            _tenantEntity.Addresses = new AddressEntity
                            {
                                StreetName = tenant.StreetName,
                                PostalCode = tenant.PostalCode,
                                City = tenant.City,
                            };
                    }
                _context.Update(_tenantEntity);
                await _context.SaveChangesAsync();
            }
        }

        public static async Task DeleteAsync(string email)
        {
            var tenant = await _context.Tenants.Include(x => x.Errors).ThenInclude(x => x.Addresses).Include(x => x.Comments).FirstOrDefaultAsync(x => x.Email == email);
            if (tenant != null)
            {
                _context.Remove(tenant);
                await _context.SaveChangesAsync();
            }
        }
    }
}