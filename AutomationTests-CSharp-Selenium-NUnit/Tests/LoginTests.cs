using NUnit.Framework;
using System.Reflection;

namespace AutomationTests_CSharp_Selenium_NUnit.PageObjectPattern
{
    [TestFixture]
    [Category("Login Tests")]
    public class LoginTests : Base
    {
        [TestCase(Category = "Login", TestName = "Login Authorization")]
        [Description("User is able to log in to the app")]
        public void LoginAuthorization()
        {
            LoginPO login = new LoginPO(Driver);
            Step("User enter nickname");
            login.Username.SendKeys("Admin");
            Step("User enter password");
            login.Password.SendKeys("admin123");
            Step("User click on login button");
            login.LoginButtonClick();
            Step("Compare current URL with the expected");

            AssertCurrentUrl(Driver, "DashboardPage");
        }

        [TestCase(Category = "Login", TestName = "Login incorrect password - negative authorization")]
        [Description("User should get message about invalid credentials")]
        public void LoginIncorrectPassword()
        {
            LoginPO login = new LoginPO(Driver);
            Step("User enter incorrect nickname");
            login.Username.SendKeys("INCORRECT USERNAME");
            Step("User enter incorrect password");
            login.Password.SendKeys("INCORRECT PASSWORD");
            Step("User click on login button");
            login.LoginButtonClick();
            Step("User should get alert about invalid credentials");

            Assert.That(ExpectedConditions.ElementExists(login.InvalidLoginAlert, Driver), "Missing invalid login credentials alert");
        }

        [TestCase(Category = "Login", TestName = "Login missing credential - negative authorization")]
        [Description("User should get message about missing required credentials")]
        public void LoginMissingCredential()
        {
            LoginPO login = new LoginPO(Driver);
            Step("User enter nickname");
            login.Username.SendKeys("Admin");
            Step("User click on login button");
            login.LoginButtonClick();
            Step("User should get message about required missing data");

            Assert.That(login.InvalidCredentialsMessage, Is.EqualTo("Required"));
        }

        [TestCase(Category = "Login", TestName = "Login forgotten password - reset password")]
        [Description("User forget password and clicks reset password button")]
        public void LoginForgottenPassword() 
        {
            LoginPO login = new LoginPO(Driver);
            login.ForgotPasswordButtonClick();
            AssertCurrentUrl(Driver, "PasswordResetPage");
            
            ResetPasswordPO resetPassword = new ResetPasswordPO(Driver);
            resetPassword.UsernameInput.SendKeys("Admin");
            resetPassword.ResetPasswordButtonClick();

            Assert.That(resetPassword.Header, Is.EqualTo("Reset Password link sent successfully"));
        }

        [TestCase(Category = "Login", TestName = "Login forgotten password - cancel process")]
        [Description("User forget password and clicks cancel button on reset password page")]
        public void LoginForgettenPasswordCancel()
        {
            LoginPO login = new LoginPO(Driver);
            login.ForgotPasswordButtonClick();
            AssertCurrentUrl(Driver, "PasswordResetPage");

            ResetPasswordPO resetPassword = new ResetPasswordPO(Driver);
            resetPassword.UsernameInput.SendKeys("Admin");
            resetPassword.CancelButtonClick();

            AssertCurrentUrl(Driver, "LoginPage");
        }
    }
}