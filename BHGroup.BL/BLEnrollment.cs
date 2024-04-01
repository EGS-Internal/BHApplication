using BHGroup.App.Public.Core;
using BHGroup.DAL;
using BHGroup.DAL.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace BHGroup.BL
{


    public class BLEnrollment : IEnrollment
    {
        private readonly DBContext _dbContext;

        public BLEnrollment()
        {
            _dbContext = DIHelper.Get().Services.GetRequiredService<DBContext>();
        }

        private string GetCurrentSemester()
        {
            string res = "";
            DateTime date = DateTime.Now;
            if (date.Month >= 3 && date.Month <= 9)
            {
                res += (date.Year - 1).ToString();
                res += "2";
            }
            else
            {
                res += date.Year.ToString();
                res += "1";
            }
            return res;
        }

        private string GetNextSemester()
        {
            string res = string.Empty;
            string current = GetCurrentSemester();
            if (current[4].ToString() == "1") res = current + 1;
            if (current[4].ToString() == "2") res = DateTime.Now.ToString() + "1";
            return res;
        }
        public void Add(Student student, Course course)
        {
            var temp = _dbContext.Enrollments.Where(e => e.Student == student).ToList();
            foreach (var e in temp)
            {
                if (e.Course == course || e.Semester == GetNextSemester())
                {
                    throw new Exception("Enrollment is invalid!");
                }
                else
                {
                    Enrollment enroll = new Enrollment
                    {
                        Course = course,
                        Student = student,
                        Semester = GetNextSemester(),
                        Grade = EGrades.F
                    };
                    _dbContext.Enrollments.Add(enroll);
                }
            }


        }

        void IEnrollment.Delete(int id)
        {
            throw new NotImplementedException();
        }



        IList<Enrollment> IEnrollment.GetAllByCourse(Course course)
        {
            throw new NotImplementedException();
        }

        Enrollment IEnrollment.GetByCourse(Course course)
        {
            throw new NotImplementedException();
        }

        Enrollment IEnrollment.GetById(int id)
        {
            throw new NotImplementedException();
        }

        Enrollment IEnrollment.GetBySemester(string semester)
        {
            throw new NotImplementedException();
        }

        IList<Enrollment> IEnrollment.GetByStudent(Student student)
        {
            throw new NotImplementedException();
        }


    }
}
