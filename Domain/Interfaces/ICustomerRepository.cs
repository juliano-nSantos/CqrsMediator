using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ICustomerRepository
    {
        Task<Customer> GetById(int id);
        Task<Customer> GetByEmail(string email);
        Task<IEnumerable<Customer>> GetAll();

        void Add(Customer customer);
        void Update(Customer customer);
        void Remove(Customer customer);
    }
}
