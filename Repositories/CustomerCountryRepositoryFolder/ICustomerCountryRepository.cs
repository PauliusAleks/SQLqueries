﻿using Assignment2_BackEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2_BackEnd.Repositories.CustomerCountryRepositoryFolder
{
    public interface ICustomerCountryRepository
    {
        public List<CustomerCountry> GetCountryNames();
    }
}
