using Microsoft.AspNetCore.Mvc;
using SneakerShop.Models.ClientViewModels;
using SneakerShop.Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SneakerShop.Controllers
{
    public class ClientController : Controller
    {
        private IClientService clientService;

        public ClientController(IClientService clientService)
        {
            this.clientService = clientService;
            
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var createUserViewModel = new CreateClientViewModel();
            return this.View(createUserViewModel);
        }

        [HttpPost]

        public async Task<IActionResult> Create(CreateClientViewModel createClientViewModel)
        {
            this.clientService.Create(
                createClientViewModel.FirstName,
                createClientViewModel.LastName,
                createClientViewModel.Telephone,
                createClientViewModel.Email,
                createClientViewModel.Gender);

            return this.RedirectToAction("List");
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            return this.View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var client = this.clientService.GetById(id);

            var editClientViewModel = new ClientViewModel(client.Id, client.FirstName, client.LastName,
                client.Telephone, client.Email, client.Gender);

            return this.View(editClientViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ClientViewModel clientViewModel)
        {
            this.clientService.Edit(clientViewModel.Id, clientViewModel.FirstName, clientViewModel.LastName,
                clientViewModel.Telephone, clientViewModel.Email, clientViewModel.Gender );

            return this.RedirectToAction("List");
        }

        public async Task<IActionResult> Delete(int id)
        {
            this.clientService.Delete(id);

            return this.RedirectToAction("List");
        }
    }
}
