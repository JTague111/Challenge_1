using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Challenge1Take4Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AddToList_ShouldGetNotNull()
        {
            Menu menu = new Menu();
            content.Name = "Croissant"
            MenuRepository reposiotry = new MenuRepository

            repository.AddFoodToList(menu);
            Menu menuFromList = repository.GetFoodByName

            Assert.IsNotNull(foodFromList);
        }
        [testMethod]
        public void DeleteContent_ShouldReturnTrue()
        {
            // Arrange

            // Act
            bool deleteResult = _repo.RemoveFoodFromList(_menu.Name)

            // Assert
            Assert.IsTrue(deleteResult);
        }
    }
}
