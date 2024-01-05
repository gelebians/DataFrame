using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using Technical.System;

namespace Technical
{
    public partial class DataFrame : DynamicObject,IDictionary<string, DataFrameData>
    {
        public DataFrameData this[string column]
        {
            get
            {
                if (_columns.ContainsKey(column))
                    return _columns[column];
                else
                    return null;
            }
            set
            {
                if (_columns.Count > 0)
                {
                    if (value.Count() == _columns.First().Value.Count())
                    {
                        if (_columns.ContainsKey(column))
                        {
                            _columns[column] = value;
                        }
                        else
                            _columns.Add(column, value);
                    }
                    else
                    {
                        throw new Exception("Number of rows of data is not the same");
                    }
                }
                else
                {
                    _columns.Add(column, value);
                }
            }
        }
        public DataFrameData this[string column, int row1, int row2]
        {
            get
            {
                int rowNo1 = 0, rowno2 = 0;
                if (row1 > -1 && row1 < row2 && row2 < _columns.First().Value.Count())
                {
                    rowNo1 = row1;
                    rowno2 = row2;
                }
                else
                    throw new Exception("Row numbers are incorrect.");
                if (_columns.ContainsKey(column))
                {
                    return _columns[column][rowNo1,rowno2-rowNo1];
                }
                else
                {
                    throw new Exception("column not found.");
                }
            }
        }

        public IConvertible? this[string column, int row]
        {
            get
            {
                int rowNo = 0;
                if (row > -1 && row < _columns.First().Value.Count())
                    rowNo = row;
                else if (row == -1) //last row
                    rowNo = _columns.First().Value.Count() - 1;
                else
                    return null;
                if (_columns.ContainsKey(column))
                    return _columns[column][rowNo];
                else
                    return null;
            }
            set
            {
                int rowNo = -1;
                if (row > -1 && row < _columns.First().Value.Count())
                    rowNo = row;
                else if (row == -1) //last row
                    rowNo = _columns.First().Value.Count() - 1;
                else
                    throw new Exception("Row numbers are incorrect.");
                if (_columns.ContainsKey(column))
                    _columns[column][rowNo] = (IConvertible?)value;
                else
                    throw new Exception("column is error.");
            }
        }
        public List<IConvertible?> this[int row]
        {
            get
            {
                List<IConvertible?> values = new List<IConvertible?>();
                int rowNo = -1;
                if (row > -1 && row < _columns.Count)
                    rowNo = row;
                else if (row == -1) //last row
                    rowNo = _columns.Count - 1;
                if (rowNo > -1)
                {
                    foreach (var column in _columns)
                    {
                        values.Add(column.Value[rowNo]);
                    }
                    return values;
                }
                else
                {
                    return null;
                }

            }
        }
        public DataFrame this[string[] columnlar]
        {
            get
            {
                return new DataFrame(_columns.Values.ToList(), columnlar);
            }
        }

        public void rename(Dictionary<string, string> columnlar)
        {
            foreach (var data in columnlar)
            {
                if (_columns.ContainsKey(data.Key))
                {
                    var değer = _columns[data.Key];
                    _columns.Remove(data.Key);
                    _columns.Add(data.Value, değer);
                }
            }
        }
    }
}
