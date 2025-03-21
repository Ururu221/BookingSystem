using BookingSystem_web_api.Models;
using BookingSystem_web_api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookingSystem_web_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingSystemController : Controller
    {
        private readonly IBookingService _bookingService;

        public BookingSystemController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id) 
        {
            var room = await _bookingService.GetRoomAsync(id);
            return Ok(room);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() 
        { 
            var rooms = await _bookingService.GetAllRoomsAsync();
            return Ok(rooms);
        }

        [HttpPost]
        public async Task<IActionResult> Create(RoomModel room) 
        {
            await _bookingService.CreateRoomAsync(room);
            return Ok(room);
        }

        [HttpPut]
        public async Task<IActionResult> Update(RoomModel room)
        {
            var newRoom = await _bookingService.UpdateRoomAsync(room);
            return Ok(newRoom);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id) 
        {
            await _bookingService.DeleteRoomAsync(id);
            return NoContent();
        }

        [HttpPost("book/{roomId}")]
        public async Task<IActionResult> Book(Guid roomId, Reservation reservation) 
        {
            var room = await _bookingService.BookRoomAsync(roomId, reservation);
            return Ok(room);
        }
    }
}
