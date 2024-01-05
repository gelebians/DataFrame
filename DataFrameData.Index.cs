using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Technical.System;

namespace Technical
{
    public partial class DataFrameData
    {
        public IConvertible? this[int index]
        {
            get
            {
                if (index < this.Count() && index >= 0)
                {
                    return _data switch
                    {
                        bool?[] bool1 => bool1[index],
                        int?[] int1 => int1[index],
                        float?[] float1 => float1[index],
                        double?[] double1 => double1[index],
                        decimal?[] decimal1 => decimal1[index],
                        DateTime?[] dateTime1 => dateTime1[index],
                        string?[] string1 => string1[index],
                        _ => throw new NotImplementedException("Unrecognized data type")
                    };
                }
                else
                {
                    Genel.Loglayıcı.Error("Index belirtilen aralık dışındaydı.: DataFrameData.this[int index]");
                    return null;
                }
            }
            set
            {
                if (index < this.Count() && index >= 0)
                    _data.SetValue(value, index);
            }
        }
        public DataFrameData this[int index,int boyut]
        {
            get
            {
                if (index < this.Count() && index >= 0 && index < boyut && boyut < this.Count())
                {
                    return _data switch
                    {
                        bool?[] bool1 => new DataFrameData(bool1.Skip(index).Take(boyut).ToArray()),
                        int?[] int1 => new DataFrameData(int1.Skip(index).Take(boyut).ToArray()),
                        float?[] float1 => new DataFrameData(float1.Skip(index).Take(boyut).ToArray()),
                        double?[] double1 => new DataFrameData(double1.Skip(index).Take(boyut).ToArray()),
                        decimal?[] decimal1 => new DataFrameData(decimal1.Skip(index).Take(boyut).ToArray()),
                        DateTime?[] dateTime1 => new DataFrameData(dateTime1.Skip(index).Take(boyut).ToArray()),
                        string?[] string1 => new DataFrameData(string1.Skip(index).Take(boyut).ToArray()),
                        _ => throw new NotImplementedException("Unrecognized data type")
                    };
                }
                else
                {
                    Genel.Loglayıcı.Error("Index belirtilen aralık dışındaydı.: DataFrameData.this[int index, int boyut]");
                    return null;
                }
            }
        }
        public List<DataFrameData> Rolling(int boyut)
        {
            List<DataFrameData> sonuç = new List<DataFrameData>(Count());
            for(int i=0; i< Count(); i++)
            {
                
                Array araveri = this._data switch
                {
                    bool?[] => new bool?[boyut],
                    int?[] => new int?[boyut],
                    float?[] => new float?[boyut],
                    double?[] => new double?[boyut],
                    decimal?[] => new decimal?[boyut],
                    DateTime?[] => new DateTime?[boyut],
                    string?[] => new string?[boyut],
                    _ => throw new NotImplementedException("Unrecognized data type")
                };
                sonuç.Add(new DataFrameData(araveri));
                try
                {
                    if (i < boyut - 1)
                    {
                        for (int j = i; j < boyut + i; j++)
                        {
                            if (j < boyut - 1)
                                sonuç[i][j - i] = null;
                            else
                                sonuç[i][j - i] = this[j - boyut + 1];
                        }
                    }
                    else
                    {
                        var kesim = _data switch
                        {
                            bool?[] bool1 => new DataFrameData(bool1.Skip(i - boyut + 1).Take(boyut).ToArray()),
                            int?[] int1 => new DataFrameData(int1.Skip(i - boyut + 1).Take(boyut).ToArray()),
                            float?[] float1 => new DataFrameData(float1.Skip(i - boyut + 1).Take(boyut).ToArray()),
                            double?[] double1 => new DataFrameData(double1.Skip(i - boyut + 1).Take(boyut).ToArray()),
                            decimal?[] decimal1 => new DataFrameData(decimal1.Skip(i - boyut + 1).Take(boyut).ToArray()),
                            DateTime?[] dateTime1 => new DataFrameData(dateTime1.Skip(i - boyut + 1).Take(boyut).ToArray()),
                            string?[] string1 => new DataFrameData(string1.Skip(i - boyut + 1).Take(boyut).ToArray()),
                            _ => throw new NotImplementedException("Unrecognized data type")
                        };
                        sonuç[i] = kesim;
                    }
                }catch(Exception e)
                {
                    Genel.Loglayıcı.Error("Rolling işlem hatası.: DataFrameData.Rolling(int boyut), Hata:"+e.Message);
                }
                
                
            }
            return sonuç;
        }
        public IConvertible? First()
        {
            return _data switch
            {
                bool?[] bool1 => (bool1.Length > 0) ? bool1[0] : null,
                int?[] int1 => (int1.Length > 0) ? int1[0] : null,
                float?[] float1 => (float1.Length > 0) ? float1[0] : null,
                double?[] double1 => (double1.Length > 0) ? double1[0] : null,
                decimal?[] decimal1 => (decimal1.Length > 0) ? decimal1[0] : null,
                DateTime?[] dateTime1 => (dateTime1.Length > 0) ? dateTime1[0] : null,
                string?[] string1 => (string1.Length > 0) ? string1[0] : null,
                _ => throw new NotImplementedException("Unrecognized data type")
            };
        }
        public IConvertible? Last()
        {
            return _data switch
            {
                bool?[] bool1 => (bool1.Length > 0) ? bool1[bool1.Length - 1] : null,
                int?[] int1 => (int1.Length > 0) ? int1[int1.Length - 1] : null,
                float?[] float1 => (float1.Length > 0) ? float1[float1.Length - 1] : null,
                double?[] double1 => (double1.Length > 0) ? double1[double1.Length - 1] : null,
                decimal?[] decimal1 => (decimal1.Length > 0) ? decimal1[decimal1.Length - 1] : null,
                DateTime?[] dateTime1 => (dateTime1.Length > 0) ? dateTime1[dateTime1.Length - 1] : null,
                string?[] string1 => (string1.Length > 0) ? string1[string1.Length - 1] : null,
                _ => throw new NotImplementedException("Unrecognized data type")
            };
        }
        public IEnumerator<IConvertible?> GetEnumerator()
        {
            return _data switch
            {
                bool?[] bool1 => (IEnumerator<IConvertible?>)bool1.GetEnumerator(),
                int?[] int1 => (IEnumerator<IConvertible?>)int1.GetEnumerator(),
                float?[] float1 => (IEnumerator<IConvertible?>)float1.GetEnumerator(),
                double?[] double1 => (IEnumerator<IConvertible?>)double1.GetEnumerator(),
                decimal?[] decimal1 => (IEnumerator<IConvertible?>)decimal1.GetEnumerator(),
                DateTime?[] dateTime1 => (IEnumerator<IConvertible?>)dateTime1.GetEnumerator(),
                string?[] string1 => (IEnumerator<IConvertible?>)string1.GetEnumerator(),
                _ => null
            };
        }
    }
}
