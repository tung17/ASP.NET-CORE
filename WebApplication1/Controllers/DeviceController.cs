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
    public class DeviceController : ControllerBase
    {
        private IDatabaseService DatabaseService;
        public DeviceController(IDatabaseService databaseService)
        {
            DatabaseService = databaseService;
        }
        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IResponse<List<IDevice>>>> Get([FromQuery] Device filter)
        {
            try
            {
                filter.IdRoom = new ObjectId(filter.stringIdRoom);
                List<IDevice> data = await DatabaseService.DeviceModel.Get(filter);
                return new Response<List<IDevice>>()
                {
                    Status = true,
                    Code = 200,
                    Data = data,
                    msg = "Lấy dữ liệu thành công"
                };
            }
            catch (Exception e)
            {
                return new Response<List<IDevice>>()
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
        public async Task<ActionResult<IResponse<IDevice>>> Get(string id)
        {
            try
            {
                List<IDevice> data = await DatabaseService.DeviceModel.Get(new Device() { Id = new ObjectId(id) });
                return new Response<IDevice>()
                {
                    Status = true,
                    Code = 200,
                    Data = data[0],
                    msg = "Lấy dữ liệu thành công"
                };
            }
            catch (Exception e)
            {
                return new Response<IDevice>()
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
        public async Task<ActionResult<IResponse<IDevice>>> Post([FromBody] Device data)
        {
            try
            {
                data.IdRoom = new ObjectId(data.stringIdRoom);
                IDevice Result = await DatabaseService.DeviceModel.Insert(data);
                return new Response<IDevice>()
                {
                    Status = true,
                    Code = 200,
                    Data = Result,
                    msg = "Thêm dữ liệu thành công"
                };
            }
            catch (Exception e)
            {
                return new Response<IDevice>()
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
        public async Task<ActionResult<IResponse<IDevice>>> Put(string id, [FromBody] Device data)
        {

            try
            {
                data.IdRoom = new ObjectId(data.stringIdRoom);
                bool Result = await DatabaseService.DeviceModel.Update(new ObjectId(id), data);
                return new Response<IDevice>()
                {
                    Status = Result,
                    Code = 200,
                    Data = null,
                    msg = "Cập nhật dữ liệu thành công"
                };
            }
            catch (Exception e)
            {
                return new Response<IDevice>()
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
        public async Task<ActionResult<IResponse<IDevice>>> Delete(string id)
        {
            try
            {
                bool Result = await DatabaseService.DeviceModel.Delete(new ObjectId(id));
                return new Response<IDevice>()
                {
                    Status = Result,
                    Code = 200,
                    Data = null,
                    msg = "Xóa dữ liệu thành công"
                };
            }
            catch (Exception e)
            {
                return new Response<IDevice>()
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