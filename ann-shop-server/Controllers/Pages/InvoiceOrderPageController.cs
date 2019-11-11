using ann_shop_server.Services.Pages;
using System.Threading.Tasks;
using System.Web.Http;
using System.Collections.Generic;
using ann_shop_server.Models;

namespace ann_shop_server.Controllers
{
    [RoutePrefix("api/v1/invoice")]
    public class InvoiceOrderPageController : ApiController
    {
        private InvoiceOrderPageService _service;

        public InvoiceOrderPageController()
        {
            _service = InvoiceOrderPageService.Instance;
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

        /// <summary>
        /// Tạo yêu cầu xóa order item của khách hàng
        /// </summary>
        /// <param name="customerID"></param>
        /// <param name="orderID"></param>
        /// <param name="orderItem"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("{orderID:int}/deleteOrderItem")]
        public IHttpActionResult deleteOrderItem(int orderID, int customerID, InvoiceOrderOrderItemModel orderItem)
        {
            try
            {
                var requirement = _service.addRequirement(customerID, orderID, orderItem, CustomerRequirement.Delete);

                return Ok(requirement);
            }
            catch (System.Exception ex)
            {

                throw ex;
            }

        }

        /// <summary>
        /// Tạo yêu cầu chỉnh sửa của khách hàng
        /// </summary>
        /// <param name="customerID"></param>
        /// <param name="orderID"></param>
        /// <param name="orderItem"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("{orderID:int}/editOrderItem")]
        public IHttpActionResult editOrderItem(int orderID, int customerID, InvoiceOrderOrderItemModel orderItem)
        {
            try
            {
                var requirement = _service.addRequirement(customerID, orderID, orderItem, CustomerRequirement.Edit);

                return Ok(requirement);
            }
            catch (System.Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Tạo yêu cầu chỉnh sửa của khách hàng
        /// </summary>
        /// <param name="customerID"></param>
        /// <param name="orderID"></param>
        /// <param name="orderItems"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("{orderID:int}/addOrderItem")]
        public IHttpActionResult addOrderItem(int orderID, int customerID, List<InvoiceOrderOrderItemModel> orderItems)
        {
            try
            {
                var requirement = _service.addRequirement(customerID, orderID, orderItems, CustomerRequirement.Add);

                return Ok(requirement);
            }
            catch (System.Exception ex)
            {

                throw ex;
            }
        }
    }
}
