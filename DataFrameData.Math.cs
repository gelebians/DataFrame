using ISRA.System;

namespace ISRA.Data
{
    /*
     * This application is for implementing pandas dataframe in c#.
     * There are DataFrameData Math functions in the DataFrameData.Math.cs file.
     * This library was designed by PoSeYDoN.
     */
    public partial class DataFrameData
    {
        /// <summary>
        /// Returns the total number of data
        /// </summary>
        /// <returns>int</returns>
        public int Count() => _data.Length;
        /// <summary>
        /// Returns the total of the data
        /// </summary>
        /// <returns>IConvertible</returns>
        /// <exception cref="NotImplementedException"></exception>
        public IConvertible? Sum() => _data switch
        {
            int?[] veri => veri.Where(x => x != null).Sum(),
            float?[] veri => veri.Where(x => x != null).Sum(),
            double?[] veri => veri.Where(x => x != null).Sum(),
            decimal?[] veri => veri.Where(x => x != null).Sum(),
            _ => throw new NotImplementedException("Collecting cannot be done with this data type.")
        };
        /// <summary>
        /// Averages the data
        /// </summary>
        /// <returns>IConvertible</returns>
        /// <exception cref="NotImplementedException"></exception>
        public IConvertible? Mean() => _data switch
        {
            int?[] veri => (veri.Count(x => x != null)>0)?(int?)Sum() / veri.Count(x => x != null):null,
            float?[] veri => (veri.Count(x => x != null) > 0) ? (float?)Sum() / veri.Count(x => x != null) : null,
            double?[] veri => (veri.Count(x => x != null) > 0) ? (double?)Sum() / veri.Count(x => x != null) : null,
            decimal?[] veri => (veri.Count(x => x != null) > 0) ? (decimal?)Sum() / veri.Count(x => x != null) : null,
            _ => throw new NotImplementedException("Collecting cannot be done with this data type.")
        };
        /// <summary>
        /// Returns the minimum of all data
        /// </summary>
        /// <returns>IConvertible</returns>
        /// <exception cref="NotImplementedException"></exception>
        public IConvertible? Min() => _data switch
        {
            int?[] veri => veri.Min(x => x != null),
            float?[] veri => veri.Min(x => x != null),
            double?[] veri => veri.Min(x => x != null),
            decimal?[] veri => veri.Min(x => x != null),
            _ => throw new NotImplementedException("The minimum value cannot be found with this data type.")
        };
        /// <summary>
        /// Returns the maximum of all data
        /// </summary>
        /// <returns>IConvertible</returns>
        /// <exception cref="NotImplementedException"></exception>
        public IConvertible? Max() => _data switch
        {
            int?[] veri => veri.Max(x => x != null),
            float?[] veri => veri.Max(x => x != null),
            double?[] veri => veri.Max(x => x != null),
            decimal?[] veri => veri.Max(x => x != null),
            _ => throw new NotImplementedException("The maximum value cannot be found with this data type.")
        };
        /// <summary>
        /// Returns the absolute value of a number.
        /// </summary>
        /// <returns>DataFrameData</returns>
        /// <exception cref="NotImplementedException"></exception>
        public DataFrameData Abs() => _data switch
        {
            int?[] veri => new DataFrameData(veri.Select(x => (int?)Math.Abs((x == null) ? 0 : x.Value)).ToArray()),
            float?[] veri => new DataFrameData(veri.Select(x => (float?)Math.Abs((x == null) ? 0 : x.Value)).ToArray()),
            double?[] veri => new DataFrameData(veri.Select(x => (double?)Math.Abs((x == null) ? 0 : x.Value)).ToArray()),
            decimal?[] veri => new DataFrameData(veri.Select(x => (decimal?)Math.Abs((x == null) ? 0 : x.Value)).ToArray()),
            _ => throw new NotImplementedException("ABS operation cannot be performed with this data type.")
        };
        /// <summary>
        /// Find the difference between the values for each row and the values from the previous row
        /// </summary>
        /// <returns>DataFrameData</returns>
        public DataFrameData Diff()
        {
            return this - this.ShiftLeft();
        }
        /// <summary>
        /// Used to trim values at specified input threshold. We can use this function to put a lower limit and upper limit on the values that any cell can have in the dataframe.
        /// </summary>
        /// <param name="top">Maximum threshold value. All values above this threshold will be set to it.</param>
        /// <param name="bottom">Minimum threshold value. All values below this threshold will be set to it.</param>
        /// <returns>DataFrameData</returns>
        /// <exception cref="NotImplementedException"></exception>
        public DataFrameData Clip(IConvertible? top = null, IConvertible? bottom = null) => _data switch
        {
            int?[] veri => new DataFrameData(veri.Select(x => ((dynamic?)top != null) ? (((dynamic?)x > (dynamic?)top) ? top : x) : ((dynamic?)bottom != null) ? (((dynamic?)x < (dynamic?)bottom) ? bottom : x) : x).ToArray()),
            float?[] veri => new DataFrameData(veri.Select(x => ((dynamic?)top != null) ? (((dynamic?)x > (dynamic?)top) ? top : x) : ((dynamic?)bottom != null) ? (((dynamic?)x < (dynamic?)bottom) ? bottom : x) : x).ToArray()),
            double?[] veri => new DataFrameData(veri.Select(x => ((dynamic?)top != null) ? (((dynamic?)x > (dynamic?)top) ? Convert.ToDouble(top) : x) : ((dynamic?)bottom != null) ? (((dynamic?)x < (dynamic?)bottom) ? Convert.ToDouble(top) : x) : x).ToArray()),
            decimal?[] veri => new DataFrameData(veri.Select(x => ((dynamic?)top != null) ? (((dynamic?)x > (dynamic?)top) ? Convert.ToDecimal(top) : x) : ((dynamic?)bottom != null) ? (((dynamic?)x < (dynamic?)bottom) ? Convert.ToDecimal(bottom) : x) : x).ToArray()),
            _ => throw new NotImplementedException("Clipping cannot be done with this data type.")
        };
        /// <summary>
        /// Return sample standard deviation over requested axis. By default the standard deviations are normalized by N-1. It is a measure that is used to quantify the amount of variation or dispersion of a set of data values. 
        /// </summary>
        /// <returns>IConvertible</returns>
        /// <exception cref="NotImplementedException"></exception>
        public IConvertible? Std()
        {
            var avg = Mean();
            return _data switch
            {
                int?[] veri => Math.Sqrt(veri.Where(x => x != null).Sum(x => (x - (dynamic?)avg) * (x - (dynamic?)avg))/Count()),
                float?[] veri => (float)Math.Sqrt(veri.Where(x => x != null).Sum(x => (x - (dynamic?)avg) * (x - (dynamic?)avg))/Count()),
                double?[] veri => Math.Sqrt(veri.Where(x => x != null).Sum(x => (x - (dynamic?)avg) * (x - (dynamic?)avg))/Count()),
                decimal?[] veri => (decimal?)Math.Sqrt(Convert.ToDouble(veri.Where(x => x != null).Sum(x =>(decimal?)( (x - (dynamic?)avg) * (x - (dynamic?)avg))))/Count()),
                _ => throw new NotImplementedException("Average operation cannot be performed with this data type.")
            };



                
        }
        /// <summary>
        /// Checks whether the given DataFrameData is numeric or not.
        /// </summary>
        /// <returns>bool</returns>
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="veri"></param>
        /// <param name="sameValue"></param>
        /// <returns></returns>
        public DataFrameData Join(DataFrameData veri,IConvertible sameValue)
        {
            if (Count() == veri.Count() && veri.Type == Type)
            {
                DataFrameData returned = new DataFrameData(Type, Count());
                for (int i = 0; i < Count(); i++)
                {
                    if ((dynamic?)veri[i] != (dynamic)sameValue)
                        returned[i] = veri[i];
                    else
                        returned[i] = this[i];
                }
                return returned;
            }
            else
            {
                General.Logging.Error("The data cannot be merged because their size or type is different.: DataFrameData.Join(DataFrameData data,IConvertible sameValue)");
                return null;
            }
        }
        /// <summary>
        /// Usage of pandas ewm function in this library
        /// </summary>
        /// <param name="periot">window size</param>
        /// <param name="alpha"> coefficient</param>
        /// <returns>DataFrameData</returns>
        /// <exception cref="NotImplementedException"></exception>
        public DataFrameData Ewm(int periot, double alpha = 0.2)
        {
            DataFrameData ewm = new DataFrameData(Type, Count());
            ewm[0] = this[0];
            for (int i = 1; i < Count(); ++i)
            {
                ewm[i] = _data switch
                {
                    int?[] veri => alpha * veri[i] + (1 - alpha) * (dynamic)ewm[i - 1],
                    float?[] veri => alpha * veri[i] + (1 - alpha) * (dynamic)ewm[i - 1],
                    double?[] veri => alpha * veri[i] + (1 - alpha) * (dynamic)ewm[i - 1],
                    decimal?[] veri => Convert.ToDecimal(alpha) * veri[i] + Convert.ToDecimal(1 - alpha) * (dynamic)ewm[i - 1],
                    _ => throw new NotImplementedException("Clipping cannot be done with this data type.")
                };
                
            }
            return ewm;
        }
        /// <summary>
        /// sma indicator
        /// </summary>
        /// <param name="periot"> window size</param>
        /// <returns></returns>
        public DataFrameData Sma(int periot)
        {
            return this.Rolling(periot).Mean();
        }
        /// <summary>
        /// ema indicator
        /// </summary>
        /// <param name="periot">window size</param>
        /// <returns></returns>
        public DataFrameData Ema(int periot)
        {
            return this.Rolling(periot).Ema(15);
        }
        /// <summary>
        /// wma indicator
        /// </summary>
        /// <param name="periot"></param>
        /// <returns></returns>
        public DataFrameData Wma(int periot)
        {
            DataFrameData weight = new DataFrameData(Type, periot);

            for (int i = 0; i < periot; i++)
            {
                weight[i] = i + 1;
            }
            return this.Rolling(periot).Wma(periot,weight);
        }
        /// <summary>
        /// Rsi indicator
        /// </summary>
        /// <param name="periot"></param>
        /// <returns></returns>
        public DataFrameData Rsi(int periot)
        {
            var delta = this.Diff();

            var top = delta.Clip(top: 0);
            var bottom = delta.Clip(top: 0) * -1;
            var maTop = top.Sma(periot);
            var maBottom = bottom.Sma(periot);
            var RS = maTop / maBottom;
            return 100m - (100m / (RS + 1));
        }
        /// <summary>
        /// hma indicator
        /// </summary>
        /// <param name="periot"> window size</param>
        /// <returns>DataFrameData</returns>
        public DataFrameData Hma(int periot)
        {
            return (this.Wma(periot / 2) * 2 - this.Wma(periot)).Wma((int)Math.Sqrt(periot));
        }
        /// <summary>
        /// Stochastic rsi indicator
        /// </summary>
        /// <param name="periot">window size</param>
        /// <param name="smooth"> smooth size</param>
        /// <returns>DataFrameData</returns>
        public DataFrameData StockRsi(int periot,int smooth)
        {
            var rsi = this.Rsi(periot);
            return (rsi - rsi.Rolling(smooth).Mean()) / rsi.Rolling(smooth).Std();
        }
    };
}
