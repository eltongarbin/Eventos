﻿using System;

namespace Eventos.IO.Domain.Eventos.Commands
{
    public class RegistrarEventoCommand : BaseEventoCommand
    {
        public IncluirEnderecoEventoCommand Endereco { get; private set; }

        public RegistrarEventoCommand(string nome,
                                      string descricaoCurta,
                                      string descricaoLonga,
                                      DateTime dataInicio,
                                      DateTime dataFim,
                                      bool gratuito,
                                      decimal valor,
                                      bool online,
                                      string nomeEmpresa,
                                      Guid organizadorId,
                                      Guid categoriaId,
                                      IncluirEnderecoEventoCommand endereco)
        {
            Nome = nome;
            DescricaoCurta = descricaoCurta;
            DescricaoLonga = descricaoLonga;
            DataInicio = dataInicio;
            DataFim = dataFim;
            Gratuito = gratuito;
            Valor = valor;
            Online = online;
            NomeEmpresa = nomeEmpresa;
            OrganizadorId = organizadorId;
            CategoriaId = categoriaId;
            Endereco = endereco;
        }
    }
}
