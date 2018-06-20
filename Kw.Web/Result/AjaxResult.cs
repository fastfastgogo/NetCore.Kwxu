using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kw.Web.Result
{
    [Serializable]
    public class AjaxResult
    {
        private bool isError = false;          //是否发生错误
        private int _total;                    //数据库中的记录总数

        
        //默认的构造函数
        private AjaxResult()
        {
        }

        /// <summary>
        /// 是否产生错误
        /// </summary>
        public bool IsError { get { return isError; } }

        /// <summary>
        /// 错误信息，或者成功信息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 成功可能时返回的数据
        /// </summary>
        public object Data { get; set; }

        #region Error
        /// <summary>
        /// 设置标识错误,并给定错误信息
        /// </summary>
        /// <param name="message">错误信息</param>
        /// <returns>操作结果</returns>
        public static AjaxResult Error(string message)
        {
            return new AjaxResult()
            {
                isError = true,
                Message = message
            };
        }
        #endregion

        #region Success
        /// <summary>
        /// 调用该方法,设置操作成功!
        /// </summary>
        /// <returns>操作结果</returns>
        public static AjaxResult Success()
        {
            return new AjaxResult()
            {
                isError = false
            };
        }

        /// <summary>
        /// 设置操作成功,并给定成功信息
        /// </summary>
        /// <param name="message">成功信息</param>
        /// <returns>操作结果</returns>
        public static AjaxResult Success(string message)
        {
            return new AjaxResult()
            {
                isError = false,
                Message = message
            };
        }

        /// <summary>
        /// 设置操作成功,设置操作返回结果
        /// </summary>
        /// <param name="data">操作成功返回的数据</param>
        /// <returns>操作结果</returns>
        public static AjaxResult Success(object data)
        {
            return new AjaxResult()
            {
                isError = false,
                Data = data
            };
        }
 
        /// <summary>
        /// 操作成功,设置成功信息及返回结果
        /// </summary>
        /// <param name="data">操作返回的结果</param>
        /// <param name="message">成功信息</param>
        /// <returns>操作结果</returns>
        public static AjaxResult Success(object data, string message)
        {
            return new AjaxResult()
            {
                isError = false,
                Data = data,
                Message = message
            };
        }
        #endregion

         

        /// <summary>
        /// 将结果序列化为JSON数据
        /// </summary>
        /// <returns>JSON数据</returns>
        public override string ToString()
        {
            return "";
            
        }
    }
}
