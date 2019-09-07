using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models;
using Core.Repository;
using System.IO;
using System.Xml.Xsl;

namespace DAL
{
    public class Repository : IRepository
    {
        //Todo Add new table in database using entity frame work that using as cache table 
        //Map all data from CSV to this Table
        //With first request after change the file update the table with new data

        public string Get()
        {
            return "";
        } 

      
    }
}
