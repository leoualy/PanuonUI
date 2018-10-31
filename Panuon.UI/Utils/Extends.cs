﻿/*==============================================================
*作者：ZEOUN
*时间：2018/10/10 15:20:15
*说明： 
*日志：2018/10/10 15:20:15 创建。
*==============================================================*/
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace Panuon.UI.Utils
{
    public static class Extends
    {
        #region String
        /// <summary>
        /// 尝试将字符串转换为整数，若转换失败，则返回0。
        /// </summary>
        public static int ToInt(this string context)
        {
            var result = 0;
            if (Int32.TryParse(context, out result))
                return result;
            else
                return 0;
        }

        /// <summary>
        /// 尝试将字符串转换为小数，若转换失败，则返回0。
        /// </summary>
        public static double ToDouble(this string context)
        {
            var result = 0.0;
            if (Double.TryParse(context, out result))
                return result;
            else
                return 0;
        }
        #endregion

        #region Integer
        /// <summary>
        /// 将数字转换为中文大写文字。
        /// </summary>
        public static string ToChineseNumber(this int number)
        {
            var result = "";
            var str = "零一二三四五六七八九";
            var convert = number.ToString();
            for(int i = 0; i < convert.Length; i++)
            {
                result += str[Int32.Parse(convert[i].ToString())];
            }
            return result;
        }

        #endregion

        #region DateTime
        /// <summary>
        /// 将时间转换成时间戳（精确到毫秒）。
        /// </summary>
        public static long ToTimeStamp(this DateTime date)
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1);
            return Convert.ToInt64(ts.TotalMilliseconds);
        }

        /// <summary>
        /// 返回一个新的日期，时分秒将被设为0。
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime ToDateOnly(this DateTime date)
        {
            return new DateTime(date.Year, date.Month, date.Day);
        }
        #endregion

        #region Long
        /// <summary>
        /// 将时间戳转换成时间（精确到毫秒）。
        /// </summary>
        public static DateTime ToDate(this long timeStamp)
        {
            return TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1)).AddMilliseconds((long)timeStamp);
        }
        #endregion

        #region List
        /// <summary>
        /// 将列表中的每个元素拼接成一段字符串。
        /// </summary>
        /// <param name="spliter">分隔符。</param>
        public static string ToString<T>(this IList<T> list,string spliter)
        {
            return String.Join(spliter, list);
        }

        public static ObservableCollection<T> ToObservableCollection<T>(this IList<T> list)
        {
            return new ObservableCollection<T>(list);
        }
        #endregion
    }
}
