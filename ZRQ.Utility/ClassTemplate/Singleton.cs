using System;
using System.Collections.Generic;
using System.Text;

namespace ZRQ.Util.ClassTemplate
{
    /// <summary>
    /// 单例
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Singleton<T> : IDisposable where T : class, new()
    {
        private static T _instance = null;
        public static T Instance()
        {
            if (null == _instance)
            {
                _instance = new T();
            }
            return _instance;
        }
        public static T Ins
        {
            get { return _instance ?? (_instance = new T()); }
        }

        public static void Reset()
        {
            if (null != _instance)
            {
                _instance = new T();
            }
        }
        public void Dispose()
        {
            DisposeImp();
        }
        protected virtual void DisposeImp()
        {
        }
    }
}
