﻿using Eventos.IO.Domain.Core.Notifications;
using Eventos.IO.Domain.Eventos.Events;
using Eventos.IO.Domain.Eventos.Repository;
using Eventos.IO.Domain.Handlers;
using Eventos.IO.Domain.Interfaces;
using MediatR;
using System;

namespace Eventos.IO.Domain.Eventos.Commands
{
    public class EventoCommandHandler : CommandHandler,
        INotificationHandler<RegistrarEventoCommand>,
        INotificationHandler<AtualizarEventoCommand>,
        INotificationHandler<ExcluirEventoCommand>,
        INotificationHandler<IncluirEnderecoEventoCommand>,
        INotificationHandler<AtualizarEnderecoEventoCommand>
    {
        private readonly IEventoRepository _eventoRepository;
        private readonly IMediatorHandler _mediator;
        private readonly IUser _user;

        public EventoCommandHandler(IEventoRepository eventoRepository,
                                    IUnitOfWork uow,
                                    IMediatorHandler mediator,
                                    INotificationHandler<DomainNotification> notifications,
                                    IUser user)
            : base(uow, mediator, notifications)
        {
            _eventoRepository = eventoRepository;
            _mediator = mediator;
            _user = user;
        }

        public void Handle(RegistrarEventoCommand message)
        {
            var endereco = new Endereco(message.Endereco.Id, 
                                        message.Endereco.Logradouro, 
                                        message.Endereco.Numero, 
                                        message.Endereco.Complemento,
                                        message.Endereco.Bairro,
                                        message.Endereco.CEP,
                                        message.Endereco.Cidade,
                                        message.Endereco.Estado,
                                        message.Endereco.EventoId.Value);

            var evento = Evento.EventoFactory.NovoEventoCompleto(message.Id,
                                                                 message.Nome,
                                                                 message.DescricaoCurta,
                                                                 message.DescricaoLonga,
                                                                 message.DataInicio,
                                                                 message.DataFim,
                                                                 message.Gratuito,
                                                                 message.Valor,
                                                                 message.Online,
                                                                 message.NomeEmpresa,
                                                                 message.OrganizadorId,
                                                                 endereco,
                                                                 message.CategoriaId);

            if (!EventoValido(evento)) return;

            // TODO:
            // Validações de negócio!
            // Organizador pode registrar evento?

            _eventoRepository.Adicionar(evento);

            if (Commit())
            {
                _mediator.PublicarEvento(new EventoRegistradoEvent(evento.Id,
                                                          evento.Nome,
                                                          evento.DataInicio,
                                                          evento.DataFim,
                                                          evento.Gratuito,
                                                          evento.Valor,
                                                          evento.Online,
                                                          evento.NomeEmpresa));
            }
        }

        public void Handle(AtualizarEventoCommand message)
        {
            var eventoAtual = _eventoRepository.ObterPorId(message.Id);

            if (!EventoExistente(message.Id, message.MessageType))
                return;

            if (eventoAtual.OrganizadorId != _user.GetUserId())
            {
                _mediator.PublicarEvento(new DomainNotification(message.MessageType, "Evento não pertencente ao Organizador"));
                return;
            }

            var evento = Evento.EventoFactory.NovoEventoCompleto(message.Id,
                                                                 message.Nome,
                                                                 message.DescricaoCurta,
                                                                 message.DescricaoLonga,
                                                                 message.DataInicio,
                                                                 message.DataFim,
                                                                 message.Gratuito,
                                                                 message.Valor,
                                                                 message.Online,
                                                                 message.NomeEmpresa,
                                                                 message.OrganizadorId,
                                                                 eventoAtual.Endereco,
                                                                 message.CategoriaId);

            if (!evento.Online && evento.Endereco == null)
            {
                _mediator.PublicarEvento(new DomainNotification(message.MessageType, "Não é possível atualizar um evento sem informar o endereço."));
                return;
            }

            if (!EventoValido(evento))
                return;

            _eventoRepository.Atualizar(evento);

            if (Commit())
            {
                _mediator.PublicarEvento(new EventoAtualizadoEvent(evento.Id, 
                                                          evento.Nome, 
                                                          evento.DescricaoCurta, 
                                                          evento.DescricaoLonga, 
                                                          evento.DataInicio, 
                                                          evento.DataFim, 
                                                          evento.Gratuito, 
                                                          evento.Valor, 
                                                          evento.Online, 
                                                          evento.NomeEmpresa));
            }
        }

        public void Handle(ExcluirEventoCommand message)
        {
            if (!EventoExistente(message.Id, message.MessageType))
                return;

            var eventoAtual = _eventoRepository.ObterPorId(message.Id);
            if (eventoAtual.OrganizadorId != _user.GetUserId())
            {
                _mediator.PublicarEvento(new DomainNotification(message.MessageType, "Evento não pertencente ao Organizador"));
                return;
            }
            // TODO: Validações de negócio
            eventoAtual.ExcluirEvento();

            _eventoRepository.Atualizar(eventoAtual);

            if (Commit())
                _mediator.PublicarEvento(new EventoExcluidoEvent(message.Id));
        }

        private bool EventoValido(Evento evento)
        {
            if (evento.EhValido())
                return true;

            NotificarValidacoesErro(evento.ValidationResult);
            return false;
        }

        private bool EventoExistente(Guid id, string messageType)
        {
            var evento = _eventoRepository.ObterPorId(id);

            if (evento != null)
                return true;

            _mediator.PublicarEvento(new DomainNotification(messageType, "Evento não encontrado."));
            return false;
        }

        public void Handle(IncluirEnderecoEventoCommand message)
        {
            var endereco = new Endereco(message.Id, 
                                        message.Logradouro, 
                                        message.Numero, 
                                        message.Complemento, 
                                        message.Bairro, 
                                        message.CEP, 
                                        message.Cidade, 
                                        message.Estado, 
                                        message.EventoId.Value);
            if (!endereco.EhValido())
            {
                NotificarValidacoesErro(endereco.ValidationResult);
                return;
            }

            _eventoRepository.AdicionarEndereco(endereco);

            if (Commit())
            {
                _mediator.PublicarEvento(new EnderecoEventoAdicionadoEvent(endereco.Id,
                                                                  endereco.Logradouro,
                                                                  endereco.Numero,
                                                                  endereco.Complemento,
                                                                  endereco.Bairro,
                                                                  endereco.CEP,
                                                                  endereco.Cidade,
                                                                  endereco.Estado,
                                                                  endereco.EventoId.Value));
            }
        }

        public void Handle(AtualizarEnderecoEventoCommand message)
        {
            var endereco = new Endereco(message.Id,
                                        message.Logradouro,
                                        message.Numero,
                                        message.Complemento,
                                        message.Bairro,
                                        message.CEP,
                                        message.Cidade,
                                        message.Estado,
                                        message.EventoId.Value);
            if (!endereco.EhValido())
            {
                NotificarValidacoesErro(endereco.ValidationResult);
                return;
            }

            _eventoRepository.AtualizarEndereco(endereco);

            if (Commit())
            {
                _mediator.PublicarEvento(new EnderecoEventoAtualizadoEvent(endereco.Id,
                                                                  endereco.Logradouro,
                                                                  endereco.Numero,
                                                                  endereco.Complemento,
                                                                  endereco.Bairro,
                                                                  endereco.CEP,
                                                                  endereco.Cidade,
                                                                  endereco.Estado,
                                                                  endereco.EventoId.Value));
            }
        }
    }
}