using ERP_API.Application.ApplicationConstant;
using ERP_API.Application.Common;
using ERP_API.Application.DTO.CustomerDto;
using ERP_API.Application.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ERP_API.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        public readonly ICustomerService _customerService;
        protected APIResponse _response;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
            _response = new APIResponse();
        }


        [HttpGet]
        public async Task<ActionResult<APIResponse>> Get()
        {
            try
            {
                var customers = await _customerService.GetAllAsync();
                _response.StatusCode = HttpStatusCode.OK;
                _response.IsSuccess = true;
                _response.Result = customers;
            }
            catch (Exception ex)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                _response.AddError(CommenMessage.SystemError);
            }
            return Ok(_response);
        }

        [HttpPost]
        public async Task<ActionResult<APIResponse>> Create([FromBody] CreateCustomerDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.DisaplayMessage = CommenMessage.CreateOperationFailed;
                    _response.AddError(ModelState.ToString());
                    return Ok(_response);

                }

                var entity = await _customerService.CreateAsync(dto);
                _response.StatusCode = HttpStatusCode.Created;
                _response.IsSuccess = true;
                _response.DisaplayMessage = CommenMessage.CreateOperationSuccess;
                _response.Result = entity;
            }
            catch (Exception ex)
            {
                _response.StatusCode = HttpStatusCode.InternalServerError;
                _response.DisaplayMessage = CommenMessage.CreateOperationFailed;
                _response.AddError(CommenMessage.SystemError);
            }

            return Ok(_response);

        }
    }
}
