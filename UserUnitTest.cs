using Moq;
using SampleXUnitTest.Services;

namespace XUnitTest
{
    public class UserUnitTest
    {
        [Fact]
        public void UserService_IsUserCreated_returnTrue()
        {
            //Arrange
            var userservices = new UserService();
            string username = "Bibinkp";
            string password = "1234567890";
            var mockservices = new Mock<UserService>();
            mockservices.Setup(s => s.AddUserToDb(It.IsAny<string>(), It.IsAny<string>())).Returns("Tested");
            //Act
            bool IsValid= mockservices.Object.CreateUser(username, password);
            //Assert
            Assert.True(IsValid);
        }
        [Fact]
        public void UserService_IsUserLogin_ReturnTrue()
        {
            //Arrange
            var userservices = new UserService();
            string username = "Bibinkp";
            string password = "1234567890";
            var mockservices = new Mock<UserService>();
            mockservices.Setup(s=>s.LoginUserDb(username,password)).Returns(true);
            //act
            var isValid = mockservices.Object.LoginUserDb(username, password);
            //assert
            Assert.True(isValid);
        }
    }
}