using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BHGroup.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace BHGroup.BL
{
    public interface ICourse
    {
        public  Course GetById(int id);
        public IEnumerable<Course> GetAll();
        public void Add(Course course);
        public void Update(Course course);
        public void Delete(Course course);
    }
}
