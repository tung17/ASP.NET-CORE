using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Support.Interfaces;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApartmentController : ControllerBase
    {
        private IDatabaseService DatabaseService;
        public ApartmentController(IDatabaseService databaseService)
        {
            DatabaseService = databaseService;
        }
        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IResponse<List<IApartment>>>> Get([FromQuery] Apartment filter)
        {
            try
            {
                List<IApartment> data = await DatabaseService.ApartmentModel.Get(filter);
                return new Response<List<IApartment>>()
                {
                    Status = true,
                    Code = 200,
                    Data = data,
                    msg = "Lấy dữ liệu thành công"
                };
            }
            catch (Exception e)
            {
                return new Response<List<IApartment>>()
                {
                    Status = true,
                    Code = 201,
                    Data = null,
                    msg = e.Message
                };
            }
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IResponse<IApartment>>> Get(string id)
        {
            try
            {
                List<IApartment> data = await DatabaseService.ApartmentModel.Get(new Apartment() { Id = new ObjectId(id) });
                return new Response<IApartment>()
                {
                    Status = true,
                    Code = 200,
                    Data = data[0],
                    msg = "Lấy dữ liệu thành công"
                };
            }
            catch (Exception e)
            {
                return new Response<IApartment>()
                {
                    Status = true,
                    Code = 201,
                    Data = null,
                    msg = e.Message
                };
            }
        }

        // POST api/values
        [HttpPost]
        public async Task<ActionResult<IResponse<IApartment>>> Post([FromBody] Apartment data)
        {
            try
            {
                IApartment Result = await DatabaseService.ApartmentModel.Insert(data);
                return new Response<IApartment>()
                {
                    Status = true,
                    Code = 200,
                    Data = Result,
                    msg = "Thêm dữ liệu thành công"
                };
            }
            catch (Exception e)
            {
                return new Response<IApartment>()
                {
                    Status = true,
                    Code = 201,
                    Data = null,
                    msg = e.Message
                };
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<ActionResult<IResponse<IApartment>>> Put(string id, [FromBody] Apartment data)
        {

            try
            {
                bool Result = await DatabaseService.ApartmentModel.Update(new ObjectId(id), data);
                return new Response<IApartment>()
                {
                    Status = Result,
                    Code = 200,
                    Data = null,
                    msg = "Cập nhật dữ liệu thành công"
                };
            }
            catch (Exception e)
            {
                return new Response<IApartment>()
                {
                    Status = false,
                    Code = 201,
                    Data = null,
                    msg = e.Message
                };
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<IResponse<IApartment>>> Delete(string id)
        {
            try
            {
                bool Result = await DatabaseService.ApartmentModel.Delete(new ObjectId(id));
                return new Response<IApartment>()
                {
                    Status = Result,
                    Code = 200,
                    Data = null,
                    msg = "Xóa dữ liệu thành công"
                };
            }
            catch (Exception e)
            {
                return new Response<IApartment>()
                {
                    Status = false,
                    Code = 201,
                    Data = null,
                    msg = e.Message
                };
            }
        }
    }
}