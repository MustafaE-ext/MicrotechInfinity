﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MicrotechInfinity.Domain.Interfaces.UoW
{
    public interface IUnitOfWork
    {
        IUnitOfWorkAdapter Create();
    }
}
