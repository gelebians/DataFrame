using System;
using System.Linq;
using System.Runtime.InteropServices;
using Technical.System;

namespace Technical
{
    public partial class DataFrameData
    {
        Array _data;
        public Array Değerler => _data;
        public Type Type { get; set; }
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
                throw new NotImplementedException("Unrecognized data type:("+Type.Name+") DataFrameData(Type type,int size))
        }
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
                throw new Exception("Index was outside the specified range.: DataFrameData.Add(int index,IConvertible? data)");
            }
            
        }
        public void Delete(int index)
        {
            if (index >= 0 && index < Count())
            {
                _data = _data switch
                {
                    bool?[] bool1 => General.DeleteArray(bool1,index),
                    int?[] int1 => General.DeleteArray(int1, index),
                    float?[] float1 => General.DeleteArray(float1, index),
                    double?[] double1 => General.DeleteArray(double1, index),
                    decimal?[] decimal1 => General.DeleteArray(decimal1, index),
                    DateTime?[] dateTime1 => General.DeleteArray(dateTime1, index),
                    string?[] string1 => General.DeleteArray(string1, index),
                    _ => throw new NotImplementedException("Unrecognized data type")
                };
            }
            else
            {
                throw new Exception("Index was outside the specified range.: DataFrameData.Add(int index,IConvertible? data)");
            }
        }
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
                General.Loglayıcı.Error("Unrecognized data type:(" + Type.Name + ") DataFrameData.Clear()");
        }
        public override string ToString()
        {
            string str = "DataType:" + Type.Name+" Size:"+Count()+"\nDatas:";
            str+=_data switch
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
        public DataFrameData ShiftLeft(int count=1)
        {
            Array data = _data switch
            {
                bool?[] bool1 => General.Join(new bool?[count], bool1.Take(Count() - count).ToArray()),
                int?[] int1 => General.Join(new int?[count],int1.Take(Count() - count).ToArray()),
                float?[] float1 => General.Join(new float?[count], float1.Take(Count() - count).ToArray()),
                double?[] double1 => General.Join(new double?[count], double1.Take(Count() - count).ToArray()),
                decimal?[] decimal1 => General.Join(new decimal?[count], decimal1.Take(Count() - count).ToArray()),
                DateTime?[] dateTime1 => General.Join(new DateTime?[count], dateTime1.Take(Count() - count).ToArray()),
                string?[] string1 => General.Join(new string?[count], string1.Take(Count() - count).ToArray()),
                _ => throw new NotImplementedException("Unrecognized data type")
            };

            return new DataFrameData(data);
        }
        public DataFrameData ShiftRight(int count = 1)
        {
            Array data = _data switch
            {
                bool?[] bool1 => General.Join(bool1.Skip(count).Take(Count() - count).ToArray(), new bool?[count]),
                int?[] int1 => General.Join(int1.Skip(count).Take(Count() - count).ToArray(), new int?[count]),
                float?[] float1 => General.Join(float1.Skip(count).Take(Count() - count).ToArray(), new float?[count]),
                double?[] double1 => General.Join(double1.Skip(count).Take(Count() - count).ToArray(), new double?[count]),
                decimal?[] decimal1 => General.Join(decimal1.Skip(count).Take(Count() - count).ToArray(), new decimal?[count]),
                DateTime?[] dateTime1 => General.Join(dateTime1.Skip(count).Take(Count() - count).ToArray(), new DateTime?[count]),
                string?[] string1 => General.Join(string1.Skip(count).Take(Count() - count).ToArray(), new string?[count]),
                _ => throw new NotImplementedException("Unrecognized data type")
            };

            return new DataFrameData(data);
        }
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
        public void ForEach(Action<IConvertible?> action)
        {
            if (action == null)
            {
                throw new Exception("action cannot be left blank");
            }

            for (int i = 0; i < Count(); i++)
            {
                action(this[i]);
            }
        }
    }
}
