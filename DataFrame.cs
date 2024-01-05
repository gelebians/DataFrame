using System.Collections;
using System.Diagnostics.CodeAnalysis;
using System.Dynamic;
using System.Reflection;
using Technical.System;

namespace Technical
{
    public partial class DataFrame : DynamicObject, IDictionary<string, DataFrameData>
    {
        private Dictionary<string, DataFrameData> _columns;
        public Dictionary<string, DataFrameData> Columns
        {
            get => _columns;
            set
            {
                if (_columns != value)
                {
                    _columns = value;
                }
            }
        }

        public DataFrame()
        {
            _columns = new Dictionary<string, DataFrameData>();
        }
        public DataFrame(string[] Columns)
        {
            _columns = new Dictionary<string, DataFrameData>();
            for (int i = 0; i < Columns.Length; i++)
            {
                _columns.Add(Columns[i], new DataFrameData(typeof(int),0));
            }
        }

        public DataFrame(IEnumerable<DataFrameData> data, string[] Columns = null)
        {
            string[] titles = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", };
            _columns = new Dictionary<string, DataFrameData>();
            if (data.Count() > 0)
            {
                if (Columns == null)
                {
                    int i = 0;
                    foreach (var row in data)
                    {
                        _columns.Add(titles[i], row);
                        i++;
                    }
                }
                else if (Columns.Length <= data.Count())
                {
                    var Rows = data.ToArray();
                    for (int i = 0; i < Columns.Length; i++)
                    {
                        _columns.Add(Columns[i], Rows[i]);
                    }
                }
                else
                {
                    var Rows = data.ToArray();
                    for (int i = 0; i < Rows.Length; i++)
                    {
                        _columns.Add(Columns[i], Rows[i]);
                    }
                }
            }
        }

        public DataFrame(DataFrameData data,string column = null)
        {
            string columnName =(column ==null)?"A":column;
            _columns = new Dictionary<string, DataFrameData>();
            _columns.Add(columnName, data);
        }

        public DataFrame(Dictionary<string, IConvertible[]> data, string[] Columns=null)
        {
            _columns = new Dictionary<string, DataFrameData>();
            bool datasizeaccuracy = false;
            int tempCount = data.First().Value.Length;
            foreach (var received in data)
            {
                if (received.Value.Length == tempCount)
                    datasizeaccuracy = true;
                else
                    datasizeaccuracy = true;
                tempCount = received.Value.Length;
            }
            if (data.Count() > 0 && datasizeaccuracy)
            {
                if (Columns == null)
                {
                    foreach (var received in data)
                    {
                        _columns.Add(received.Key, new DataFrameData(received.Value.Cast<IConvertible>().ToArray()));
                    }
                }
                else if (Columns.Length <= data.First().Value.Count())
                {
                    var Rows = data.ToArray();
                    for (int i = 0; i < Columns.Length; i++)
                    {
                        _columns.Add(Columns[i], new DataFrameData(Rows[i].Value.Cast<IConvertible>().ToArray()));
                    }
                }
                else
                {
                    int i = 0;
                    foreach (var received in data)
                    {
                        _columns.Add(Columns[i], new DataFrameData(received.Value.Cast<IConvertible>().ToArray()));
                        i++;
                    }
                }
            }
        }

        public DataFrame(IEnumerable<object> objectlist)
        {
            _columns = new Dictionary<string, DataFrameData>();
            int i = 0;
            foreach (var nesne in objectlist)
            {
                
                Type tip = nesne.GetType();
                if (tip.GetTypeInfo().IsClass)
                {
                    
                    foreach (var prop in tip.GetProperties())
                    {
                        if (_columns.ContainsKey(prop.Name))
                        {
                            _columns[prop.Name][i] = (IConvertible?)prop.GetValue(nesne, null);
                        }
                        else
                        {
                            _columns.Add(prop.Name, new DataFrameData(prop.PropertyType,objectlist.Count()));
                            _columns[prop.Name][i] = (IConvertible?)prop.GetValue(nesne, null);
                        }
                        
                    }

                }
                i++;
            }
        }

        public int Count => (_columns.Count > 0) ? _columns.First().Value.Toplam(): 0;

        public ICollection<string> Keys => _columns.Keys;

        public ICollection<DataFrameData> Values => _columns.Values;
        
        public bool IsReadOnly => _columns.ToArray().IsReadOnly;

        public void AddRow(IConvertible[] datas)
        {
            if (datas.Length == _columns.Count)
            {
                int i = 0;
                foreach (var column in _columns)
                {
                    column.Value.Add(datas[i]);
                    i++;
                }
            }
        }
        public void AddRow(List<IConvertible> datas)
        {
            if (datas.Count == _columns.Count)
            {
                int i = 0;
                foreach (var column in _columns)
                {
                    _columns[column.Key].Add(datas[i]);
                    i++;
                }
            }
        }
        public void AddRow(int index, IConvertible[] datas)
        {
            if (datas.Length == _columns.Count)
            {
                int i = 0;
                foreach (var column in _columns)
                {
                    _columns[column.Key].Add(index, datas[i]);
                    i++;
                }
            }
        }
        public void AddRow(int index, List<IConvertible> datas)
        {
            if (datas.Count == _columns.Count)
            {
                int i = 0;
                foreach (var column in _columns)
                {
                    _columns[column.Key].Add(index, datas[i]);
                    i++;
                }
            }
        }

        public void DeleteRow(int index)
        {
            foreach (var column in _columns)
            {
                _columns[column.Key].Delete(index);
            }
        }
        public void ClearRows()
        {
            foreach (var column in _columns)
            {
                _columns[column.Key].Clear();
            }
        }

        public override string ToString()
        {
            List<string> Rows = new List<string>();
            string titles = "";
            int j = 0;
            foreach(var column in Columns)
            {
                titles += "|"+column.Key.PadRight(30);
                if (j == Columns.Count - 1)
                    titles += "|\n";
                for(int i= 0;i < column.Value.Toplam(); i++)
                {
                    if (Rows.Count < i + 1)
                        Rows.Add("");
                    Rows[i] +="|" +((column.Value[i]!=null)?column.Value[i].ToString().PadRight(30):"");
                    if (j == Columns.Count - 1)
                        Rows[i] += "|\n";
                }
                j++;
            }
            return ("|Rows Count:"+Rows.Count+" Columns Count:"+Columns.Count).PadRight(30*Columns.Count)+new string(' ', Columns.Count * 30 + Columns.Count - 1) +"|\n"+"|" + new string('=', Columns.Count * 30 + Columns.Count - 1) + "|\n" + titles + "|" + new string('=', Columns.Count * 30 + Columns.Count - 1) + "|\n" + string.Join("", Rows) + "|" + new string('=', Columns.Count * 30 + Columns.Count - 1) + "|\n";
        }


        public void Clear()
        {
            _columns.Clear();
        }

        public bool Contains(KeyValuePair<string, DataFrameData> item)
        {
            throw new NotImplementedException();
        }

        public bool ContainsKey(string key)
        {
            return _columns.ContainsKey(key);
        }

        public void CopyTo(KeyValuePair<string, DataFrameData>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<KeyValuePair<string, DataFrameData>> GetEnumerator()
        {
            return _columns.GetEnumerator();
        }

        public void Add(string key, DataFrameData value)
        {
            throw new NotImplementedException();
        }

        public void Add(KeyValuePair<string, DataFrameData> item)
        {
            throw new NotImplementedException();
        }
        public bool Remove(string key)
        {
            return _columns.Remove(key);
        }

        public bool Remove(KeyValuePair<string, DataFrameData> item)
        {
            return _columns.Remove(item.Key);
        }

        public bool TryGetValue(string key, [MaybeNullWhen(false)] out DataFrameData value)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            // Converting the property name to lowercase
            // so that property names become case-insensitive.
            string name = binder.Name.ToLower();

            // If the property name is found in a dictionary,
            // set the result parameter to the property value and return true.
            // Otherwise, return false.
            result = _columns[binder.Name];
            return true;
        }

        // If you try to set a value of a property that is
        // not defined in the class, this method is called.
        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            if (_columns.Count > 0)
            {
                if (((DataFrameData)value).Toplam() == _columns.First().Value.Toplam())
                {
                    if (_columns.ContainsKey(binder.Name))
                    {
                        _columns[binder.Name] = (DataFrameData)value;
                    }
                    else
                        _columns.Add(binder.Name, (DataFrameData)value);
                }
                else
                {
                    Genel.Loglayıcı.Error("datasin satır sayısı aynı değil");
                }
            }
            else
            {
                _columns.Add(binder.Name, (DataFrameData)value);
            }
            

            // You can always add a value to a dictionary,
            // so this method always returns true.
            return true;
        }
        
    }
}
