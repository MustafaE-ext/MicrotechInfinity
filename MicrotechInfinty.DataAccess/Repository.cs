﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace MicrotechInfinity.DataAccess
{
    public abstract class Repository
    {
        protected SqlConnection _context;
        protected SqlTransaction _transaction;

        protected SqlCommand CreateCommand(string query)
        {
            return new SqlCommand(query, _context, _transaction);
        }
    }
}
