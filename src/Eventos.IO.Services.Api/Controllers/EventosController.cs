using AutoMapper;
using Eventos.IO.Domain.Core.Bus;
using Eventos.IO.Domain.Core.Notifications;
using Eventos.IO.Domain.Eventos.Commands;
using Eventos.IO.Domain.Eventos.Repository;
using Eventos.IO.Domain.Interfaces;
using Eventos.IO.Services.Api.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Eventos.IO.Services.Api.Controllers
{
    public class EventosController : BaseController
    {
        private readonly IBus _bus;
        private readonly IEventoRepository _eventoRepository;
        private readonly IMapper _mapper;

        public EventosController(IDomainNotificationHandler<DomainNotification> notifications,
                                 IUser user,
                                 IBus bus,
                                 IEventoRepository eventoRepository,
                                 IMapper mapper)
            : base(notifications, user, bus)
        {
            _eventoRepository = eventoRepository;
            _mapper = mapper;
            _bus = bus;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("eventos")]
        public IEnumerable<EventoViewModel> Get()
        {
            return _mapper.Map<IEnumerable<EventoViewModel>>(_eventoRepository.ObterTodos());
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("eventos/{id:guid}")]
        public EventoViewModel Get(Guid id, int version)
        {
            return _mapper.Map<EventoViewModel>(_eventoRepository.ObterPorId(id));
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("eventos/categorias")]
        public IEnumerable<CategoriaViewModel> ObterCategorias()
        {
            return _mapper.Map<IEnumerable<CategoriaViewModel>>(_eventoRepository.ObterCategorias());
        }

        [HttpGet]
        [Authorize(Policy = "PodeLerEventos")]
        [Route("eventos/meus-eventos")]
        public IEnumerable<EventoViewModel> ObterMeusEventos()
        {
            return _mapper.Map<IEnumerable<EventoViewModel>>(_eventoRepository.ObterEventoPorOrganizador(OrganizadorId));
        }

        [HttpPost]
        [Authorize(Policy = "PodeGravar")]
        [Route("eventos")]
        public IActionResult Post([FromBody] EventoViewModel eventoViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotificarErroModelInvalida();
                return Response();
            }

            var eventoCommand = _mapper.Map<RegistrarEventoCommand>(eventoViewModel);
            _bus.SendCommand(eventoCommand);

            return Response(eventoCommand);
        }

        [HttpPut]
        [Authorize(Policy = "PodeGravar")]
        [Route("eventos")]
        public IActionResult Put([FromBody] EventoViewModel eventoViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotificarErroModelInvalida();
                return Response();
            }

            var atualizarEventoCommand = _mapper.Map<AtualizarEventoCommand>(eventoViewModel);
            _bus.SendCommand(atualizarEventoCommand);

            return Response(eventoViewModel);
        }

        [HttpDelete]
        [Authorize(Policy = "PodeGravar")]
        [Route("eventos/{id:guid}")]
        public IActionResult Delete(Guid id)
        {
            _bus.SendCommand(new ExcluirEventoCommand(id));

            return Response();
        }
    }
}