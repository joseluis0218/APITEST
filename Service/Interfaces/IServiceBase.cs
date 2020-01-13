﻿using Common.HttpHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IServiceBase<T>
    {
        EResponseBase<T> Get();
        EResponseBase<T> GetByID(int ID);
        EResponseBase<T> Insert(T model);
        EResponseBase<T> Update(T model);
        EResponseBase<T> Delete(int ID);



    }
}
