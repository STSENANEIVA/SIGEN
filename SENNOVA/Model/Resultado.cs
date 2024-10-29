using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Resultado<T>
    {

        public string code { get; set; }
        public string heading { get; set; }
        public string message { get; set; }
        public T data { get; set; }
        public int count { get; set; }


        public void SetData(T obj)
        {
            data = obj;
        }

    }
}
