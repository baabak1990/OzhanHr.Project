using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzhanHr.Application.Exceptions
{
    public class NotFountException:ApplicationException
    {
        public NotFountException(string name,object key):base($"{name} with ({key}) is not found !!!")
        {
            
        }
    }
}
