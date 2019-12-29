using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpiceApp.Data;
using SpiceApp.Models;
using SpiceApp.Models.ViewModels;
using SpiceApp.Utility;

namespace SpiceApp.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class OrderController : Controller
    {

        private ApplicationDbContext _db;
        private int PageSize = 2;

        public OrderController(ApplicationDbContext db)
        {
            _db = db;
        }

        [Authorize]
        public async Task<IActionResult> Confirm(int id)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            OrderDetailsViewModel orderDetailsViewModel =
                new OrderDetailsViewModel()
                {
                    OrderHeader = await _db.OrderHeader.Include(o => o.ApplicationUser).FirstOrDefaultAsync(o => o.Id == id && o.UserId == claim.Value),
                    OrderDetails = await _db.OrderDetails.Where(o => o.OrderId == id).ToListAsync()
                };

            return View(orderDetailsViewModel);

        }

        [Authorize]
        public async Task<IActionResult> OrderHistory(int productPage=1)
        {

            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            OrderListViewModel orderListVM = new OrderListViewModel()
            {
                Orders = new List<OrderDetailsViewModel>()

            };

            
            List<OrderHeader> orderHeaderList =
                await _db.OrderHeader.Include(o => o.ApplicationUser).Where(u => u.UserId == claim.Value).ToListAsync();

            foreach (OrderHeader item in orderHeaderList)
            {
                OrderDetailsViewModel individual = new OrderDetailsViewModel
                {
                    OrderHeader = item,
                    OrderDetails = await _db.OrderDetails.Where(o => o.OrderId == item.Id).ToListAsync()
                };
                orderListVM.Orders.Add(individual);
            }


            var count = orderListVM.Orders.Count;
            orderListVM.Orders = orderListVM.Orders.OrderByDescending(p=>p.OrderHeader.Id).Skip((productPage-1)*PageSize).Take(PageSize).ToList();

            orderListVM.PagingInfo = new PagingInfo()
            {
                CurrentPage = productPage,
                ItemsPerPage = PageSize,
                TotalItem=count,
                urlParam="/Customer/Order/Orderhistory?productPage=:"
            };
            return View(orderListVM);
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetOrderDetails(int Id)
        {
            OrderDetailsViewModel orderDetailsViewModel =
                new OrderDetailsViewModel()
                {
                    OrderHeader = await _db.OrderHeader.FirstOrDefaultAsync(m => m.Id == Id)
                };
            orderDetailsViewModel.OrderDetails =
                await _db.OrderDetails.Where(m => m.OrderId == Id).ToListAsync();

            orderDetailsViewModel.OrderHeader.ApplicationUser =
                await _db.ApplicationUser.FirstOrDefaultAsync(u => u.Id == orderDetailsViewModel.OrderHeader.UserId);

            return PartialView("_IndividualOrderDetails",orderDetailsViewModel);
        }


        [Authorize(Roles = SD.KitchenUser + "," + SD.ManagerUser)]
        public async Task<IActionResult> ManageOrder()
        {
            List<OrderDetailsViewModel> orderDetailVm = new
                 List<OrderDetailsViewModel>();



            List<OrderHeader> orderHeaderList =
                await _db.OrderHeader.Where(o => o.Status == SD.StatusSubmitted || o.Status==SD.StatusInProcess || o.Status==SD.StatusPending).OrderByDescending(o=>o.PickupTime).ToListAsync();

            foreach (OrderHeader item in orderHeaderList)
            {
                OrderDetailsViewModel individual = new OrderDetailsViewModel
                {
                    OrderHeader = item,
                    OrderDetails = await _db.OrderDetails.Where(o => o.OrderId == item.Id).ToListAsync()
                };
                orderDetailVm.Add(individual);
            }

            return View(orderDetailVm.OrderBy(b=>b.OrderHeader.PickupTime).ToList());
        }

        [Authorize(Roles =SD.KitchenUser + "," +SD.ManagerUser)]
        public async Task<IActionResult> OrderPrepare(int OrderId)
        {
            OrderHeader orderHeader = await _db.OrderHeader.FindAsync(OrderId);
            orderHeader.Status = SD.StatusInProcess;
            await _db.SaveChangesAsync();
            return RedirectToAction("ManageOrder","Order");
        }

        [Authorize(Roles = SD.KitchenUser + "," + SD.ManagerUser)]
        public async Task<IActionResult> OrderReady(int OrderId)
        {
            OrderHeader orderHeader = await _db.OrderHeader.FindAsync(OrderId);
            orderHeader.Status = SD.StatusReady;
            await _db.SaveChangesAsync();

            //TODO email logic to notify user
            return RedirectToAction("ManageOrder", "Order");
        }


        [Authorize(Roles = SD.KitchenUser + "," + SD.ManagerUser)]
        public async Task<IActionResult> OrderCancel(int OrderId)
        {
            OrderHeader orderHeader = await _db.OrderHeader.FindAsync(OrderId);
            orderHeader.Status = SD.StatusCancelled;
            await _db.SaveChangesAsync();

            return RedirectToAction("ManageOrder", "Order");
        }


        [Authorize]
        public async Task<IActionResult> OrderPickup(int productPage = 1,string searchEmail=null, string searchName = null, string searchPhone = null)
        {

            //var claimsIdentity = (ClaimsIdentity)User.Identity;
            //var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            OrderListViewModel orderListVM = new OrderListViewModel()
            {
                Orders = new List<OrderDetailsViewModel>()

            };

            StringBuilder param = new StringBuilder();
            param.Append("/Customer/Order/OrderPickup?productPage=:");
            param.Append("&searchName=");
            if (searchName != null)
            {
                param.Append(searchName);
            }
            param.Append("&searchEmail=");
            if (searchEmail != null)
            {
                param.Append(searchEmail);
            }
            param.Append("&searchPhone=");
            if (searchPhone != null)
            {
                param.Append(searchPhone);
            }

            List<OrderHeader> orderHeaderList =
                new List<OrderHeader>();
            if (searchName != null || searchEmail != null ||
                searchPhone != null)
            {
                var user = new ApplicationUser();
                orderHeaderList =
                    new List<OrderHeader>();
                if (searchName != null)
                {
                    orderHeaderList = await _db.OrderHeader
                        .Include(o => o.ApplicationUser)
                        .Where(u => u.PickupName.ToLower().Contains(searchName.ToLower())).OrderByDescending(o => o.OrderDate).ToListAsync();


                }
                else
                {
                    if (searchEmail != null)
                    {
                        user = await _db.ApplicationUser
                            .Where(u => u.Email.ToLower()
                            .Contains(searchEmail.ToLower())).FirstOrDefaultAsync();
                        orderHeaderList = await _db.OrderHeader
                            .Include(o => o.ApplicationUser)
                            .Where(o => o.UserId == user.Id)
                            .OrderByDescending(o => o.OrderDate).ToListAsync();


                    }
                    else
                    {
                        if (searchPhone != null)
                        {
                            orderHeaderList = await _db.OrderHeader
                                .Include(o => o.ApplicationUser)
                                .Where(u => u.PhoneNumber.Contains(searchPhone)).OrderByDescending(o => o.OrderDate).ToListAsync();


                        }
                    }
                }

            }
            else
            {

                 orderHeaderList =
                    await _db.OrderHeader.Include(o => o.ApplicationUser).Where(u => u.Status == SD.StatusReady).ToListAsync();
            }
                foreach (OrderHeader item in orderHeaderList)
                {
                    OrderDetailsViewModel individual = new OrderDetailsViewModel
                    {
                        OrderHeader = item,
                        OrderDetails = await _db.OrderDetails.Where(o => o.OrderId == item.Id).ToListAsync()
                    };
                    orderListVM.Orders.Add(individual);
                }

            
            var count = orderListVM.Orders.Count;
            orderListVM.Orders = orderListVM.Orders.OrderByDescending(p => p.OrderHeader.Id).Skip((productPage - 1) * PageSize).Take(PageSize).ToList();

            orderListVM.PagingInfo = new PagingInfo()
            {
                CurrentPage = productPage,
                ItemsPerPage = PageSize,
                TotalItem = count,
                urlParam = param.ToString()
            };
            return View(orderListVM);
        }


        [Authorize(Roles =SD.FrontDesk + ","+SD.ManagerUser)]
        [HttpPost]
        [ActionName("OrderPickup")]
        public async Task<IActionResult> OrderPickupPost(int orderId)
        {
            OrderHeader orderHeader = await _db.OrderHeader.FindAsync(orderId);
            orderHeader.Status = SD.StatusCancelled;
            await _db.SaveChangesAsync();

            return RedirectToAction("OrderPickup", "Order");

        }
    }
}