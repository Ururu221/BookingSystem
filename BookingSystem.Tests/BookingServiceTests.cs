using BookingSystem_web_api.Models;
using BookingSystem_web_api.Repositories.Interfaces;
using BookingSystem_web_api.Services;
using Moq;
using Xunit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public class BookingServiceTests
{
    [Fact]
    public async Task UpdateRoomAsync_ShouldUpdateRoom_WhenRoomExists()
    {
        // Arrange
        var roomId = Guid.NewGuid();
        var updatedRoom = new RoomModel
        {
            Id = roomId,
            RoomType = "Conference",
            HumanCapacity = 12,
            Address = "New Address",
            IsAvailable = true
        };

        var roomRepoMock = new Mock<IRoomRepository>();

        roomRepoMock.Setup(r => r.UpdateRoomAsync(It.IsAny<RoomModel>()))
                    .ReturnsAsync((RoomModel r) => r);

        var bookingService = new BookingService(roomRepoMock.Object, null);

        // Act
        var result = await bookingService.UpdateRoomAsync(updatedRoom);

        // Assert
        Assert.Equal(updatedRoom.Address, result.Address);
        Assert.Equal(updatedRoom.HumanCapacity, result.HumanCapacity);
        Assert.Equal(updatedRoom.IsAvailable, result.IsAvailable);

        roomRepoMock.Verify(r => r.UpdateRoomAsync(updatedRoom), Times.Once);
    }

    [Fact]
    public async Task BookRoomAsync_ShouldCreateReservation_WhenRoomExists()
    {
        // Arrange
        var roomId = Guid.NewGuid();
        var room = new RoomModel
        {
            Id = roomId,
            RoomType = "Bedroom",
            HumanCapacity = 2,
            Address = "Test Address",
            IsAvailable = true,
            Reservation = new List<Reservation>()
        };

        // Создаем объект бронирования (без Id, его сгенерирует сервис)
        var reservation = new Reservation
        {
            From = DateTime.Now.AddHours(1),
            To = DateTime.Now.AddHours(2)
        };

        // Моки репозиториев
        var roomRepoMock = new Mock<IRoomRepository>();
        var reservationRepoMock = new Mock<IBookingRepository>();

        // Возвращаем комнату по roomId
        roomRepoMock.Setup(r => r.GetByIdAsync(roomId)).ReturnsAsync(room);
        // Настраиваем GetAllAsync для бронирований так, чтобы проверка доступности работала (пустой список)
        reservationRepoMock.Setup(r => r.GetAllAsync())
                           .ReturnsAsync(new List<Reservation>());
        // Настраиваем создание бронирования: возвращаем переданное бронирование
        reservationRepoMock.Setup(r => r.CreateReservationAsync(It.IsAny<Reservation>()))
                           .ReturnsAsync((Reservation res) => res);
        // Настраиваем обновление комнаты: возвращаем объект, который передали
        roomRepoMock.Setup(r => r.UpdateRoomAsync(It.IsAny<RoomModel>()))
                    .ReturnsAsync((RoomModel r) => r);

        // Создаем сервис с переданными моками
        var bookingService = new BookingService(roomRepoMock.Object, reservationRepoMock.Object);

        // Act
        var updatedRoom = await bookingService.BookRoomAsync(roomId, reservation);

        // Проверяем, что методы создания бронирования и обновления комнаты были вызваны ровно один раз
        reservationRepoMock.Verify(r => r.CreateReservationAsync(It.Is<Reservation>(res => res.RoomId == roomId)), Times.Once);
        roomRepoMock.Verify(r => r.UpdateRoomAsync(It.IsAny<RoomModel>()), Times.Once);
    }


}
