using BHGroup.DAL;
using BHGroup.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace BHGroup.BL.Test
{
    public class CourseTests
    {
        private ICourse _courseContext;
        private Mock<DbSet<Course>> _mockCourseDbSet;
        private Mock<DBContext> _mockCourseDbContext;

        [SetUp]
        public void Setup()
        {
            _mockCourseDbContext = new Mock<DBContext>();
            var data = new List<Course>()
            {
                new Course()
                {
                    CourseID = 1,
                    Coursename = "test 1",
                    Description = "test 1",
                    LecturerID = 1,
                },
                new Course()
                {
                    CourseID = 2,
                    Coursename = "test 2",
                    Description = "test 2",
                    LecturerID = 1,
                },
                new Course()
                {
                    CourseID = 3,
                    Coursename = "test 3",
                    Description = "test 3",
                    LecturerID = 1,
                },
                new Course()
                {
                    CourseID = 4,
                    Coursename = "test 4",
                    Description = "test 4",
                    LecturerID = 1,
                },
            }.AsQueryable();

            _mockCourseDbSet = new Mock<DbSet<Course>>();
            _mockCourseDbSet.As<IQueryable<Course>>().Setup(m => m.Provider).Returns(data.Provider);
            _mockCourseDbSet.As<IQueryable<Course>>().Setup(m => m.Expression).Returns(data.Expression);
            _mockCourseDbSet.As<IQueryable<Course>>().Setup(m => m.ElementType).Returns(data.ElementType);
            _mockCourseDbSet.As<IQueryable<Course>>().Setup(m => m.GetEnumerator()).Returns(() => data.GetEnumerator());

            _mockCourseDbContext
                .Setup(s => s.Courses)
                .Returns(_mockCourseDbSet.Object);
            _courseContext = new BLCourse(_mockCourseDbContext.Object);
        }
        [Test]
        public void GetAllTest()
        {
            var result = _courseContext.GetAll();
            Assert.That(result.Count, Is.EqualTo(4));
        }
        [Test]
        public void GetByNameTest()
        {
            var result = _courseContext.GetByName("test");
            Assert.That(result.Count(), Is.EqualTo(4));
        }
        [Test]
        public void AddTest()
        {
            _courseContext.Add(
                new Course()
                {
                    CourseID = 5,
                    Coursename = "test 5",
                    Description = "test 5",
                    LecturerID = 1,
                }
            );
            _mockCourseDbSet.Verify(m => m.Add(It.IsAny<Course>()), Times.Once());
            _mockCourseDbContext.Verify(m => m.SaveChanges(), Times.Once());
        }
        [Test]
        public void DeleteTest()
        {
            _courseContext.Delete(1);
            _mockCourseDbSet.Verify(m => m.Remove(It.IsAny<Course>()), Times.Once());
            _mockCourseDbContext.Verify(m => m.SaveChanges(), Times.Once());
        }
        [Test]
        public void UpdateTest()
        {
            _courseContext.Update(
                new Course()
                {
                    CourseID = 1,
                    Coursename = "test 1 update",
                    Description = "test 1 update",
                    LecturerID = 2,
                }
            );
            _mockCourseDbSet.Verify(m => m.Update(It.IsAny<Course>()), Times.Once());
            _mockCourseDbContext.Verify(m => m.SaveChanges(), Times.Once());
        }
    }
}
