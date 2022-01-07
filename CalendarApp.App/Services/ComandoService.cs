using CalendarApp.App.Interfaces;
using CalendarApp.Domain.Interfaces;
using CalendarApp.Models.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalendarApp.App.Services
{
    public class ComandoService : IComando
    {
        private IComandoRepositorio _ComandoRepositorio;

        public ComandoService(IComandoRepositorio ComandoRepositorio)
        {
            _ComandoRepositorio = ComandoRepositorio;
        }

        public List<Comando> Listar(Comando comando)
        {
            try
            {
                return _ComandoRepositorio.Listar(comando);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int Salvar(Comando comando)
        {
            try
            {
                return _ComandoRepositorio.Salvar(comando);
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
