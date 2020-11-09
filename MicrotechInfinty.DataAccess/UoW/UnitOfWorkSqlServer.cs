using AutoMapper.Configuration;
using MicrotechInfinity.Domain.Interfaces.UoW;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicrotechInfinity.DataAccess.UoW
{
    public class UnitOfWorkSqlServer : IUnitOfWork
    {
        private readonly IConfiguration _configuration;

        public UnitOfWorkSqlServer(IConfiguration configuration = null)
        {
            _configuration = configuration;
        }

        public IUnitOfWorkAdapter Create()
        {
            var connectionString = _configuration == null
                ? Parameters.ConnectionString
                : _configuration.GetValue<string>("SqlConnectionString");

            return new UnitOfWorkSqlServerAdapter(connectionString);
        }
    }
}
