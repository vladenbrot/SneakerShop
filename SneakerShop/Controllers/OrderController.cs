using SneakerShop.Data.Entities;
using SneakerShop.Models;
using SneakerShop.Models.OrderViewModels;
using SneakerShop.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SneakerShop.Service.Contracts;

namespace SneakerShop.Controllers
{
    public class OrderController : Controller
    {
        private IOrderService orderService;
        private IClientService clientService;
        private IShoeService shoeService;

        public OrderController(IOrderService orderService, IClientService clientService,
            IShoeService shoeService)
        {
            this.orderService = orderService;
            this.clientService = clientService;
            this.shoeService = shoeService;
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var createOrderViewModel = new CreateOrderViewModel();
            return this.View(createOrderViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(int id, double orderPrice, int shoeCount, Shoe shoe, ShoeType shoeType)
        {

            this.orderService.Create(id, orderPrice, shoeCount, shoe, shoeType);

            return this.RedirectToAction("List");
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            return this.View();
        }

        public async Task<IActionResult> Details(int id)
        {
            var order = this.orderService.GetById(id);
            var people = new List<Client>();

            foreach (var clientOrder in order.ClientsOrders)
            {
                var client = this.clientService.GetById(clientOrder.ClientId);

                people.Add(client);
            }

            var detailViewModel = new OrderDetailsViewModels(order.Id, order.Shoe, order.ShoeCount, order.ShoeType, order.OrderPrice);

            return this.View(detailViewModel);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var order = this.orderService.GetById(id);
            var editOrder = new EditOrderViewModel(order.Id, order.ShoeCount, order.ShoeType, order.Shoe, order.OrderPrice);

            return this.View(editOrder);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, int shoeCount, ShoeType shoeType, int shoesId, double orderPrice)
        {
            var shoe = this.shoeService.GetById(shoesId);

            this.orderService.Edit(id, orderPrice, shoeCount, shoe, shoeType);

            return this.RedirectToAction("List");
        }


        public async Task<IActionResult> Delete(int id)
        {
            this.orderService.Delete(id);

            return this.RedirectToAction("List");
        }

        [HttpGet]
        public async Task<IActionResult> AddClients(int id)
        {
            var order = this.orderService.GetById(id);

            var addClientsViewModel = new AddClientViewModel(id, order.ShoeCount);
            addClientsViewModel.People = (IEnumerable<MySql.Data.MySqlClient.Memcached.Client>)this.clientService.GetAll().ToList();

            return this.View(addClientsViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddClients(int id, List<int> people)
        {
            var clients = new List<Client>();

            foreach (var peopleId in people)
            {
                var person = this.clientService.GetById(peopleId);
                clients.Add(person);
            }

            this.orderService.AddClients(clients, id);
            return this.RedirectToAction("List");
        }
    }
}

