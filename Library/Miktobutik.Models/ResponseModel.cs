using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// 
/// </summary>
namespace Miktobutik.Models
{

    /// <summary>
    /// 
    /// </summary>
    public class ErrorItem
    {     
       // public Exception ex { get; set; }
        public string FieldName { get; set; }
        public string Message { get; set; }

    }
    /// <summary>
    /// 
    /// </summary>
    public class ResponseModel : ResponseModel<object> { }
    /// <summary>
    /// 
    /// </summary>
    public class ResponseModel<TType> where TType : class
    {
        public static ResponseModel<TType> Create()
        {
            return new ResponseModel<TType>();
        }
        public bool Success { get; set; }
        public string Message { get; set; }
        public TType result { get; set; }
        public List<ErrorItem> errors { get; set; } = new List<ErrorItem>();

    }
}
