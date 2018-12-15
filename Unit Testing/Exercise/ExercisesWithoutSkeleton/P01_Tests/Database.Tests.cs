namespace Tests
{
    using System;
    using System.Linq;
    using System.Reflection;
    using NUnit.Framework;
    using P01_Database.Models;

    [TestFixture]
    public class DataBaseTests
    {

        [Test]
        public void DBTest_EmptyConstructor_ShouldInitializeExactSize()
        {
            // Arrange
            Database localDB = new Database();

            // Act
            FieldInfo[] fields = typeof(Database)
                .GetFields(BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance);

            int settedSize = (int)fields.Where(x => x.Name == "size")
                .FirstOrDefault()
                .GetValue(localDB);

            int?[] internalArray = (int?[])fields.Where(x => x.Name == "internalArray")
                .FirstOrDefault()
                .GetValue(localDB);

            int sizeOfInternalArray = internalArray.Length;

            // Assert

            Assert.That(sizeOfInternalArray, Is.EqualTo(settedSize), "The constructor does not set the size of the array to the correct internal const value.");
        }

        [Test]
        public void DBTest_Constructor_ShouldInitializeWithGivenArrayParameter()
        {
            // Arrange
            int[] valuesToAdd = { 1, 2, 3, 4, 5, 6 };

            // Act
            Database localDB = new Database(valuesToAdd);

            var internalArray = (int?[])typeof(Database)
                .GetField("internalArray", BindingFlags.Instance | BindingFlags.NonPublic)
                .GetValue(localDB);

            var values = internalArray.Where(x => x != null)
                .Select(x => x.GetValueOrDefault())
                .ToArray();

            //Assert 
            Assert.That(values.Length, Is.EqualTo(valuesToAdd.Length), "Internal array count mismatch");
        }

        [Test]
        public void DBTest_Constructor_ShouldThrowExceptionIfInputArraySizeIsLongerThan16()
        {

            //Arrange
            int[] valuesToAdd = new int[17];
            Database localDB;

            //Assert
            Assert.Throws<InvalidOperationException>(() => localDB = new Database(valuesToAdd));
        }

        [Test]
        [TestCase(new int[] { }, 222)]
        [TestCase(new int[] { 1, }, 2)]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, 4)]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 }, 64)]
        public void DBTest_Add_ShouldAddAnElementAtNextFreeCell(int[] valuesToAdd, int numberToAdd)
        {
            // Arrange 
            Database localDB = new Database(valuesToAdd);

            // Act && Assert
            Assert.DoesNotThrow(() => localDB.Add(numberToAdd));
        }

        [Test]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 }, 64)]

        public void DBTest_Add_ShouldThrowExceptionIfMoreThan16ElementsAreAdded(int[] valuesToAdd, int numberToAdd)
        {
            // Arrange
            Database localDB = new Database(valuesToAdd);

            // Act
            Assert.That(() => localDB.Add(numberToAdd), Throws.InvalidOperationException.With.Message.EqualTo("DB is full!"));
        }

        [Test]
        [TestCase(new int[] { 1, })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 })]
        public void DBTest_Add_ShouldRemoveElement(int[] initValues)
        {
            // Arrange
            Database localDB = new Database(initValues);

            // Act
            var internalArrayValue = (int?[])typeof(Database)
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .Where(x => x.Name == "internalArray")
                .FirstOrDefault()
                .GetValue(localDB);

            var internalArrayLength = internalArrayValue
                .Where(x => x != null)
                .Count();

            localDB.Remove();
            var elementsAfterOperation = localDB.Fetch();

            // Assert
            Assert.That(internalArrayLength - 1, Is.EqualTo(elementsAfterOperation.Length), "Remove operation was not successful!");
        }

        [Test]
        [TestCase(new int[] { 1, })]
        public void DBTest_Add_ShouldThrowExceptionIfNoElementsAreFound(int[] initValues)
        {
            // Arrange
            Database localDB = new Database(initValues);

            // Act & Assert
            localDB.Remove();

            Assert.That(() => localDB.Remove(),
                Throws.InvalidOperationException.With.Message
                .EqualTo("DB is empty!"));
        }
    }
}