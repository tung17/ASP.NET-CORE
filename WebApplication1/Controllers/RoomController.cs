using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Support.Interfaces;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private IDatabaseService DatabaseService;
        public RoomController(IDatabaseService databaseService)
        {
            DatabaseService = databaseService;
        }
        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IResponse<List<IRoom>>>> Get([FromQuery] Room filter)
        {
            try
            {
                List<IRoom> data = await DatabaseService.RoomModel.Get(filter);
                return new Response<List<IRoom>>()
                {
                    Status = true,
                    Code = 200,
                    Data = data,
                    msg = "Lấy dữ liệu thành công"
                };
            }            
            catch(Exception e)
            {
                return new Response<List<IRoom>>()
                {
                    Status = false,
                    Code = 201,
                    Data = null,
                    msg = e.Message
                };
            }
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IResponse<IRoom>>> Get(string id)
        {
            try
            {
                List<IRoom> data = await DatabaseService.RoomModel.Get(new Room() {Id = new ObjectId(id) });
                return new Response<IRoom>()
                {
                    Status = true,
                    Code = 200,
                    Data = data[0],
                    msg = "Lấy dữ liệu thành công"
                };
            }
            catch (Exception e)
            {
                return new Response<IRoom>()
                {
                    Status = false,
                    Code = 201,
                    Data = null,
                    msg = e.Message
                };
            }
        }

        // POST api/values
        [HttpPost]
        public async Task<ActionResult<IResponse<IRoom>>> Post([FromBody] Room data)
        {
            try
            {
                data.IdApartment = new ObjectId(data.stringApartment);
                IRoom Result = await DatabaseService.RoomModel.Insert(data);
                return new Response<IRoom>(){
                    Status = true,
                    Code = 200,
                    Data = Result,
                    msg = "Thêm dữ liệu thành công"
                };
            }
            catch(Exception e)
            {
                return new Response<IRoom>()
                {
                    Status = false,
                    Code = 201,
                    Data = null,
                    msg = e.Message
                };
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<ActionResult<IResponse<IRoom>>> Put(string id, [FromBody] Room data)
        {
            
            try
            {
                data.IdApartment = new ObjectId(data.stringApartment);
                bool Result = await DatabaseService.RoomModel.Update(new ObjectId(id), data);
                return new Response<IRoom>()
                {
                    Status = Result,
                    Code = 200,
                    Data = null,
                    msg = "Cập nhật dữ liệu thành công"
                };
            }
            catch(Exception e)
            {
                return new Response<IRoom>()
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
        public async Task<ActionResult<IResponse<IRoom>>> Delete(string id)
        {
            try
            {
                bool Result = await DatabaseService.RoomModel.Delete(new ObjectId(id));
                return new Response<IRoom>()
                {
                    Status = Result,
                    Code = 200,
                    Data = null,
                    msg = "Xóa dữ liệu thành công"
                };
            }
            catch (Exception e)
            {
                return new Response<IRoom>()
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
