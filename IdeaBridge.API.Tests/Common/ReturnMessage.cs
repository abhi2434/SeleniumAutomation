using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Automation.API.Tests.Common
{
    public class ReturnMessage<T>
    {

        public ReturnMessage()
        {
            this.Exceptions = new List<Exception>();
            this.Message = "Failed";
        }
        public List<Exception> Exceptions { get; set; }
        public string Message { get; set; }

        public bool Status { get; set; }

        public T Value { get; set; }

        public HttpStatusCode HttpStatusCode { get; set; }
        public void SetSuccess(T value)
        {
            this.Status = true;
            this.Message = "Successful";
            this.Value = value;
        }
        public void SetSuccess(T value, string message)
        {
            this.Status = true;
            this.Message = message;
            this.Value = value;
        }
        public void SetError(Exception ex, string message)
        {
            this.Status = false;
            this.Message = message;
            this.Exceptions.Add(ex);
        }
        public void SetError(Exception ex)
        {
            this.Status = false;
            this.Message = ex.Message;
            this.Exceptions.Add(ex);
        }
    }
}
