using creditoautomotriz.Entities.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace creditoautomotriz.Infrastructure.Utils
{
    public class ImportarCsv
    {
        #region Attributos
        private List<Cliente> lines = new List<Cliente>();
        #endregion
        public void Import(string filename)
        {
            try
            {
                using (var fs = new StreamReader(filename))
                {
                    lines = new CsvHelper.CsvReader((CsvHelper.IParser)fs).GetRecords<Cliente>().ToList();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
