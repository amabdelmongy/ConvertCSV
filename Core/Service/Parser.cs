using Core.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Core.Service
{
    public interface IParser
    {
        IList<Person> ParseCSV(string path);
    }
     
    public partial class Parser : IParser
    {
        public IFileManager _fileManager;
        private readonly IDataConverter _dataConverter;
        private readonly IMapper _mapper;

        public Parser(IFileManager fileManager, IDataConverter dataConverter, IMapper mapper)
        {
            _fileManager = fileManager;
            _dataConverter = dataConverter;
            _mapper = mapper;
        }
         
        public IList<Person> ParseCSV(string path)
        {
            var lines = _fileManager.ReadFile(path);
            var data = new List<string>();
            foreach (var line in lines)
            { 
                var cells = (line).Split(Constant.CellSpertor).Where(t => !string.IsNullOrEmpty(t)).ToList();
                _dataConverter.Convert(cells, data);
            } 
            return _mapper.MapPersons(data);
        }
    }


}