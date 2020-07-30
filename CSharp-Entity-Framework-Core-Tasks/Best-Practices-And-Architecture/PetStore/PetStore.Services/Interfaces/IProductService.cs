using PetStore.ServiceModels.Products.InputModels;
using PetStore.ServiceModels.Products.OutputModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetStore.Services.Interfaces
{
    public interface IProductService
    {
        void AddProduct(AddProductInputServiceModel model);

        ProductDetailServiceModel GetById(string id);

        ICollection<ListAllProductsByProductTypeServiceModel>ListAllByProductType(string type);

        ICollection<ListAllProductsServiceModel> GetAll();

        ICollection<ListAllProductsByNameServiceModel> SearchByName
            (string searchString, bool caseSensitive);

        bool RemoveById(string id);

        bool RemoveByName(string name);

        void EditProduct(string id, EditProductInputServiceModel model);
    }
}
