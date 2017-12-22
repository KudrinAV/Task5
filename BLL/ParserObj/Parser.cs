using BLL.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ParserObj
{
    public class Parser
    {
        private SaleDTO ParseLine(string line, int id)
        {
            try
            {
                var temp = line.Split(';');
                return new SaleDTO(DateTime.Parse(temp[0]), temp[1], temp[2], Double.Parse(temp[3]), id);
            }
            catch (FormatException e)
            {
                return null;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public IList<SaleDTO> ParserCSV(string path, int id)
        {
            IList<SaleDTO> resultList = new List<SaleDTO>();
            string line;
            using (StreamReader sr = new StreamReader(path))
            {
                try
                {
                    while ((line = sr.ReadLine()) != null)
                    {
                        resultList.Add(ParseLine(line, id));
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return resultList;
        }
    }
}
