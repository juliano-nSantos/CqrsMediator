using Domain.Entities;
using Domain.Interfaces;
using Infra.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        protected readonly AppDbContext _db;

        public CustomerRepository(AppDbContext context)
        {
            _db = context;
        }

        public void Add(Customer customer)
        {
            _db.Customers.Add(customer);
            _db.SaveChanges();
        }

        public async Task<IEnumerable<Customer>> GetAll()
        {
            return await _db.Customers.ToListAsync();
        }

        public async Task<Customer> GetByEmail(string email)
        {
            return await _db.Customers.AsNoTracking().FirstOrDefaultAsync(c => c.Email == email);
        }

        public async Task<Customer> GetById(int id)
        {
            return await _db.Customers.FindAsync(id);
        }

        public void Remove(Customer customer)
        {
            _db.Customers.Remove(customer);
            _db.SaveChanges();
        }

        public void Update(Customer customer)
        {
            _db.Customers.Update(customer);
            _db.SaveChanges();
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
