using KUSYS_Demo.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KUSYS_Demo.Data.Repositories
{
    public class StudentRepository : Repository<Student>
    {
        Context context;
        public StudentRepository(Context _context) : base(_context)
        {
            context = _context;
        }
    }
}
