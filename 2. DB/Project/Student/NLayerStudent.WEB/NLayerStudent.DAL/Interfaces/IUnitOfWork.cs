using System;
using System.Collections.Generic;
using System.Text;
using NLayerStudent.DAL.Entities;

namespace NLayerStudent.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Phone> Phones { get;}
        IRepository<Order> Orders { get;}
        void Save();
    }
}
