using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZipLink.Core.Commons
{
    public static class CommonHelpers
    {
        /// <summary>
        /// Force data type conversion
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static T ConvertTo<T>(object value, T defaultValue = default(T))
        {
            try
            {
                if (value == null || DBNull.Value.Equals(value))
                {
                    return defaultValue;
                }
                return (T)Convert.ChangeType(value, typeof(T));
            }
            catch (Exception)
            {
                return defaultValue;
            }
        }
    }
}
