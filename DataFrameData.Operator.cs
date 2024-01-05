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
        public static DataFrameData operator &(DataFrameData left,DataFrameData right)
        {
            if (left.Count() == right.Count())
            {
                DataFrameData returned = new DataFrameData(typeof(bool), left.Count());
                if (left.Type == typeof(bool) && left.Type == typeof(bool))
                {
                    for (int i = 0; i < left.Count(); i++)
                    {
                        returned[i] = (bool)left[i] == true && (bool)right[i] == true;
                    }
                    return returned;
                }
                else
                {
                    throw new Exception("The two data types are not the same or are not comparable types.: DataFrameData.&(DataFrameData left,DataFrameData right)");
                    return null;
                }
            }
            else
            {
                throw new Exception("Data sizes are not the same.: DataFrameData.&(DataFrameData left,DataFrameData right)");
                return null;
            }
        }
        public static DataFrameData operator ==(DataFrameData left, DataFrameData right)
        {
            if (left.Count() == right.Count())
            {
                DataFrameData returned =new DataFrameData(typeof(bool), left.Count());
                if (left.Type == right.Type || (left.IsNumeric() && right.IsNumeric()))
                {
                    for (int i = 0; i < left.Count(); i++)
                    {
                        returned[i] = left[i] == right[i];
                    }
                    return returned;
                }
                else
                {
                    throw new Exception("The two data types are not the same or are not comparable types.: DataFrameData.==(DataFrameData left,DataFrameData right)");
                    return null;
                }
            }
            else
            {
                throw new Exception("Data sizes are not the same.: DataFrameData.==(DataFrameData left,DataFrameData right)");
                return null;
            }
        }
        public static DataFrameData operator !=(DataFrameData left, DataFrameData right)
        {
            if (left.Count() == right.Count())
            {
                DataFrameData returned = new DataFrameData(typeof(bool), left.Count());
                if (left.Type == right.Type || (left.IsNumeric() && right.IsNumeric()))
                {
                    for (int i = 0; i < left.Count(); i++)
                    {
                        returned[i] = left[i] != right[i];
                    }
                    return returned;
                }
                else
                {
                    throw new Exception("The two data types are not the same or are not comparable types.");
                }
            }
            else
            {
                throw new Exception("Data sizes are not the same.");
            }
        }
        public static DataFrameData operator ==(DataFrameData left, IConvertible right)
        {
            DataFrameData returned = new DataFrameData(typeof(bool), left.Count());
            if ((left.IsNumeric() && right.IsNumeric()) || (left.Type == right.GetType()))
            {
                for (int i = 0; i < left.Count(); i++)
                {
                    returned[i] = (dynamic?)left[i] == (dynamic)right;
                }
                return returned;
            }
            else
            {
                throw new Exception("The two data types are not the same or are not comparable types.");
            }
        }

        public static DataFrameData operator !=(DataFrameData left, IConvertible right)
        {
            DataFrameData returned = new DataFrameData(typeof(bool), left.Count());
            if ((left.IsNumeric() && right.IsNumeric()) || (left.Type == right.GetType()))
            {
                for (int i = 0; i < left.Count(); i++)
                {
                    returned[i] = (dynamic?)left[i] != right;
                }
                return returned;
            }
            else
            {
                throw new Exception("The two data types are not the same or are not comparable types.");
            }
        }
        public static DataFrameData operator >(DataFrameData left, DataFrameData right)
        {
            if (left.Count() == right.Count())
            {
                DataFrameData returned = new DataFrameData(typeof(bool), left.Count());
                if ((left.IsNumeric() && right.IsNumeric()) || (left.Type == typeof(DateTime) && right.Type == typeof(DateTime)))
                {
                    for (int i = 0; i < left.Count(); i++)
                    {
                        returned[i] = (dynamic?)left[i] > (dynamic?)right[i];
                    }
                    return returned;
                }
                else
                {
                    throw new Exception("iki veri karşılaştırılabilir türde değiller.");
                }
            }
            else
            {
                throw new Exception("Data sizes are not the same.");
            }
        }
        public static DataFrameData operator >=(DataFrameData left, DataFrameData right)
        {
            if (left.Count() == right.Count())
            {
                DataFrameData returned = new DataFrameData(typeof(bool), left.Count());
                if ((left.IsNumeric() && right.IsNumeric()) || (left.Type == typeof(DateTime) && right.Type == typeof(DateTime)))
                {
                    for (int i = 0; i < left.Count(); i++)
                    {
                        returned[i] = (dynamic?)left[i] >= (dynamic?)right[i];
                    }
                    return returned;
                }
                else
                {
                    throw new Exception("The two data types are not the same or are not comparable types.");
                }
            }
            else
            {
                throw new Exception("Data sizes are not the same.");
            }
        }
        public static DataFrameData operator <(DataFrameData left, DataFrameData right)
        {
            if (left.Count() == right.Count())
            {
                DataFrameData returned = new DataFrameData(typeof(bool), left.Count());
                if ((left.IsNumeric() && right.IsNumeric()) || (left.Type == typeof(DateTime) && right.Type == typeof(DateTime)))
                {
                    for (int i = 0; i < left.Count(); i++)
                    {
                        returned[i] = (dynamic?)left[i] < (dynamic?)right[i];
                    }
                    return returned;
                }
                else
                {
                    throw new Exception("The two data types are not the same or are not comparable types.");
                }
            }
            else
            {
                throw new Exception("Data sizes are not the same.");
            }
        }
        public static DataFrameData operator <=(DataFrameData left, DataFrameData right)
        {
            if (left.Count() == right.Count())
            {
                DataFrameData returned = new DataFrameData(typeof(bool), left.Count());
                if ((left.IsNumeric() && right.IsNumeric()) || (left.Type == typeof(DateTime) && right.Type == typeof(DateTime)))
                {
                    for (int i = 0; i < left.Count(); i++)
                    {
                        returned[i] = (dynamic?)left[i] <= (dynamic?)right[i];
                    }
                    return returned;
                }
                else
                {
                    throw new Exception("The two data types are not the same or are not comparable types.");
                }
            }
            else
            {
                throw new Exception("Data sizes are not the same.");
            }
        }
        public static DataFrameData operator >(DataFrameData left, IConvertible right)
        {
            DataFrameData returned = new DataFrameData(typeof(bool), left.Count());
            if ((left.IsNumeric() && right.IsNumeric()) || (left.Type == typeof(DateTime) && right.GetType() == typeof(DateTime)))
            {
                for (int i = 0; i < left.Count(); i++)
                {
                    returned[i] = (dynamic?)left[i] > right;
                }
                return returned;
            }
            else
            {
                throw new Exception("iki veri karşılaştırılabilir türde değiller.");
            }
        }
        public static DataFrameData operator >=(DataFrameData left, IConvertible right)
        {
            DataFrameData returned = new DataFrameData(typeof(bool), left.Count());
            if ((left.IsNumeric() && right.IsNumeric()) || (left.Type == typeof(DateTime) && right.GetType() == typeof(DateTime)))
            {
                for (int i = 0; i < left.Count(); i++)
                {
                    returned[i] = (dynamic?)left[i] >= right;
                }
                return returned;
            }
            else
            {
                throw new Exception("iki veri karşılaştırılabilir türde değiller.");
            }
        }
        public static DataFrameData operator <(DataFrameData left, IConvertible right)
        {
            DataFrameData returned = new DataFrameData(typeof(bool), left.Count());
            if ((left.IsNumeric() && right.IsNumeric()) || (left.Type == typeof(DateTime) && right.GetType() == typeof(DateTime)))
            {
                for (int i = 0; i < left.Count(); i++)
                {
                    returned[i] = (dynamic?)left[i] < right;
                }
                return returned;
            }
            else
            {
                throw new Exception("iki veri karşılaştırılabilir türde değiller.");
            }
        }
        public static DataFrameData operator <=(DataFrameData left, IConvertible right)
        {
            DataFrameData returned = new DataFrameData(typeof(bool), left.Count());
            if ((left.IsNumeric() && right.IsNumeric()) || (left.Type == typeof(DateTime) && right.GetType() == typeof(DateTime)))
            {
                for (int i = 0; i < left.Count(); i++)
                {
                    returned[i] = (dynamic?)left[i] <= right;
                }
                return returned;
            }
            else
            {
                throw new Exception("Data sizes are not the same.");
            }
        }
        public static DataFrameData operator +(DataFrameData left, DataFrameData right)
        {
            if (left.Count() == right.Count())
            {
                DataFrameData returned = new DataFrameData(left.Type, left.Count());
                if (left.Type == right.Type || (left.IsNumeric() && right.IsNumeric()))
                {
                    for (int i = 0; i < left.Count(); i++)
                    {
                        returned[i] = (left[i] != null && right[i] != null) ? ((dynamic?)left[i] + (dynamic?)right[i]) : null;
                    }
                    return returned;
                }
                else
                {
                    throw new Exception("The two data types are not the same or are not comparable types.");
                }
            }
            else
            {
                throw new Exception("Data sizes are not the same.");
            }
        }
        public static DataFrameData operator +(DataFrameData left, IConvertible? right)
        {
            DataFrameData returned = new DataFrameData(left.Type, left.Count());
            if (left.IsNumeric() && right.IsNumeric())
            {
                for (int i = 0; i < left.Count(); i++)
                {
                    returned[i] = (dynamic?)left[i] + (dynamic?)right;
                }
                return returned;
            }
            else
            {
                throw new Exception("The two data types are not the same or are not comparable types.");
            }
        }
        public static DataFrameData operator +(IConvertible? left, DataFrameData right)
        {

            DataFrameData returned = new DataFrameData(right.Type, right.Count());
            if (left.IsNumeric() && right.IsNumeric())
            {
                for (int i = 0; i < right.Count(); i++)
                {
                    returned[i] = (dynamic?)left + (dynamic?)right[i];
                }
                return returned;
            }
            else
            {
                throw new Exception("The two data types are not the same or are not comparable types.");
            }

        }
        public static DataFrameData operator -(DataFrameData left, DataFrameData right)
        {
            if (left.Count() == right.Count())
            {
                DataFrameData returned = new DataFrameData(left.Type, left.Count());
                if (left.Type == right.Type || (left.IsNumeric() && right.IsNumeric()))
                {
                    for (int i = 0; i < left.Count(); i++)
                    {
                        returned[i] = (dynamic?)left[i] - (dynamic?)right[i];
                    }
                    return returned;
                }
                else
                {
                    throw new Exception("The two data types are not the same or are not comparable types.");
                }
            }
            else
            {
                throw new Exception("Data sizes are not the same.");
            }
        }
        public static DataFrameData operator -(DataFrameData left, IConvertible? right)
        {
            DataFrameData returned = new DataFrameData(left.Type, left.Count());
            if (left.IsNumeric() && right.IsNumeric())
            {
                for (int i = 0; i < left.Count(); i++)
                {
                    returned[i] = (dynamic?)left[i] - (dynamic)right;
                }
                return returned;
            }
            else
            {
                throw new Exception("The two data types are not the same or are not comparable types.");
            }
        }
        public static DataFrameData operator -(IConvertible? left, DataFrameData right)
        {

            DataFrameData returned = new DataFrameData(right.Type, right.Count());
            if (left.IsNumeric() && right.IsNumeric())
            {
                for (int i = 0; i < right.Count(); i++)
                {
                    returned[i] = (dynamic)left - (dynamic?)right[i];
                }
                return returned;
            }
            else
            {
                throw new Exception("The two data types are not the same or are not comparable types.");
            }
        }
        public static DataFrameData operator *(DataFrameData left, DataFrameData right)
        {
            if (left.Count() == right.Count())
            {
                DataFrameData returned = new DataFrameData(left.Type, left.Count());
                if (left.Type == right.Type || (left.IsNumeric() && right.IsNumeric()))
                {
                    for (int i = 0; i < left.Count(); i++)
                    {
                        returned[i] = (dynamic?)left[i] * (dynamic?)right[i];
                    }
                    return returned;
                }
                else
                {
                    throw new Exception("The two data types are not the same or are not comparable types.");
                }
            }
            else
            {
                throw new Exception("Data sizes are not the same.");
            }
        }
        public static DataFrameData operator *(DataFrameData left, IConvertible? right)
        {

            DataFrameData returned = new DataFrameData(left.Type, left.Count());
            if (left.IsNumeric() && right.IsNumeric())
            {
                for (int i = 0; i < left.Count(); i++)
                {
                    returned[i] = (dynamic?)left[i] * (dynamic)right;
                }
                return returned;
            }
            else
            {
                throw new Exception("The two data types are not the same or are not comparable types.");
            }
        }
        public static DataFrameData operator *(IConvertible? left, DataFrameData right)
        {

            DataFrameData returned = new DataFrameData(right.Type, right.Count());
            if (left.IsNumeric() && right.IsNumeric())
            {
                for (int i = 0; i < right.Count(); i++)
                {
                    returned[i] = (dynamic)left * (dynamic?)right[i];
                }
                return returned;
            }
            else
            {
                throw new Exception("The two data types are not the same or are not comparable types.");
            }
        }
        public static DataFrameData operator /(DataFrameData left, DataFrameData right)
        {
            if (left.Count() == right.Count())
            {
                DataFrameData returned = new DataFrameData(left.Type, left.Count());
                if (left.Type == right.Type || (left.IsNumeric() && right.IsNumeric()))
                {
                    for (int i = 0; i < left.Count(); i++)
                    {
                        if ((dynamic?)right[i] == 0 || (dynamic?)right[i] == null)
                            returned[i] = null;
                        //throw new Exception("Sıfıra bölme hatası.");
                        else
                            returned[i] = ((dynamic?)left[i] / (dynamic?)right[i]);
                    }
                    return returned;
                }
                else
                {
                    throw new Exception("The two data types are not the same or are not comparable types.");
                }
            }
            else
            {
                throw new Exception("Data sizes are not the same.");
            }
        }
        public static DataFrameData operator /(DataFrameData left, IConvertible? right)
        {
            DataFrameData returned = new DataFrameData(left.Type, left.Count());
            if (left.IsNumeric() && right.IsNumeric())
            {
                for (int i = 0; i < left.Count(); i++)
                {
                    if ((dynamic?)right == 0 || (dynamic?)right == null)
                        returned[i]=null;
                        //throw new Exception("Sıfıra bölme hatası.");
                    else
                        returned[i] = (dynamic?)left[i] / (dynamic?)right;
                }
                return returned;
            }
            else
            {
                throw new Exception("The two data types are not the same or are not comparable types.");
            }
        }
        public static DataFrameData operator /(IConvertible? left, DataFrameData right)
        {
            DataFrameData returned = new DataFrameData(right.Type, right.Count());
            if (left.IsNumeric() && right.IsNumeric())
            {
                for (int i = 0; i < right.Count(); i++)
                {
                    if ((dynamic?)right[i] == 0 || (dynamic?)right[i] == null)
                        returned[i] = null;
                    //throw new Exception("Sıfıra bölme hatası.");
                    else
                        returned[i] = (dynamic?)left / (dynamic?)right[i];
                }
                return returned;
            }
            else
            {
                throw new Exception("The two data types are not the same or are not comparable types.");
            }
        }
    }
}
 
