using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Response<T>
    {
        public Response() { }
        public Response(T data, string messaje = null)
        {
            Succeded= true;
            Message = messaje;
            Result = data;
        }

        public Response(string message)
        {
            Succeded = false;
            Message = message;
        }

        public bool Succeded {  get; set; }
        public string Message { get; set; }
        public T Result { get; set; }
    }
}
