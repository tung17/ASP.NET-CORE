using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Support.Interfaces;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApartmentJoinRoomController : ControllerBase
    {
        private IDatabaseService DatabaseService;
        public ApartmentJoinRoomController(IDatabaseService databaseService)
        {
            DatabaseService = databaseService;
        }

        [HttpGet]
        public async Task<ActionResult<IResponse<List<IApartmentJoinRoom>>>> Get([FromQuery] Apartment filter)
        {
            try
            {
                List<IApartmentJoinRoom> data = await DatabaseService.ApartmentModelJoinRoom.Get(new ApartmentJoinRoom() { Apartment=filter});
                return new Response<List<IApartmentJoinRoom>>()
                {
                    Status = true,
                    Code = 200,
                    Data = data,
                    msg = "Lấy dữ liệu thành công"
                };
            }
            catch (Exception e)
            {
                return new Response<List<IApartmentJoinRoom>>()
                {
                    Status = true,
                    Code = 201,
                    Data = null,
                    msg = e.Message
                };
            }
        }
    }
}