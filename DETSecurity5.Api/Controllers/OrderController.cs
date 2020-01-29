using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DETSecurity5.Api.ViewModels;
using DETSecurity5.Data.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DETSecurity5.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class OrderController : ControllerBase
    {
        private readonly DETSecurity5DataService _dataService;

        public OrderController(DETSecurity5DataService dataService)
        {
            _dataService = dataService;
        }

        #region Order

        [HttpGet]
        public ActionResult GetOrders()
        {
            try
            {
                return Ok(_dataService.GetOrders());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpGet("{id}")]
        public ActionResult GetOrderById(int id)
        {
            try
            {
                var vm = _dataService.GetOrderById(id);

                if (vm == null)
                {
                    return NotFound();
                }

                return Ok(vm);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpGet]
        public ActionResult GetOrdersByLoggedInUserId()
        {
            try
            {
                var userId = User.Claims.FirstOrDefault(c => c.Type == "userid").Value;
                return Ok(_dataService.GetOrdersByUserId(userId));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpPost]
        public ActionResult AddOrder([FromBody] OrderVM value)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                _dataService.AddOrder(value);

                return Created("", value);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpPost]
        public ActionResult UpdateClassType([FromBody] OrderVM value)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                _dataService.UpdateOrder(value);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteClassType(int id)
        {
            try
            {
                var vm = _dataService.GetOrderById(id);
                if (vm == null)
                {
                    return NotFound();
                }

                _dataService.DeleteOrder(vm);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        #endregion Order
    }
}