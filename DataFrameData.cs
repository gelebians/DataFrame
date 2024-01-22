using ISRA.System;
using System;

namespace ISRA.Data
{
    /*
     * This application is for implementing pandas dataframe in c#.
     * There are DataFrameData constructor in the DataFrameData.cs file.
     * This library was designed by PoSeYDoN.
     */
    /// <summary>
    /// Data class used for DataFrame
    /// </summary>
    public partial class DataFrameData
    {
        Array _data;
        /// <summary>
        /// Array of values
        /// </summary>
        public Array Values => _data;
        /// <summary>
        /// DataFrameData type of data of the data
        /// </summary>
        public Type Type { get; set; }
        /// <summary>
        /// Create by specifying type and size
        /// </summary>
        /// <param name="type"> data type</param>
        /// <param name="size"> datas size</param>
        public DataFrameData(Type type,int size)
        {
            Type = type;
            if (Type == typeof(bool))
                _data = new bool?[size];
            else if (Type == typeof(int))
                _data = new int?[size];
            else if (Type == typeof(float))
                _data = new float?[size];
            else if (Type == typeof(double))
                _data = new double?[size];
            else if (Type == typeof(decimal))
                _data = new decimal?[size];
            else if (Type == typeof(DateTime))
                _data = new DateTime?[size];
            else if (Type == typeof(string))
                _data = new string?[size];
            else
                General.Logging.Error("Unrecognized data type:(" + Type.Name + ") DataFrameData(Type type,int size)");
        }
        
        /// <summary>
        /// Creating DataFrameData with array
        /// </summary>
        /// <param name="data">Array of data</param>
        /// <exception cref="NotImplementedException"></exception>
        public DataFrameData(Array data)
        {
            _data = data;
            Type = data switch
            {
                bool?[] bool1 => typeof(bool),
                int?[] int1 => typeof(int),
                float?[] float1 => typeof(float),
                double?[] double1 => typeof(double),
                decimal?[] decimal1 => typeof(decimal),
                DateTime?[] dateTime1 => typeof(DateTime),
                string?[] string1 => typeof(string),
                _ => throw new NotImplementedException("Unrecognized data type")
            };
        }
        /// <summary>
        /// Add new data
        /// </summary>
        /// <param name="data">Data to add</param>
        /// <exception cref="NotImplementedException">Data type error</exception>
        public void Add(IConvertible? data)
        {
            _data = _data switch
            {
                bool?[] bool1 => General.AddArray(bool1,data),
                int?[] int1 => General.AddArray(int1, data),
                float?[] float1 => General.AddArray(float1, data),
                double?[] double1 => General.AddArray(double1, data),
                decimal?[] decimal1 => General.AddArray(decimal1, data),
                DateTime?[] dateTime1 => General.AddArray(dateTime1, data),
                string?[] string1 => General.AddArray(string1, data),
                _ => throw new NotImplementedException("Unrecognized data type")
            };
        }
        public void Add(int index,IConvertible? data)
        {
            if (index >= 0 && index < Count())
            {
                _data = _data switch
                {
                    bool?[] bool1 => General.AddArray(bool1,index,data),
                    int?[] int1 => General.AddArray(int1, index, data),
                    float?[] float1 => General.AddArray(float1, index, data),
                    double?[] double1 => General.AddArray(double1, index, data),
                    decimal?[] decimal1 => General.AddArray(decimal1, index, data),
                    DateTime?[] dateTime1 => General.AddArray(dateTime1, index, data),
                    string?[] string1 => General.AddArray(string1, index, data),
                    _ => throw new NotImplementedException("Unrecognized data type")
                };
            }
            else
            {
                General.Logging.Error("Index was outside the specified range.: DataFrameData.Add(int index,IConvertible? data)");
            }
            
        }
        /// <summary>
        /// Deleting data given with index number
        /// </summary>
        /// <param name="index"> index number</param>
        /// <exception cref="NotImplementedException"></exception>
        public void Delete(int index)
        {
            if (index >= 0 && index < Count())
            {
                _data = _data switch
                {
                    bool?[] bool1 => General.RemoveArray(bool1,index),
                    int?[] int1 => General.RemoveArray(int1, index),
                    float?[] float1 => General.RemoveArray(float1, index),
                    double?[] double1 => General.RemoveArray(double1, index),
                    decimal?[] decimal1 => General.RemoveArray(decimal1, index),
                    DateTime?[] dateTime1 => General.RemoveArray(dateTime1, index),
                    string?[] string1 => General.RemoveArray(string1, index),
                    _ => throw new NotImplementedException("Unrecognized data type")
                };
            }
            else
            {
                General.Logging.Error("Index was outside the specified range.: DataFrameData.Add(int index,IConvertible? data)");
            }
        }
        /// <summary>
        /// Clear all data
        /// </summary>
        public void Clear()
        {
            if (Type == typeof(bool))
                _data = new bool?[Count()];
            else if (Type == typeof(int))
                _data = new int?[Count()];
            else if (Type == typeof(float))
                _data = new float?[Count()];
            else if (Type == typeof(double))
                _data = new double?[Count()];
            else if (Type == typeof(decimal))
                _data = new decimal?[Count()];
            else if (Type == typeof(DateTime))
                _data = new DateTime?[Count()];
            else if (Type == typeof(string))
                _data = new string?[Count()];
            else
                General.Logging.Error("Unrecognized data type:(" + Type.Name + ") DataFrameData.Clear()");
        }
        /// <summary>
        /// Converts data to string in tabular form
        /// </summary>
        /// <returns> string</returns>
        /// <exception cref="NotImplementedException"></exception>
        public override string ToString()
        {
            string str = "DataType:" + Type.Name + " Size:" + Count() + "\nDatas:";
            str += _data switch
            {
                bool?[] bool1 => string.Join(",", bool1),
                int?[] int1 => string.Join(",", int1),
                float?[] float1 => string.Join(",", float1),
                double?[] double1 => string.Join(",", double1),
                decimal?[] decimal1 => string.Join(",", decimal1),
                DateTime?[] dateTime1 => string.Join(",", dateTime1),
                string?[] string1 => string.Join(",", string1),
                _ => throw new NotImplementedException("Unrecognized data type")
            };
            return str;
        }
        /// <summary>
        /// Shifts the array to the left by the given number. Initial values ​​are assigned as null
        /// </summary>
        /// <param name="counter"> number to shift left</param>
        /// <returns>DataFrameData</returns>
        /// <exception cref="NotImplementedException"></exception>
        public DataFrameData ShiftLeft(int counter=1)
        {
            Array data = _data switch
            {
                bool?[] bool1 => General.ArrayJoin(new bool?[counter], bool1.Take(Count() - counter).ToArray()),
                int?[] int1 => General.ArrayJoin(new int?[counter],int1.Take(Count() - counter).ToArray()),
                float?[] float1 => General.ArrayJoin(new float?[counter], float1.Take(Count() - counter).ToArray()),
                double?[] double1 => General.ArrayJoin(new double?[counter], double1.Take(Count() - counter).ToArray()),
                decimal?[] decimal1 => General.ArrayJoin(new decimal?[counter], decimal1.Take(Count() - counter).ToArray()),
                DateTime?[] dateTime1 => General.ArrayJoin(new DateTime?[counter], dateTime1.Take(Count() - counter).ToArray()),
                string?[] string1 => General.ArrayJoin(new string?[counter], string1.Take(Count() - counter).ToArray()),
                _ => throw new NotImplementedException("Unrecognized data type")
            };

            return new DataFrameData(data);
        }
        /// <summary>
        /// Shifts the array to the right by the given number. Initial values ​​are assigned as null
        /// </summary>
        /// <param name="counter">number to shift right</param>
        /// <returns>DataFrameData</returns>
        /// <exception cref="NotImplementedException"></exception>
        public DataFrameData ShiftRight(int counter = 1)
        {
            Array data = _data switch
            {
                bool?[] bool1 => General.ArrayJoin(bool1.Skip(counter).Take(Count() - counter).ToArray(), new bool?[counter]),
                int?[] int1 => General.ArrayJoin(int1.Skip(counter).Take(Count() - counter).ToArray(), new int?[counter]),
                float?[] float1 => General.ArrayJoin(float1.Skip(counter).Take(Count() - counter).ToArray(), new float?[counter]),
                double?[] double1 => General.ArrayJoin(double1.Skip(counter).Take(Count() - counter).ToArray(), new double?[counter]),
                decimal?[] decimal1 => General.ArrayJoin(decimal1.Skip(counter).Take(Count() - counter).ToArray(), new decimal?[counter]),
                DateTime?[] dateTime1 => General.ArrayJoin(dateTime1.Skip(counter).Take(Count() - counter).ToArray(), new DateTime?[counter]),
                string?[] string1 => General.ArrayJoin(string1.Skip(counter).Take(Count() - counter).ToArray(), new string?[counter]),
                _ => throw new NotImplementedException("Unrecognized data type")
            };

            return new DataFrameData(data);
        }
        /// <summary>
        /// Returns the index number of the given data
        /// </summary>
        /// <param name="data">Data to be indexed</param>
        /// <returns>int</returns>
        public int index(IConvertible? data)
        {
            int indx = _data switch
            {
                bool?[] bool1 => (bool1.Contains((bool)data)) ? Array.IndexOf(bool1, data) : -1,
                int?[] int1 => (int1.Contains((int)data)) ? Array.IndexOf(int1, data) : -1,
                float?[] float1 => (float1.Contains((float)data)) ? Array.IndexOf(float1, data) : -1,
                double?[] double1 => (double1.Contains((double)data)) ? Array.IndexOf(double1, data) : -1,
                decimal?[] decimal1 => (decimal1.Contains((decimal)data)) ? Array.IndexOf(decimal1, data) : -1,
                DateTime?[] dateTime1 => (dateTime1.Contains((DateTime)data)) ? Array.IndexOf(dateTime1, data) : -1,
                string?[] string1 => (string1.Contains((string)data)) ? Array.IndexOf(string1, data) : -1,
                _ => -1
            };
            return indx;
        }
        /// <summary>
        /// Foreach method used in the list method
        /// </summary>
        /// <param name="action">Method to run</param>
        public void ForEach(Action<IConvertible?> action)
        {
            if (action == null)
            {
                General.Logging.Error("Index was outside the specified range.: DataFrameData.ForEach(Action<T>)");
            }

            for (int i = 0; i < Count(); i++)
            {
                action(this[i]);
            }
        }
        public DataFrameData Short(ShortSide side=ShortSide.Asc)
        {
            return _data switch
            {
                bool?[] bool1 => new DataFrameData((side == ShortSide.Asc) ? bool1.OrderBy(x => x).ToArray() : bool1.OrderByDescending(x => x).ToArray()),
                int?[] int1 => new DataFrameData((side == ShortSide.Asc) ? int1.OrderBy(x => x).ToArray() : int1.OrderByDescending(x => x).ToArray()),
                float?[] float1 => new DataFrameData((side == ShortSide.Asc) ? float1.OrderBy(x => x).ToArray() : float1.OrderByDescending(x => x).ToArray()),
                double?[] double1 => new DataFrameData((side == ShortSide.Asc) ? double1.OrderBy(x => x).ToArray() : double1.OrderByDescending(x => x).ToArray()),
                decimal?[] decimal1 => new DataFrameData((side == ShortSide.Asc) ? decimal1.OrderBy(x => x).ToArray() : decimal1.OrderByDescending(x => x).ToArray()),
                DateTime?[] dateTime1 => new DataFrameData((side == ShortSide.Asc) ? dateTime1.OrderBy(x => x).ToArray() : dateTime1.OrderByDescending(x => x).ToArray()),
                string?[] string1 => new DataFrameData((side == ShortSide.Asc) ? string1.OrderBy(x => x).ToArray() : string1.OrderByDescending(x => x).ToArray()),
                _ => throw new NotImplementedException("Unrecognized data type")
            };
        }
        
    }
}
