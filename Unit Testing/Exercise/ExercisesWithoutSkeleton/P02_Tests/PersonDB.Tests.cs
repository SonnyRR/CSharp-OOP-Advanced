using System.Linq;
using System.Reflection;
using NUnit.Framework;
using P02_ExtendedDatabase.Models;
namespace Tests
{
    public class Tests
    {

        private Database personDB;

        [SetUp]
        public void Setup()
        {
            personDB = new Database();
        }

        [Test]
        public void PersonDB_Constructor_ShouldInitializeEmptyDB()
        {
            //Arrange
            FieldInfo[] fields = typeof(Database)
          .GetFields(BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance);

            int settedSize = (int)fields.Where(x => x.Name == "size")
                .FirstOrDefault()
                .GetValue(personDB);

            Person[] internalArray = (Person[])fields.Where(x => x.Name == "internalArray")
                .FirstOrDefault()
                .GetValue(personDB);

            int sizeOfInternalArray = internalArray.Length;

            // Assert

            Assert.That(sizeOfInternalArray, Is.EqualTo(settedSize), "The constructor does not set the size of the array to the correct internal const value.");
        }

        [Test]
        public void PersonDB_Add_ShouldThrowExceptionIfUserWithTheSameIdIsPresent()
        {
            // Arrange
            Person firstPerson = new Person(13023, "sampleUserName");
            Person secondPerson = new Person(13023, "otherName");

            // Act
            personDB.Add(firstPerson);

            // Assert
            Assert.That(() => personDB.Add(secondPerson),
                Throws.InvalidOperationException.With.Message.EqualTo("There is already a person with the same id!"));
        }

        [Test]
        public void PersonDB_Add_ShouldThrowExceptionIfUserWithTheSameUsernameIsPresent()
        {
            // Arrange
            Person firstPerson = new Person(5342, "sampleUserName");
            Person secondPerson = new Person(123, "sampleUserName");

            // Act
            personDB.Add(firstPerson);

            // Assert
            Assert.That(() => personDB.Add(secondPerson),
                Throws.InvalidOperationException.With.Message.EqualTo("There is already a person with the same username!"));
        }
    }
}