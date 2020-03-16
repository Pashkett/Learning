using System;
using System.Collections.Generic;
using System.Text;
using Contracts;
using Entities;

namespace Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private RepositoryContext repositoryContext;
        private ICompanyRepository companyRepository;
        private IEmployeeRepository employeeRepository;

        public RepositoryManager(RepositoryContext repositoryContext)
        {
            this.repositoryContext = repositoryContext;
        }

        public ICompanyRepository Company
        {
            get
            {
                if (companyRepository == null)
                    companyRepository = new CompanyRepository(repositoryContext);

                return companyRepository;
            }
        }

        public IEmployeeRepository Employee
        {
            get
            {
                if (employeeRepository == null)
                    employeeRepository = new EmployeeRepository(repositoryContext);

                return employeeRepository;
            }
        }

        public void Save() => repositoryContext.SaveChanges();
    }
}
