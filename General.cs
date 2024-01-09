using ISRA.Data;
using Serilog;
using Serilog.Core;
using System.Reflection;

namespace ISRA.System
{
    /*
     * This application is for implementing pandas dataframe in c#.
     * There are external static functions in the Genel.cs file.
     * This library was designed by PoSeYDoN.
     */
    public static partial class General
    {
        /// <summary>
        /// Checks whether the given parameter is numeric or not.
        /// </summary>
        /// <param name="o"> The parameter is of type object</param>
        /// <returns>bool</returns>
        public static bool IsNumeric(this object o) => o is byte || o is sbyte || o is ushort || o is uint || o is ulong || o is short || o is int || o is long || o is float || o is double || o is decimal;
        public static Logger Logging = new LoggerConfiguration().WriteTo.Console()
     .WriteTo.Debug(outputTemplate: DateTime.Now.ToString())
     .WriteTo.File("System-Logs.txt", rollingInterval: RollingInterval.Day)
     .CreateLogger();
        /// <summary>
        /// Implementation of the np.where function.
        /// </summary>
        /// <param name="compare"> compare operators</param>
        /// <param name="iftrue"> if true</param>
        /// <param name="iffalse"> if false</param>
        /// <returns>DataFrameData</returns>
        /// <exception cref="Exception"></exception>
        public static DataFrameData Where(DataFrameData compare, IConvertible iftrue, IConvertible iffalse)
        {
            if (compare.Type == typeof(bool) && (iftrue.GetType() == iffalse.GetType()))
            {
                DataFrameData datas = new DataFrameData(iftrue.GetType(), compare.Count());
                for (int i = 0; i < compare.Count(); i++)
                {
                    datas[i] = ((bool)compare[i]) ? iftrue : iffalse;
                }
                return datas;
            }
            else
            {
                throw new Exception("Comparison Error. The comparison type is not bool or the result types are not the same.");
            }
        }
        /// <summary>
        /// Finds the maximum of the DataFrameDatas given with the parameter
        /// </summary>
        /// <param name="parameters">It is of type DataFrameData</param>
        /// <returns>DataFrameData</returns>
        /// <exception cref="Exception"></exception>
        public static DataFrameData DataFrameMax(params DataFrameData[] parameters)
        {
            
            DataFrameData datas = new DataFrameData(parameters.First().Type,parameters.First().Count());
            if(parameters.Length > 1)
            {
                bool datasizeaccuracy = false;
                int size = 0;
                for (int i = 0; i < parameters.Length; i++)
                {
                    if (i == 0)
                        size = parameters[0].Count();
                    else
                    {
                        if (parameters[i].Count() == size)
                            datasizeaccuracy = true;
                        else
                            datasizeaccuracy=false;
                    }
                    size = parameters[i].Count();
                }
                
                if (datasizeaccuracy)
                {
                    for(int i = 0;i < size; i++)
                    {
                        IConvertible?[] values = new IConvertible?[parameters.Length];
                        for (int j = 0; j < parameters.Length; j++)
                            values[j] = parameters[j][i];
                        datas[i]=values.Max();
                    }
                   
                }
                else
                {
                    throw new Exception("The sizes of the data to be compared are not the same");
                }
            }
            else
            {
                throw new Exception("There are not enough parameters to compare. There must be at least 2 parameters.");
            }
            return datas;
        }
        /// <summary>
        /// Finds the minimum of the DataFrameDatas given with the parameter
        /// </summary>
        /// <param name="parameters">It is of type DataFrameData</param>
        /// <returns>DataFrameData</returns>
        /// <exception cref="Exception"></exception>
        public static DataFrameData DataFrameMin(params DataFrameData[] parameters)
        {

            DataFrameData datas = new DataFrameData(parameters.First().Type, parameters.First().Count());
            if (parameters.Length > 1)
            {
                bool datasizeaccuracy = false;
                int size = 0;
                for (int i = 0; i < parameters.Length; i++)
                {
                    if (i == 0)
                        size = parameters[0].Count();
                    else
                    {
                        if (parameters[i].Count() == size)
                            datasizeaccuracy = true;
                        else
                            datasizeaccuracy = false;
                    }
                    size = parameters[i].Count();
                }
                if (datasizeaccuracy)
                {
                    for (int i = 0; i < size; i++)
                    {
                        dynamic?[] values = new dynamic?[parameters.Length];
                        for (int j = 0; j < parameters.Length; j++)
                            values[j] = parameters[j][i];
                        datas[i] = values.Min();
                    }
                }
                else
                {
                    throw new Exception("The sizes of the data to be compared are not the same");
                }
            }
            else
            {
                throw new Exception("There are not enough parameters to compare. There must be at least 2 parameters.");
            }
            return datas;
        }
        /// <summary>
        /// Checks whether there is an intersection of two dataFrameData.
        /// </summary>
        /// <param name="left">Type of DataFrameData</param>
        /// <param name="right">Type of DataFrameData</param>
        /// <returns>DataFrameData containing elements of type bool</returns>
        /// <exception cref="Exception"></exception>
        public static DataFrameData Cross(DataFrameData left,DataFrameData right)
        {
            if (left.IsNumeric() && right.IsNumeric() && left.Count() == right.Count())
            {
                var cross = General.Where(left < right, 1, 0);

                var preview_cross = cross.ShiftLeft();
                return (cross - preview_cross).Abs()==1;

                /*
                DataFrameData returned = new DataFrameData(typeof(eAlSat), veri1.Toplam());
                for(int i = 0; i < veri1.Toplam(); i++)
                {
                    if (i == 0)
                        returned.Ekle(eAlSat.NÖTR);
                    else
                    {
                        if ((dynamic?)veri1[i] > (dynamic?)veri2[i] && (dynamic?)veri1[i-1]< (dynamic?)veri2[i - 1])
                        {
                            returned.Ekle(eAlSat.AL);
                        }else if((dynamic?)veri1[i] < (dynamic?)veri2[i] && (dynamic?)veri1[i - 1] > (dynamic?)veri2[i - 1])
                        {
                            returned.Ekle(eAlSat.SAT);
                        }
                        else
                        {
                            returned.Ekle(eAlSat.NÖTR);
                        }
                    }
                    
                }
                return returned;
                */
            }
            else
            {
                throw new Exception("The data sizes are not the same or the two data are not of computable type.");
            }
        }
        public static int?[] ArrayJoin(this int?[] array1, int?[] array2)
        {
            int?[] sonuc = new int?[array1.Length + array2.Length];
            array1.CopyTo(sonuc, 0);
            array2.CopyTo(sonuc, array1.Length);
            return sonuc;
        }
        public static bool?[] ArrayJoin(this bool?[] array1, bool?[] array2)
        {
            bool?[] sonuc = new bool?[array1.Length + array2.Length];
            array1.CopyTo(sonuc, 0);
            array2.CopyTo(sonuc, array1.Length);
            return sonuc;
        }
        public static float?[] ArrayJoin(this float?[] array1, float?[] array2)
        {
            float?[] sonuc = new float?[array1.Length + array2.Length];
            array1.CopyTo(sonuc, 0);
            array2.CopyTo(sonuc, array1.Length);
            return sonuc;
        }
        public static double?[] ArrayJoin(this double?[] array1, double?[] array2)
        {
            double?[] sonuc = new double?[array1.Length + array2.Length];
            array1.CopyTo(sonuc, 0);
            array2.CopyTo(sonuc, array1.Length);
            return sonuc;
        }
        public static decimal?[] ArrayJoin(this decimal?[] array1, decimal?[] array2)
        {
            decimal?[] sonuc = new decimal?[array1.Length + array2.Length];
            array1.CopyTo(sonuc, 0);
            array2.CopyTo(sonuc, array1.Length);
            return sonuc;
        }
        public static DateTime?[] ArrayJoin(this DateTime?[] array1, DateTime?[] array2)
        {
            DateTime?[] sonuc = new DateTime?[array1.Length + array2.Length];
            array1.CopyTo(sonuc, 0);
            array2.CopyTo(sonuc, array1.Length);
            return sonuc;
        }
        public static string?[] ArrayJoin(this string?[] array1, string?[] array2)
        {
            string?[] sonuc = new string?[array1.Length + array2.Length];
            array1.CopyTo(sonuc, 0);
            array2.CopyTo(sonuc, array1.Length);
            return sonuc;
        }

        public static T[] RemoveArray<T>(T[] array,int index)
        {
            T[] array2=new T[array.Length-1];
            for (int i = 0; i < array2.Length; i++)
            {
                if (i < index)
                {
                    array2[i] = array[i];
                }
                else
                {
                    array2[i] = array[i + 1];
                }
            }
            return array2;
        }
        public static T[] AddArray<T>(T[] array, IConvertible? veri)
        {
            T[] array2 = new T[array.Length + 1];
            for (int i = 0; i < array2.Length; i++)
            {
                if (i == array.Length)
                    array2[i] = (T)veri;
                else
                    array2[i] = array[i];
            }
            return array2;
        }
        public static T[] AddArray<T>(T[] array,int index, IConvertible? veri)
        {
            T[] array2 = new T[array.Length + 1];
            for (int i = 0; i < array2.Length; i++)
            {
                if (i < index)
                {
                    array2[i] = array[i];
                }else if (i == index)
                {
                    array2[i] = (T)veri;
                }
                else
                {
                    array2[i] = array[i - 1];
                }
            }
            return array2;
        }
        /// <summary>
        /// Returns the value of type enum with its name
        /// </summary>
        /// <param name="eff">element of type enum</param>
        /// <returns></returns>
        public static String convertToString(this Enum eff)
        {
            return Enum.GetName(eff.GetType(), eff);
        }

        public static EnumType converToEnum<EnumType>(this String enumValue)
        {
            return (EnumType)Enum.Parse(typeof(EnumType), enumValue);
        }

        /// <summary>
        /// It is exactly the same as the Map function used in the Arduino library.
        /// </summary>
        /// <param name="value">Value to be averaged</param>
        /// <param name="fromSource">Minimum value of the source item</param>
        /// <param name="toSource">Maximum value of the source item</param>
        /// <param name="fromTarget">Minimum value of target item</param>
        /// <param name="toTarget">Maximum value of target item</param>
        /// <returns>decimal</returns>
        public static decimal Map(this decimal value, decimal fromSource, decimal toSource, decimal fromTarget, decimal toTarget)
        {
            return (value - fromSource) / (toSource - fromSource) * (toTarget - fromTarget) + fromTarget;
        }
        /// <summary>
        /// Clone the given object
        /// </summary>
        /// <typeparam name="T">Type of object</typeparam>
        /// <param name="obj">The item to clone.</param>
        /// <returns>T</returns>
        public static T Clone<T>(this T obj)
        {
            var inst = obj.GetType().GetMethod("MemberwiseClone", BindingFlags.Instance | BindingFlags.NonPublic);

            return (T)inst?.Invoke(obj, null);
        }
        /// <summary>
        /// nz function used in numpy
        /// </summary>
        /// <param name="datas">DataFrameData with null values</param>
        /// <param name="değiştirilecek">DataFrameData containing the values ​​to substitute</param>
        /// <returns>DataFrameData</returns>
        public static DataFrameData nz(this DataFrameData datas,DataFrameData değiştirilecek)
        {
            DataFrameData returned = new DataFrameData(datas.Type, datas.Values.Length);
            for(int i=0; i<datas.Values.Length; i++)
            {
                if (datas[i] == null && datas.IsNumeric())
                {
                    if (değiştirilecek[i] != null && değiştirilecek.IsNumeric())
                        returned[i] = değiştirilecek[i];
                    else
                        returned[i] = 0;
                }
                else
                {
                    returned[i] = datas[i];
                }
            }
            return returned;
        }
        /// <summary>
        /// nz function used in numpy
        /// </summary>
        /// <param name="datas">DataFrameData with null values</param>
        /// <returns>DataFrameData. null values ​​are replaced with 0</returns>
        public static DataFrameData nz(this DataFrameData datas)
        {
            DataFrameData returned = new DataFrameData(datas.Type, datas.Values.Length);

            for (int i = 0; i < datas.Values.Length; i++)
            {
                if (datas[i] == null && datas.IsNumeric())
                    returned[i] = 0;
                else
                    returned[i]= datas[i];
            }
            return returned;
        }
        public static DataFrameData Mean(this IEnumerable<DataFrameData> datas)
        {
            if (datas.Count() > 0)
            {
                DataFrameData returned = new DataFrameData(datas.First().Type, datas.Count());
                int i = 0;
                foreach(var item in datas)
                {
                    returned[i] = item.Mean();
                    i++;
                }
                return returned;
            }
            else
            {
                throw new Exception("The size of the data to be averaged must be greater than 0.");
            }
        }
    }
}
