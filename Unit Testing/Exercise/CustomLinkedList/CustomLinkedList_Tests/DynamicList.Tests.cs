namespace Tests
{
    using System;
    using NUnit.Framework;
    using CustomLinkedList;
    public class Tests
    {
        [Test]
        public void Constructor_ShouldInitWithNullValues()
        {

            DynamicList<int> testList = new DynamicList<int>();

            Assert.That(testList.Count, Is.EqualTo(0), "Empty DynamicList should have a count of: 0");
        }

        [Test]
        [TestCase(4)]
        [TestCase(-31)]
        [TestCase(0)]
        public void Indexator_GetShouldThrowExceptionOfInvalidIndex(int index)
        {
            DynamicList<int> testList = new DynamicList<int>();
            int tempVar = 0;

            Assert.Throws<ArgumentOutOfRangeException>(
                () => tempVar = testList[index], "Indexator does not throw an exception if invalid index is passed!");
        }

        [Test]
        [TestCase(4)]
        [TestCase(-31)]
        [TestCase(0)]
        public void Indexator_SetShouldThrowExceptionOfInvalidIndex(int index)
        {
            DynamicList<int> testList = new DynamicList<int>();
            int tempVar = 13;

            Assert.Throws<ArgumentOutOfRangeException>(
                () => testList[index] = tempVar, "Indexator does not throw an exception if invalid index is passed!");
        }

        [Test]
        public void AddMethod_ShouldCreateNewNode()
        {
            DynamicList<int> testList = new DynamicList<int>();

            testList.Add(4);

            Assert.That(testList[0], Is.EqualTo(4));
        }

        [Test]
        public void AddMethod_ShouldAddAfterValues()
        {
            DynamicList<int> testList = new DynamicList<int>();

            testList.Add(4);
            testList.Add(123);

            Assert.That(testList[testList.Count - 1], Is.EqualTo(123));
        }

        [Test]
        [TestCase(new int[] { 1, 2, 3 }, 4)]
        [TestCase(new int[] { 1, 2, 3 }, -1)]
        public void RemoveAtMethod_ShouldThrowExceptionIfIndexIsInvalid(int[] valuesToAdd, int index)
        {
            DynamicList<int> testList = new DynamicList<int>();

            for (int i = 0; i < valuesToAdd.Length; i++)
            {
                testList.Add(valuesToAdd[i]);
            }

            Assert.That(() => testList.RemoveAt(index),
                Throws.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 4)]
        [TestCase(new int[] { 1, 2, 3 }, 0)]
        public void RemoveAtMethod(int[] valuesToAdd, int index)
        {
            DynamicList<int> testList = new DynamicList<int>();
            for (int i = 0; i < valuesToAdd.Length; i++)
            {
                testList.Add(valuesToAdd[i]);
            }

            var expectedValue = testList[index];
            var returnedValue = testList.RemoveAt(index);

            Assert.That(expectedValue, Is.EqualTo(returnedValue));
        }

        [Test]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 66)]
        [TestCase(new int[] { 1, 2, 3 }, -13)]
        public void RemoveMethod_ShouldReturnNegativeIfElementIsNotFound(int[] initValues, int elementToRemove)
        {
            DynamicList<int> testList = new DynamicList<int>();
            for (int i = 0; i < initValues.Length; i++)
            {
                testList.Add(initValues[i]);
            }

            var returnedValue = testList.Remove(elementToRemove);

            Assert.That(returnedValue, Is.EqualTo(-1));
        }

        [Test]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 4)]
        [TestCase(new int[] { 1, 2, 3 }, 2)]
        public void RemoveMethod_ShouldReturnIndexOfReturnedElement(int[] initValues, int elementToRemove)
        {
            DynamicList<int> testList = new DynamicList<int>();
            for (int i = 0; i < initValues.Length; i++)
            {
                testList.Add(initValues[i]);
            }

            var returnedValue = testList.Remove(elementToRemove);

            Assert.That(returnedValue, Is.GreaterThanOrEqualTo(0));
        }

        [Test]
        [TestCase(new int[] { 443, 124, -131, 0, 55}, -131, true)]
        [TestCase(new int[] { 443, 124, -131, 0, 55}, 141441, false)]
        public void ContainsMethod_Test(int[] initValues, int numberToFind, bool expectedValue)
        {
            DynamicList<int> testList = new DynamicList<int>();
            for (int i = 0; i < initValues.Length; i++)
            {
                testList.Add(initValues[i]);
            }

            var returnedBoolValue = testList.Contains(numberToFind);

            Assert.That(returnedBoolValue, Is.EqualTo(expectedValue));
        }

        [Test]
        [TestCase(new int[] { 443, 124, -131, 0, 55 }, -131, 2)]
        [TestCase(new int[] { 443, 124, -131, 0, 55 }, 141441, -1)]
        public void IndexOfMethod_Test(int[] initValues, int numberToFind, int expectedValue)
        {
            DynamicList<int> testList = new DynamicList<int>();
            for (int i = 0; i < initValues.Length; i++)
            {
                testList.Add(initValues[i]);
            }

            var returnedIndexValue = testList.IndexOf(numberToFind);

            Assert.That(returnedIndexValue, Is.EqualTo(expectedValue));

        }
    }
}