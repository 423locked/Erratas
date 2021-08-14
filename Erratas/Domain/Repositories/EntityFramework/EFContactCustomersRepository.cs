using Erratas.Domain.Entities;
using Erratas.Domain.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Erratas.Domain.Repositories.EntityFramework
{
    public class EFContactCustomersRepository : IContactCustomersRepository
    {
        public readonly AppDbContext context;
        public EFContactCustomersRepository(AppDbContext dbContext)
        {
            this.context = dbContext;
        }

        public IQueryable<ContactCustomer> GetContactCustomers()
        {
            return context.ContactCustomers;
        }

        public ContactCustomer GetContactCustomerById(Guid Id)
        {
            return context.ContactCustomers.FirstOrDefault(x => x.Id == Id);
        }

        public void SaveContactCustomer(ContactCustomer customer)
        {
            context.Entry(customer).State = EntityState.Added;
            context.SaveChanges();
        }

        public void ResolveContactCustomer(Guid id)
        {
            context.ContactCustomers.Remove(new ContactCustomer { Id = id }) ;
            context.SaveChanges();
        }
    }
}
