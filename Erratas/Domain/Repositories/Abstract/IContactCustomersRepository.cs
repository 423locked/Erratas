using Erratas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Erratas.Domain.Repositories.Abstract
{
    public interface IContactCustomersRepository
    {
        IQueryable<ContactCustomer> GetContactCustomers();
        ContactCustomer GetContactCustomerById(Guid Id);
        void SaveContactCustomer(ContactCustomer customer);
        void ResolveContactCustomer(Guid id);
    }
}
