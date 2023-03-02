using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KUSYS_Demo.Business.Service
{
    interface IService<T> where T : class
    {
        List<T> GetList();
    }

}
