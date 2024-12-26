using AutoMapper;
using Ecommerce.BL.DTOs.ProductDTOs;
using Ecommerce.BL.Services.Abstractions;
using Ecommerce.Core.Entities;
using Ecommerce.DAL.Exceptions;
using Ecommerce.DAL.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.BL.Services.Implementations;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public ProductService(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<ProductReadDto> AddAsync(ProductCreateDto productCreateDto)
    {
        var product = _mapper.Map<Product>(productCreateDto);
        product.CreatedAt = DateTime.UtcNow.AddHours(4);

        await _productRepository.AddAsync(product);
        await _productRepository.SaveChangesAsync();

        return _mapper.Map<ProductReadDto>(product);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var product = await _productRepository.GetByIdAsync(id)
            ?? throw new EntityNotFoundException("Product not found");

        _productRepository.Delete(product);
        await _productRepository.SaveChangesAsync();

        return true;
    }

    public async Task<ICollection<ProductReadDto>> GetAllAsync()
    {
        var products = await _productRepository.GetAllAsync();
        return _mapper.Map<ICollection<ProductReadDto>>(products);
    }

    public async Task<ProductReadDto> GetByIdAsync(int id)
    {
        var product = await _productRepository.GetByIdAsync(id)
            ?? throw new EntityNotFoundException("Product not found");

        return _mapper.Map<ProductReadDto>(product);
    }

    public async Task<bool> RestoreAsync(int id)
    {
        var product = await _productRepository.GetByIdAsync(id)
            ?? throw new EntityNotFoundException("Product not found");

        if (product.DeletedAt == null)
            throw new InvalidOperationException("Product is not soft deleted");

        product.DeletedAt = null;
        _productRepository.Restore(product);
        await _productRepository.SaveChangesAsync();

        return true;
    }

    public async Task<bool> SoftDeleteAsync(int id)
    {
        var product = await _productRepository.GetByIdAsync(id)
            ?? throw new EntityNotFoundException("Product not found");

        if (product.DeletedAt != null)
            throw new InvalidOperationException("Product is already soft deleted");

        product.DeletedAt = DateTime.UtcNow.AddHours(4);
        _productRepository.SoftDelete(product);
        await _productRepository.SaveChangesAsync();

        return true;
    }

    public async Task<bool> UpdateAsync(int id, ProductUpdateDto productUpdateDto)
    {
        var existingProduct = await _productRepository.GetByIdAsync(id)
            ?? throw new EntityNotFoundException("Product not found");

        _mapper.Map(productUpdateDto, existingProduct);
        existingProduct.UpdatedAt = DateTime.UtcNow.AddHours(4);

        await _productRepository.UpdateAsync(existingProduct);
        await _productRepository.SaveChangesAsync();

        return true;
    }
}
