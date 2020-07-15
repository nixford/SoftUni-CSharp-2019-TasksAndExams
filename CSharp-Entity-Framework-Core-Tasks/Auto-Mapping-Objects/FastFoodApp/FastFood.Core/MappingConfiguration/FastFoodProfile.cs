namespace FastFood.Core.MappingConfiguration
{
    using AutoMapper;
    using FastFood.Core.ViewModels.Categories;
    using FastFood.Core.ViewModels.Employees;
    using FastFood.Core.ViewModels.Items;
    using FastFood.Core.ViewModels.Orders;
    using FastFood.Models;
    using FastFood.Models.Enums;
    using System;
    using System.Globalization;
    using ViewModels.Positions;

    public class FastFoodProfile : Profile
    {
        public FastFoodProfile()
        {
            //Positions
            this.CreateMap<CreatePositionInputModel, Position>()
                .ForMember(x => x.Name, y => y.MapFrom(s => s.PositionName));

            this.CreateMap<Position, PositionsAllViewModel>()
                .ForMember(x => x.Name, y => y.MapFrom(s => s.Name));

            // Categories
            this.CreateMap<CreateCategoryInputModel, Category>()
                .ForMember(x => x.Name, y => y.MapFrom(x => x.CategoryName));

            this.CreateMap<Category, CategoryAllViewModel>();

            // Employees
            this.CreateMap<Position, RegisterEmployeeViewModel>()
                .ForMember(destinationMember: x => x.PositionId, memberOptions: y
                => y.MapFrom(mapExpression: x => x.Id))
                .ForMember(destinationMember: x => x.PositionName, memberOptions: y 
                => y.MapFrom(mapExpression: x => x.Name));

            this.CreateMap<RegisterEmployeeInputModel, Employee>();

            this.CreateMap<Employee, EmployeesAllViewModel>()
                .ForMember(destinationMember: x => x.Position, memberOptions: y =>
                y.MapFrom(mapExpression: x => x.Position.Name));

            //Items
            this.CreateMap<Category, CreateItemViewModel>()
                .ForMember(destinationMember: x => x.CategoryId, memberOptions: y 
                => y.MapFrom(mapExpression: x => x.Id))
                .ForMember(destinationMember: x => x.CategoryName, memberOptions: y =>
                y.MapFrom(mapExpression: x => x.Name));

            this.CreateMap<CreateItemInputModel, Item>();

            this.CreateMap<Item, ItemsAllViewModels>()
                .ForMember(destinationMember: x => x.Category, memberOptions: y
                => y.MapFrom(mapExpression: x => x.Category.Name));

            //Orders
            this.CreateMap<Item, CreateOrderItemViewModel>()
                .ForMember(destinationMember: x => x.ItemId, memberOptions: y =>
                y.MapFrom(mapExpression: x => x.Id))
                .ForMember(destinationMember: x => x.ItemName, memberOptions: y =>
                y.MapFrom(mapExpression: x => x.Name));

            this.CreateMap<Employee, CreateOrderEmployeeViewModel>()
                .ForMember(destinationMember: x => x.EmployeeId, memberOptions: y
                => y.MapFrom(mapExpression: x => x.Id))
                .ForMember(destinationMember: x => x.EmployeeName, memberOptions: y =>
                y.MapFrom(mapExpression: x => x.Name));

            this.CreateMap<CreateOrderInputModel, Order>()
                .ForMember(destinationMember: x => x.DateTime, memberOptions: y =>
                y.MapFrom(mapExpression: x => DateTime.UtcNow))
                .ForMember(destinationMember: x => x.Type, memberOptions: y => 
                y.MapFrom(mapExpression: x => OrderType.ToGo));

            this.CreateMap<CreateOrderInputModel, OrderItem>()
                .ForMember(destinationMember: x => x.Quantity, memberOptions: y =>
                y.MapFrom(mapExpression: x => x.Quantity))
                .ForMember(destinationMember: x => x.ItemId, memberOptions: y =>
                y.MapFrom(mapExpression: x => x.ItemId));

            this.CreateMap<Order, OrderAllViewModel>()
                .ForMember(destinationMember: x => x.Employee, memberOptions: y =>
                y.MapFrom(mapExpression: x => x.Employee.Name))
                .ForMember(destinationMember: x => x.DateTime, memberOptions:
                y => y.MapFrom(mapExpression: x => x.DateTime.ToString("D",
                CultureInfo.InvariantCulture)))
                .ForMember(destinationMember: x => x.OrderId, memberOptions: y => 
                y.MapFrom(mapExpression: x => x.Id));
                
        }
    }
}
