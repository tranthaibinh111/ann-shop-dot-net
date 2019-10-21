using ann_shop_server.Models;
using ann_shop_server.Models.Pages.InvoiceCustomer;
using ann_shop_server.Services.Pages;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace ann_shop_server.Controllers.Pages
{
    [RoutePrefix("api/v1/invoice")]
    public class InvoiceCustomerController : ApiController
    {
        private InvoiceCustomerService _service;

        public InvoiceCustomerController()
        {
            _service = InvoiceCustomerService.Instance;
        }

        /// <summary>
        /// Kiểm tra xem đơn hàng này có thuộc khách hàng này không
        /// </summary>
        /// <param name="order"></param>
        /// <param name="customer"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{orderID:int}/checkCustomer/{customerID:int}")]
        public IHttpActionResult checkExistOrder(int orderID, int customerID)
        {
            var exist = _service.checkExistOrder(orderID, customerID);

            return Ok<bool>(exist);
        }

        /// <summary>
        /// Lấy thông tin khách hàng
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{orderID:int}/getCustomer")]
        public IHttpActionResult getCustomer(int orderID, int customerID)
        {
            var existOrder = _service.checkExistOrder(orderID, customerID);

            if (!existOrder)
                return NotFound();

            var customer = _service.getCustomer(customerID);

            if (customer != null)
                return Ok(customer);
            else
                return NotFound();
        }

        /// <summary>
        /// Lấy thông tin đơn hàng
        /// </summary>
        /// <param name="orderID"></param>
        /// <param name="customerID"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{orderID:int}/getOrder")]
        public IHttpActionResult getOrder(int orderID, int customerID)
        {
            var existOrder = _service.checkExistOrder(orderID, customerID);

            if (!existOrder)
                return NotFound();

            var order = _service.getOrder(orderID, customerID);

            if (order != null)
                return Ok(order);
            else
                return NotFound();
        }

        /// <summary>
        /// Lấy thông tin danh sảch các sản phẩm đặt hàng
        /// </summary>
        /// <param name="orderID"></param>
        /// <param name="customerID"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{orderID:int}/getOrderItems")]
        public async Task<IHttpActionResult> getOrderItems(int orderID, int customerID)
        {
            var existOrder = _service.checkExistOrder(orderID, customerID);

            if (!existOrder)
                return NotFound();

            var orderItems = await Task.Run(() => _service.getOrderItems(orderID));

            if (orderItems != null)
                return Ok(orderItems);
            else
                return NotFound();
        }
    }
}
