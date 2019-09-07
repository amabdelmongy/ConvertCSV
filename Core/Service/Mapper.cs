using System;
using System.Collections.Generic;
using System.Linq;
using Core.Models;

namespace Core.Service
{
    public interface IMapper
    {
        List<Person> MapPersons(List<string> data);
    }

    public class Mapper : IMapper
    { 
        public List<Person> MapPersons(List<string> data)
        {
            var persons = new List<Person>();
            var index = 0;

            for (int i = 0; i < data.Count / Constant.NumberOfColumns; i++)
            {
                var person = new Person();
                person.ID = persons.Count + 1;
                person.Name = data[index + (int)Constant.ColumnIndex.Name];
                person.Lastname = data[index + (int)Constant.ColumnIndex.Lastname];
                person.Zipcode = PersonZipcode(data[index + (int) Constant.ColumnIndex.Address]);
                person.City = PersonCity(data[index + (int)Constant.ColumnIndex.Address]);
                person.Color = PersonColor(data[ index + (int)Constant.ColumnIndex.Color]);
                persons.Add(person);
                index += Constant.NumberOfColumns;
            } 
            return persons;
        }

        private Color PersonColor(string data)
        {
            return (Color) int.Parse(data);
        }

        private string PersonZipcode(string data)
        {
            return data.Split(Constant.SpaceSpertor)[0];
        }

        private string PersonCity(string data)
        {
            return String.Join(" ", data.Split(Constant.SpaceSpertor).Skip(1));
        }
    }
}