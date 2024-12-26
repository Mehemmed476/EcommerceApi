using Ecommerce.BL.DTOs.ProductDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.BL.Services.Abstractions;

public interface IProductService
{
    Task<ICollection<ProductReadDto>> GetAllAsync();
    Task<ProductReadDto> GetByIdAsync(int id);
    Task<ProductReadDto> AddAsync(ProductCreateDto productCreateDto);
    Task<bool> UpdateAsync(int id, ProductUpdateDto productUpdateDto);
    Task<bool> SoftDeleteAsync(int id);
    Task<bool> RestoreAsync(int id);
    Task<bool> DeleteAsync(int id);
}
