using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Service
{
    public class Constant
    {
        internal const string CellSpertor = ",";
        internal const string SpaceSpertor = " ";
        internal const int NumberOfColumns = 4;

        internal enum ColumnIndex
        {
            Name = 0,
            Lastname,
            Address,
            Color
        }
    }
}
