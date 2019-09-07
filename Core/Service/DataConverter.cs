using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Service
{
    public interface IDataConverter
    {
        void Convert(List<string> cells, List<string> data);
    }

    public class DataConverter : IDataConverter
    {
        private bool IsFourthColumn(List<string> data)
        {
            return (data.Count() + 1) % Constant.NumberOfColumns == 0;
        }

        public void Convert(List<string> cells, List<string> data)
        {
            for (int index = 0; index < cells.Count; index++)
            {
                var cell = cells[index];
                if (IsFourthColumn(data))
                {
                    data.Add(ParseColorCell(cell));
                    var remainValues = cell.Trim().Split(Constant.SpaceSpertor).Skip(1).Where(t => !string.IsNullOrEmpty(t))
                        .ToList();

                    if (remainValues.Count > 0)
                        data.AddRange(remainValues);
                }
                else
                {
                    data.Add(cell.Trim());
                }
            }
        }

        private string ParseColorCell(string cell)
        {
            return cell.Trim().Split(Constant.SpaceSpertor)[0].ToString();
        }
    }
}
