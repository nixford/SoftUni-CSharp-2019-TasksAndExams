﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using PetStore.Common;
using PetStore.Data;
using PetStore.Models;
using PetStore.Models.Enumerations;
using PetStore.ServiceModels.Products.InputModels;
using PetStore.ServiceModels.Products.OutputModels;
using PetStore.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetStore.Services
{
    public class ProductService : IProductService
    {
        private readonly PetStoreDbContext dbContext;
        private readonly IMapper mapper;

        public ProductService(PetStoreDbContext dbContext, 
            IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public void AddProduct(AddProductInputServiceModel model)
        {
            try
            {
                Product product = this.mapper.Map<Product>(model);

                this.dbContext.Products.Add(product);
                this.dbContext.SaveChanges();
            }
            catch (Exception)
            {
                throw new ArgumentException(ExceptionMesseges.InvalidProductType);
            }

            
        }

        public ICollection<ListAllProductsByProductTypeServiceModel> ListAllProductType(string type)
        {
            ProductType productType;

            bool hasParsed = Enum.TryParse<ProductType>
                (type, true, out productType);

            if (!hasParsed)
            {
                throw new ArgumentException(ExceptionMesseges.InvalidProductType);
            }

            List<ListAllProductsByProductTypeServiceModel> productsServiceModels =
                this.dbContext.Products
                .Where(p => p.ProductType == productType)
                .ProjectTo<ListAllProductsByProductTypeServiceModel>
                (this.mapper.ConfigurationProvider)
                .ToList();

            return productsServiceModels;
        }

        public ICollection<ListAllProductsServiceModel> GetAll()
        {
            var products = this.dbContext
                .Products
                .ProjectTo<ListAllProductsServiceModel>
                (this.mapper.ConfigurationProvider)
                .ToList();

            return products;
        }

        public bool RemoveById(string id)
        {
            Product productToRemove = this.dbContext
                .Products
                .Find(id);

            if (productToRemove == null)
            {
                throw new ArgumentException(ExceptionMesseges.ProductNotFound);
            }

            this.dbContext.Products.Remove(productToRemove);
            int rowsAffected = this.dbContext.SaveChanges();

            bool wasDeleted = rowsAffected == 1;

            return wasDeleted;
        }

        public bool RemoveByName(string name)
        {
            Product productToRemove = this.dbContext
                .Products
                .FirstOrDefault(p => p.Name == name);

            if (productToRemove == null)
            {
                throw new ArgumentException(ExceptionMesseges.ProductNotFound);
            }

            this.dbContext.Products.Remove(productToRemove);
            int rowsAffected = this.dbContext.SaveChanges();

            bool wasDeleted = rowsAffected == 1;

            return wasDeleted;
        }

        public ICollection<ListAllProductsByNameServiceModel> SearchByName
            (string searchString, bool caseSensitive)
        {
            ICollection<ListAllProductsByNameServiceModel> products;

            if (caseSensitive)
            {
                products = this.dbContext
                    .Products
                    .Where(p => p.Name.Contains(searchString))
                    .ProjectTo<ListAllProductsByNameServiceModel>
                    (this.mapper.ConfigurationProvider)
                    .ToList();
            }
            else
            {
                products = this.dbContext
                    .Products
                    .Where(p => p.Name.ToLower().Contains(searchString.ToLower()))
                    .ProjectTo<ListAllProductsByNameServiceModel>
                    (this.mapper.ConfigurationProvider)
                    .ToList();
            }

            return products;
        }

        public void EditProduct(string id, EditProductInputServiceModel model)
        {
            try
            {
                Product product = this.mapper.Map<Product>(model);

                Product productToUpdate = this.dbContext
                    .Products
                    .Find(id);

                if (productToUpdate == null)
                {
                    throw new ArgumentException(ExceptionMesseges.ProductNotFound);
                }

                productToUpdate.Name = product.Name;
                productToUpdate.ProductType = product.ProductType;
                productToUpdate.Price = product.Price;

                this.dbContext.SaveChanges();
            }
            catch(ArgumentException ae)
            {
                throw ae;
            }
            catch (Exception)
            {

                throw new ArgumentException(ExceptionMesseges.InvalidProductType);
            }
        }
    }
}
