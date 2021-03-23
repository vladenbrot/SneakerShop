using Microsoft.AspNetCore.Mvc;
using SneakerShop.Models.ShoeViewModels;
using SneakerShop.Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SneakerShop.Controllers
{
    public class ShoeController : Controller
    {
        private IShoeService shoeService;

        public ShoeController(IShoeService shoeService)
        {
            this.shoeService = shoeService;
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var createUserViewModel = new CreateShoeViewModel();
            return this.View(createUserViewModel);
        }
        [HttpPost]
        public IActionResult Create(CreateShoeViewModel createShoeViewModel)
        {
            this.shoeService.Create(
                createShoeViewModel.Id,
                createShoeViewModel.AmountInStore,
                createShoeViewModel.Price,
                createShoeViewModel.Type,
                createShoeViewModel.Size);

            return RedirectToAction("List", createShoeViewModel);
        }

        [HttpGet]
        public IActionResult List()
        {
            return this.View();
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            var shoe = this.shoeService.GetById(id);

            var editShoeViewModel = new ShoeViewModel(shoe.Id, shoe.AmountInStore, shoe.IsOnSale, shoe.Price, shoe.IsNewRelease, shoe.ShoeType, shoe.Size);
            return this.View(editShoeViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(ShoeViewModel shoeViewModel)
        {
            this.shoeService.Edit(shoeViewModel.Id, shoeViewModel.AmountInStore, shoeViewModel.Price, shoeViewModel.Type, shoeViewModel.Size);
            return this.RedirectToAction("List");
        }
    }
}
