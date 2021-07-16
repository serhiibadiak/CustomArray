using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;

namespace CustomArray.Tests
{
    [TestFixture]
    public class Tests
    {
        #region Low
        [Test]
        public void Array_Get_ShouldReturnSameReference()
        {
            //arrange
            var array = new int[] { 1, 2, 3, 4 };
            int first = -5;
            //act
            var custom = new CustomArray<int>(first, array);
            //assert
            Assert.Multiple(() =>
            {
                Assert.AreSame(array, custom.Array, message: "Array property or constructor works incorrectly");
                Assert.AreEqual(array, custom.Array, message: "Array property or constructor works incorrectly");
            });
        }

        [Test]
        public void Array_Get_WithListShouldRetrurnSameReference()
        {
            var expected_list = new List<int>() { 6, 2, -8, 0 };
            int first = 4;

            var custom = new CustomArray<int>(first, expected_list);
            var actual_array = custom.Array;

            Assert.AreEqual(expected_list, actual_array, message: "Array property or constructor works incorrectly");

        }

        [TestCase(-4, 5, -3, 10)]
        [TestCase(1, 7, 2, 4)]
        [TestCase(0, 3, 2, 9)]
        public void Indexer_GetElementAtPosition_ShouldReturnValue(int first, int length, int n, int element)
        {
            //Act
            var custom = new CustomArray<int>(first, length);
            custom[n] = element;
            //Assert
            Assert.AreEqual(element, custom[n], message: "Index get property works incorrectly");

        }
        [TestCase(-1, 6)]
        [TestCase(0, 7)]
        [TestCase(5, 2)]
        public void Length_Get_ShouldReturnCorrectValue(int first, int length)
        {
            // Act
            var custom = new CustomArray<string>(first, length);
            //Assert
            Assert.AreEqual(length, custom.Length, message: "Length get  property works incorrectly ");
        }
        [TestCase(-1, 5)]
        [TestCase(0, 11)]
        [TestCase(7, 3)]
        public void First_Get_ShouldReturnCorrectValue(int first, int length)
        {
            // Act
            var custom = new CustomArray<int>(first, length);

            //Assert
            Assert.AreEqual(first, custom.First, message: "First get property works incorrectly ");
        }
        [TestCase(-8, 4, -5)]
        [TestCase(0, 8, 7)]
        [TestCase(3, 5, 7)]
        public void Last_Get_ShouldReturnCorrectValue(int first, int length, int last)
        {
            //Act
            var custom = new CustomArray<bool>(first, length);

            //Assert
            Assert.AreEqual(last, custom.Last, message: "Last get property works incorrectly ");

        }
        [Test]
        public void CustomArrayProperties_Get_ShouldReturnCorrectValues()
        {
            //Arrange
            int first = 4;
            int length = 4;
            int last = 7;

            //Act
            var custom = new CustomArray<int>(first, 5, 7, 3, 7);
            //Assert
            Assert.AreEqual(first, custom.First, message: "First get property works incorrectly");
            Assert.AreEqual(length, custom.Length, message: "Length get property works incorrectly");
            Assert.AreEqual(last, custom.Last, message: "Last get property works incorrectly");

        }


        #endregion

        //TODO: Uncomment this if you want to check your task for advanced unit tests

        #region advanced
        [Test]
        public void createcustomarray_withnullarray_shoulthrowargumentnullexception()
        {
            //arrange
            int first = 1;
            int[] array = null;
            var expectedex = typeof(ArgumentNullException);
            //act
            var actex = Assert.Catch (() => new CustomArray<int>(first, array));
            //assert
            Assert.AreEqual(expectedex, actex.GetType(),
                message: "customarray can't be created with null array");

            }

            [Test]
            public void createcustomarray_withemptyarray_shoulthrowargumentexception()
            {
                //arrange
                int first = 1;
                int[] array = new int[] { };
                var expectedex = typeof(ArgumentException);
                //act
                var actex = Assert.Catch(() => new CustomArray<int>(first, array));
            //assert
            Assert.AreEqual(expectedex, actex.GetType(),
                message: "customarray can't be created with null array");

        }

        [TestCase(0)]
        [TestCase(-8)]
        [TestCase(-4)]
        public void length_setelementlessthan0_shouldthrowargumentexception(int length)
        {
            //arrange
            int first = 3;
            var expectedex = typeof(ArgumentException);
            //act
            var actex = Assert.Catch (() => { var custom = new CustomArray<int>(first, length); });
            //assert
            Assert.AreEqual(expectedex, actex.GetType(),
                message: "set property in length should throw argumentexception in case of length parameter smaller or equal 0  ");

            }

            [TestCase(4, 6, 3)]
            [TestCase(0, 11, 11)]
            [TestCase(-8, 3, -5)]
            public void indexer_setelementoutofrange_shouldthrowargumentexception(int first, int length, int index)
            {
                //arrange
                int value = -5;
                //act
                var custom = new CustomArray<int>(first, length);

                //assert
                Assert.Throws<ArgumentException>(() => custom[index] = value, message: "indexer  should throw argumentexception ,if index parameter  out of array range");


            }

            [TestCase(-6, 4, -9)]
            [TestCase(0, 3, 7)]
            [TestCase(9, 17, 5)]
            public void indexer_getelementoutofrange_shouldthrowargumentexception(int first, int length, int index)
            {
                //arrange
                var custom = new CustomArray<int>(first, length);
                int result = 0;
                //act -assert 
                var actex = Assert.Throws<ArgumentException>(() => result = custom[index], message: "set indexer works incorrect");

            }

            [Test]
            public void indexer_withnullvalue_shouldthrowargumentnullexception()
            {
                //arrange
                int first = 1;
                int length = 7;
                string value = null;
                int index = 5;
                var custom = new CustomArray<string>(first, length);

                //act &assert 
                Assert.Throws<ArgumentNullException>(() => custom[index] = value, message: "indexer set not throw exception if value is null ");
            }


            [Test]
            public void createcustomarray_withlistwithoutparams_shouldthrowargumentexception()
            {
                //arrange
                int first = 4;
                List<int> list = new List<int>();
                var expectedex = typeof(ArgumentException);
                //act
                var actex = Assert.Catch (() => { var custom = new CustomArray<int>(first, list); });
            //arrange
            Assert.AreEqual(expectedex, actex.GetType(),
                message: "customarray can't be created with list without elements ");

        }

        [Test]
        public void createcustomarray_withlistnull_shouldthrownullreferenceexception()
        {
            //arrange
            int first = 1;
            List<int> list = null;
            var expectedex = typeof(NullReferenceException);
            //act
            var actex = Assert.Catch (() => { var custom = new CustomArray<int>(first, list); });
            //arrange
            Assert.AreEqual(expectedex, actex.GetType(),
                message: "customarray can't be created with null list ");

            }


            [Test]
            public void getenumerator_oflistandcustomarray_shouldhaveequalelements()
            {
                List<int> list = new List<int>()
            {
                5,10,14
            };

                int first = 7;
                CustomArray<int> array = new CustomArray<int>(first, list);

                var en2 = list.GetEnumerator();
                var en = array.GetEnumerator();
                for (int i = 0; i < array.Length; i++)
                {
                    if (en.MoveNext() && en2.MoveNext())
                    {
                        Assert.AreEqual(en.Current, en2.Current, message: "getenumerator works incorretly ");
                    }
                }

            }

            [Test]
            public void getenumerator_usingienumerableexplicitlyoflistandcustomarray_shouldhaveequalelements()
            {
                //arrange

                List<int> expected_list = new List<int>()
            {
                5,10,14
            };
                int first = 7;
                List<int> actual = new List<int>();

                //act
                CustomArray<int> array = new CustomArray<int>(first, expected_list);
                IEnumerable enumerable = array;

                //assert
                foreach (var item in enumerable)
                {
                    actual.Add((int)item);
                }
                Assert.AreEqual(expected_list, actual);

            }
            #endregion

        }
    }
