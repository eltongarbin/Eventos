using AutoMapper;
using Eventos.IO.Domain.Core.Notifications;
using Eventos.IO.Domain.Eventos.Commands;
using Eventos.IO.Domain.Eventos.Repository;
using Eventos.IO.Domain.Interfaces;
using Eventos.IO.Services.Api.Controllers;
using Eventos.IO.Services.Api.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace Eventos.IO.Tests.Api.UnitTests
{
    public class EventosControllerTests
    {
        // AAA => Arrange, Act, Assert
        public EventosController eventosController;
        public Mock<DomainNotificationHandler> mockNotification;
        public Mock<IMapper> mockMapper;
        public Mock<IMediatorHandler> mockMediator;

        public EventosControllerTests()
        {
            mockNotification = new Mock<DomainNotificationHandler>();
            mockMapper = new Mock<IMapper>();
            mockMediator = new Mock<IMediatorHandler>();

            var mockUser = new Mock<IUser>();
            var mockRepository = new Mock<IEventoRepository>();

            eventosController = new EventosController(mockNotification.Object,
                                                      mockUser.Object,
                                                      mockMediator.Object,
                                                      mockRepository.Object,
                                                      mockMapper.Object);
        }

        [Fact]
        public void EventosController_RegistrarEvento_RetornarComSucesso()
        {
            // Arrange
            var eventoViewModel = new EventoViewModel();
            var eventoCommand = new RegistrarEventoCommand("Teste",
                                                           "",
                                                           "",
                                                           DateTime.Now,
                                                           DateTime.Now.AddDays(1),
                                                           true,
                                                           0,
                                                           true,
                                                           "",
                                                           Guid.NewGuid(),
                                                           Guid.NewGuid(),
                                                           new IncluirEnderecoEventoCommand(Guid.NewGuid(),
                                                                                            "",
                                                                                            null,
                                                                                            "",
                                                                                            "",
                                                                                            "",
                                                                                            "",
                                                                                            "",
                                                                                            null));

            mockMapper.Setup(m => m.Map<RegistrarEventoCommand>(eventoViewModel)).Returns(eventoCommand);
            mockNotification.Setup(m => m.GetNotifications()).Returns(new List<DomainNotification>());

            // Act
            var result = eventosController.Post(eventoViewModel);

            // Assert
            mockMediator.Verify(m => m.EnviarComando(eventoCommand), Times.Once);
            Assert.IsType<OkObjectResult>(result);
        }
    }
}
