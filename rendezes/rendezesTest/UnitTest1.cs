using System;
using Xunit;
using rendezes;

namespace rendezesTest
{
    public class SorterTests
    {
        private readonly Sorter uut = new Sorter();

        public SorterTests()
        {
            
        }

        [Fact]
        public void EmptyArray()
        {
            int[] array = new int[0];

            uut.Sort<int>(array);

            Assert.Equal(new int[0], array);
        }

        [Fact]
        public void OneElementArray()
        {
            //Given
            int[] array = new int[] {1};
            //When
            uut.Sort<int>(array);
            //Then
            Assert.Equal(new int[] {1}, array);
        }

        [Fact]
        public void SmallestElementAtEnd()
        {
            //Given
            int[] array = new int[] { 1, 0};
            //When
            uut.Sort<int>(array);
            //Then
            Assert.Equal(new int[] {0, 1}, array);
        }
    }
}
