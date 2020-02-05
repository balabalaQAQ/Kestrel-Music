using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Kestrel.EntityModel.Tools
{
    public class EntityHelper

    {   /// <summary>
        /// 提取根据系统时间生成 SortCode 所需要的字符串
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static string SortCodeByDefaultDateTime<T>()
        {
            var nowTime = DateTime.Now;
            string timeStampString = nowTime.ToString("yyyy-MM-dd-hh-mm-ss-ffff", DateTimeFormatInfo.InvariantInfo);

            var entityName = typeof(T).Name;
            string result = entityName + "_" + timeStampString;
            return result;
        }
    }
}
