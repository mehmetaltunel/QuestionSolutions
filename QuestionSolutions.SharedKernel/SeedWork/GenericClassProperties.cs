using System;
using System.Data;

namespace QuestionSolutions.SharedKernel.SeedWork
{
    public class GenericClassProperties
    {
        public string Name { get; set; }
        public object Value { get; set; }
        public DbType DbType { get; set; }
    }
}

