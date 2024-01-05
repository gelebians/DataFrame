using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Technical.System;

namespace Technical
{
    public partial class DataFrameData
    {
        public int Count() => _data.Length;
        public IConvertible? Sum() => _data switch
        {
            int?[] data => data.Where(x => x != null).Sum(),
            float?[] data => data.Where(x => x != null).Sum(),
            double?[] data => data.Where(x => x != null).Sum(),
            decimal?[] data => data.Where(x => x != null).Sum(),
            _ => throw new NotImplementedException("Collecting cannot be done with this data type.")
        };
        public IConvertible? Mean() => _data switch
        {
            int?[] data => (data.Count(x => x != null)>0)?(int?)Sum() / data.Count(x => x != null):null,
            float?[] data => (data.Count(x => x != null) > 0) ? (float?)Sum() / data.Count(x => x != null) : null,
            double?[] data => (data.Count(x => x != null) > 0) ? (double?)Sum() / data.Count(x => x != null) : null,
            decimal?[] data => (data.Count(x => x != null) > 0) ? (decimal?)Sum() / data.Count(x => x != null) : null,
            _ => throw new NotImplementedException("Collecting cannot be done with this data type.")
        };
        public IConvertible? Min() => _data switch
        {
            int?[] data => data.Min(x => x != null),
            float?[] data => data.Min(x => x != null),
            double?[] data => data.Min(x => x != null),
            decimal?[] data => data.Min(x => x != null),
            _ => throw new NotImplementedException("The minimum value cannot be found with this data type.")
        };
        public IConvertible? Max() => _data switch
        {
            int?[] data => data.Max(x => x != null),
            float?[] data => data.Max(x => x != null),
            double?[] data => data.Max(x => x != null),
            decimal?[] data => data.Max(x => x != null),
            _ => throw new NotImplementedException("The maximum value cannot be found with this data type.")
        };
        public DataFrameData Abs() => _data switch
        {
            int?[] data => new DataFrameData(data.Select(x => (int?)Math.Abs((x == null) ? 0 : x.Value)).ToArray()),
            float?[] data => new DataFrameData(data.Select(x => (float?)Math.Abs((x == null) ? 0 : x.Value)).ToArray()),
            double?[] data => new DataFrameData(data.Select(x => (double?)Math.Abs((x == null) ? 0 : x.Value)).ToArray()),
            decimal?[] data => new DataFrameData(data.Select(x => (decimal?)Math.Abs((x == null) ? 0 : x.Value)).ToArray()),
            _ => throw new NotImplementedException("ABS operation cannot be performed with this data type.")
        };
        public DataFrameData Diff()
        {
            return this - this.ShiftLeft();
        }
        public DataFrameData Clip(IConvertible? top = null, IConvertible? bottom = null) => _data switch
        {
            int?[] data => new DataFrameData(data.Select(x => ((dynamic?)top != null) ? (((dynamic?)x > (dynamic?)top) ? top : x) : ((dynamic?)bottom != null) ? (((dynamic?)x < (dynamic?)bottom) ? bottom : x) : x).ToArray()),
            float?[] data => new DataFrameData(data.Select(x => ((dynamic?)top != null) ? (((dynamic?)x > (dynamic?)top) ? top : x) : ((dynamic?)bottom != null) ? (((dynamic?)x < (dynamic?)bottom) ? bottom : x) : x).ToArray()),
            double?[] data => new DataFrameData(data.Select(x => ((dynamic?)top != null) ? (((dynamic?)x > (dynamic?)top) ? Convert.ToDouble(top) : x) : ((dynamic?)bottom != null) ? (((dynamic?)x < (dynamic?)bottom) ? Convert.ToDouble(top) : x) : x).ToArray()),
            decimal?[] data => new DataFrameData(data.Select(x => ((dynamic?)top != null) ? (((dynamic?)x > (dynamic?)top) ? Convert.ToDecimal(top) : x) : ((dynamic?)bottom != null) ? (((dynamic?)x < (dynamic?)bottom) ? Convert.ToDecimal(bottom) : x) : x).ToArray()),
            _ => throw new NotImplementedException("Clipping cannot be done with this data type.")
        };
        public IConvertible? Std()
        {
            var avg = Mean();
            return _data switch
            {
                int?[] data => Math.Sqrt(data.Where(x => x != null).Sum(x => (x - (dynamic?)avg) * (x - (dynamic?)avg))/Count()),
                float?[] data => (float)Math.Sqrt(data.Where(x => x != null).Sum(x => (x - (dynamic?)avg) * (x - (dynamic?)avg))/Count()),
                double?[] data => Math.Sqrt(data.Where(x => x != null).Sum(x => (x - (dynamic?)avg) * (x - (dynamic?)avg))/Count()),
                decimal?[] data => (decimal?)Math.Sqrt(Convert.ToDouble(data.Where(x => x != null).Sum(x =>(decimal?)( (x - (dynamic?)avg) * (x - (dynamic?)avg))))/Count()),
                _ => throw new NotImplementedException("Average operation cannot be performed with this data type.")
            };                
        }

        public bool IsNumeric() => Type.GetTypeCode(Type) switch
        {
            TypeCode.Int32 => true,
            TypeCode.Single => true,
            TypeCode.Double => true,
            TypeCode.Decimal => true,
            _ => false
        };
        public bool BigSmall()=> Type.GetTypeCode(Type) switch
        {
            TypeCode.Int32 => true,
            TypeCode.Single => true,
            TypeCode.Double => true,
            TypeCode.Decimal => true,
            TypeCode.DateTime => true,
            _ => false
        };
        public DataFrameData Join(DataFrameData data,IConvertible sameValue)
        {
            if (Count() == data.Count() && data.Type == Type)
            {
                DataFrameData returned = new DataFrameData(Type, Count());
                for (int i = 0; i < Count(); i++)
                {
                    if ((dynamic?)data[i] != (dynamic)sameValue)
                        returned[i] = data[i];
                    else
                        returned[i] = this[i];
                }
                return returned;
            }
            else
            {
                throw new Exception("The data cannot be merged because their size or type is different.: DataFrameData.Join(DataFrameData data,IConvertible sameValue)");
                return null;
            }
        }
    };
}
