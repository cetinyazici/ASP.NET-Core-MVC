﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Services.Contracts;

namespace StoreApp.Component
{
    public class ShowcaseViewComponent : ViewComponent
    {
        private readonly IServiceManager _services;

        public ShowcaseViewComponent(IServiceManager services)
        {
            _services = services;
        }

        public IViewComponentResult Invoke(string page = "default")
        {
            var product = _services.ProductService.GetShowcaseProducts(false);
            return page.Equals("default")
                ? View(product)
                : View("list", product);
        }
    }
}
