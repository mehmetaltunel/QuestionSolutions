using System.Collections.Generic;
using System.Data;
using QuestionSolutions.SharedKernel.SeedWork;

namespace QuestionSolutions.SharedKernel.Utilities
{
    public static class GenericUtil<TEntity>
    {
        public static IList<GenericClassProperties> GetGenericProperties(TEntity T)
        {
            var entityProperties = T.GetType().GetProperties();
            List<GenericClassProperties> propertiesList = new List<GenericClassProperties>();
            foreach (var property in entityProperties)
            {
                propertiesList.Add(new GenericClassProperties
                {
                    Name = property.Name,
                    Value = property.GetValue(T),
                    DbType = GetDbType(property.PropertyType.ToString()),
                });
            }
            return propertiesList;
        }

        static DbType GetDbType(string type)
        {
            switch (type)
            {
                case "System.Int64":
                    return DbType.Int64;
                break;
                case "System.String":
                    return DbType.String;
                break;
                default:
                    return DbType.String;
            }
        }
    }
}
