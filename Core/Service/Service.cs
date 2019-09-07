using System;
using System.Collections.Generic;
using System.Linq; 
using Core.Models; 

namespace Core.Service
{
    public interface IService
    { 
        IList<Person> Get(string path);
        Person GetById(string path, int id);
        List<Person> GetByColor(string path, Color color);
    }

    public class Service : IService
    { 
        private readonly IParser _parser;

        public Service(IParser parser)
        { 
            _parser = parser;
        }

        public IList<Person> Get(string path)
        {
            //ToDo Cache all rows at Database and read every time from Database
            //ToDo update Cache table in Database when CSV file change
            return _parser.ParseCSV(path);
        }

        public Person GetById(string path,int id)
        { 
            var psersons = Get(path);
            return psersons.FirstOrDefault(t=>t.ID == id);
        }

        public List<Person> GetByColor(string path, Color color)
        {            
            var psersons = Get(path);
            return psersons.Where(t => t.Color == color).ToList();
        }

    }
}