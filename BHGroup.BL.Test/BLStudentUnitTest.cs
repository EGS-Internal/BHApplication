using BHGroup.DAL;
using BHGroup.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Moq.EntityFrameworkCore;
using Moq;
using System.Xml;
using NUnit.Framework;
using System.Net.Sockets;

namespace BHGroup.BL.Test
{
    public class Tests
    {
        private IStudent _studentContext;
        private Mock<DBContext> _mockStudentDbContext;
        private Mock<DbSet<Student>> _mockStudentDbSet;

        [SetUp]
        public void Setup()
        {
            _mockStudentDbContext = new Mock<DBContext>();
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
            }.AsQueryable();

            _mockStudentDbSet = new Mock<DbSet<Student>>();
            _mockStudentDbSet.As<IQueryable<Student>>().Setup(m => m.Provider).Returns(data.Provider);
            _mockStudentDbSet.As<IQueryable<Student>>().Setup(m => m.Expression).Returns(data.Expression);
            _mockStudentDbSet.As<IQueryable<Student>>().Setup(m => m.ElementType).Returns(data.ElementType);
            _mockStudentDbSet.As<IQueryable<Student>>().Setup(m => m.GetEnumerator()).Returns(() => data.GetEnumerator());

            _mockStudentDbContext
                .Setup(s => s.Students)
                .Returns(_mockStudentDbSet.Object);
            _studentContext = new BLStudent(_mockStudentDbContext.Object);
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
        public void AddTest()
        {
            _studentContext.Add(
                new Student()
                {
                    FirstName = "test update",
                    LastName = "1",
                    DateOfBirth = DateTime.Now,
                    JoinDate = DateTime.Now,
                    Gender = Person.EGender.Male,
                    Status = Person.EStatus.Active
                }
            );
            _mockStudentDbSet.Verify(m => m.Add(It.IsAny<Student>()), Times.Once());
            _mockStudentDbContext.Verify(m => m.SaveChanges(), Times.Once());
        }
        [Test]
        public void DeleteTest()
        {
            _studentContext.Delete(1);
            _mockStudentDbSet.Verify(m => m.Remove(It.IsAny<Student>()), Times.Once());
            _mockStudentDbContext.Verify(m => m.SaveChanges(), Times.Once());
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
            _mockStudentDbSet.Verify(m => m.Update(It.IsAny<Student>()), Times.Once());
            _mockStudentDbContext.Verify(m => m.SaveChanges(), Times.Once());
        }
    }
}