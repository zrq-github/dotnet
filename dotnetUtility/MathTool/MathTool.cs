﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetTool.MathTool
{
    public class MathTool
    {
        /// <summary>
        /// 四舍五入
        /// </summary>
        /// <param name="value">要进行处理的数据</param>
        /// <param name="n">保留的小数位数</param>
        /// <returns></returns>
        public static double Round(double value, int n)
        {
            return Math.Round(value, n, MidpointRounding.AwayFromZero);
        }
        /// <summary>
        /// 角度转化为弧度
        /// </summary>
        /// <param name="angle">角度</param>
        /// <returns></returns>
        public static double ToRadian(double angle)
        {
            return angle * (Math.PI / 180);
        }
        /// <summary>
        /// 弧度转化为角度
        /// </summary>
        /// <param name="radian">弧度</param>
        /// <returns></returns>
        public static double ToAngle(double radian)
        {
            return (radian * 180) / Math.PI;
        }
    }
}