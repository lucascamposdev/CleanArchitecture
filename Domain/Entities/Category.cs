﻿using Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public sealed class Category : Entity
    {
        public string Name { get; private set; }

        public ICollection<Product> Products { get; set; }

        public Category(string name) { 
            ValidateDomain(name);    
        }

        public Category(int id, string name) {
            ValidateDomain(name);
            Id = id;
        }

        public void Update (string name)
        {
            ValidateDomain (name);
        }

        private void ValidateDomain(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name),
                "Invalid Name, Name is required.");

            DomainExceptionValidation.When(name.Length < 3,
                "Name is too short.");

            this.Name = name;
        }
    }
}
