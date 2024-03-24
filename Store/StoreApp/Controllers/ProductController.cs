﻿using Entities.Models;
using Entities.RequestParameter;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Repositories.Contracts;
using Services.Contracts;


namespace StoreApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly Services.Contracts.IServiceManager _manager;

        public ProductController(Services.Contracts.IServiceManager manager)
        {
            _manager = manager;
        }

        public IActionResult Index(ProductRequestParameters p)
        {
            var model = _manager.ProductService.GetAllProductsWithDetails(p);
            return View(model);
        }

        public IActionResult Get([FromRoute(Name = "id")] int id)
        {
            var model = _manager.ProductService.GetOneProduct(id, false);
            return View(model);
        }
    }
}
