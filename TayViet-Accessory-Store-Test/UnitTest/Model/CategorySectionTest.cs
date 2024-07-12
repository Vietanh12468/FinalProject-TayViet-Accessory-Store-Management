using FinalProject_TayViet_Accessory_Store_Management.Server.Models;

namespace TayViet_Accessory_Store_Test.UnitTest.Model
{
    public class CategorySectionTest
    {
        CategorySection sampleObject = CONSTANT_TEST_VARIBLE.sampleCategorySection;

        [Theory]
        [InlineData("Hats")]
        [InlineData("Jackets")]
        public void AddCategory_CategorySection_Success(string categoryName)
        {
            sampleObject.AddCategory(categoryName);
            Assert.Contains(categoryName, sampleObject.listCategory);
        }

        [Theory]
        [InlineData("Glasses")]
        [InlineData("Watches")]
        public void AddCategory_CategorySection_Fail(string categoryName)
        {
            Assert.Throws<Exception>(() => sampleObject.AddCategory(categoryName));
        }

        [Theory]
        [InlineData("Hats")]
        [InlineData("Jackets")]
        public void RemoveCategory_CategorySection_Fail(string categoryName)
        {
            Assert.Throws<Exception>(() => sampleObject.RemoveCategory(categoryName));
        }

        [Theory]
        [InlineData("Glasses")]
        [InlineData("Watches")]
        public void RemoveCategory_CategorySection_Success(string categoryName)
        {
            sampleObject.RemoveCategory(categoryName);
            Assert.DoesNotContain(categoryName, sampleObject.listCategory);
        }
    }
}
