using BHGroup.DAL;
using BHGroup.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Moq.EntityFrameworkCore;
using Moq;

namespace BHGroup.BL.Test
{
    public class Tests
    {
        private IStudent _studentContext;
        private Mock<DBContext> _mockStudentContext;

        [SetUp]
        public void Setup()
        {
            _mockStudentContext = new Mock<DBContext>();
            var data = new List<Student>()
            {
                new Student()
                {
                    StudentCode = 1,
                    FirstName = "test",
                    LastName = "1",
                    DateOfBirth = DateTime.Now,
                    JoinDate = DateTime.Now,
                    Gender = Person.EGender.Male,
                    Status = Person.EStatus.Active
                },
                new Student()
                {
                    StudentCode = 2,
                    FirstName = "test",
                    LastName = "2",
                    DateOfBirth = DateTime.Now,
                    JoinDate = DateTime.Now,
                    Gender = Person.EGender.Female,
                    Status = Person.EStatus.Active
                },
                new Student()
                {
                    StudentCode = 3,
                    FirstName = "test",
                    LastName = "3",
                    DateOfBirth = DateTime.Now,
                    JoinDate = DateTime.Now,
                    Gender = Person.EGender.Male,
                    Status = Person.EStatus.Inactive
                },
                new Student()
                {
                    StudentCode = 4,
                    FirstName = "test",
                    LastName = "4",
                    DateOfBirth = DateTime.Now,
                    JoinDate = DateTime.Now,
                    Gender = Person.EGender.Female,
                    Status = Person.EStatus.Inactive
                },
            };
            _mockStudentContext.Setup(s => s.Students).ReturnsDbSet(data);
            _studentContext = new BLStudent(_mockStudentContext.Object);
        }

        [Test]
        public void GetAllTest()
        {
            var result = _studentContext.GetAll();
            Assert.That(result.Count, Is.EqualTo(4));
        }
        [Test]
        public void GetByNaneTest()
        {
            var result = _studentContext.GetByName("test");
            Assert.That(result.Count(), Is.EqualTo(4));
        }
        [Test]
        public void DeleteTest()
        {
            _studentContext.Delete(1);
            var result = _studentContext.GetAll();
            Assert.That(result.Count(), Is.EqualTo(3));
        }
        [Test]
        public void UpdateTest()
        {
            _studentContext.Update( 
                new Student()
                {
                    StudentCode = 1,
                    FirstName = "test update",
                    LastName = "1",
                    DateOfBirth = DateTime.Now,
                    JoinDate = DateTime.Now,
                    Gender = Person.EGender.Male,
                    Status = Person.EStatus.Active
                }
            );
            var result = _studentContext.GetById(1);
            Assert.That(result.FirstName, Is.EqualTo("test update"));
        }
    }
}