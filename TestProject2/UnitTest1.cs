namespace TestProject2
{
    public class UnitTest1
    {
        [Fact]
        public void Add_TwoPositiveNumbers_ReturnsSum()
        {            // Arrange
            int result = 3;

            // Assert
            Assert.Equal(8, result);
        }
    }
}