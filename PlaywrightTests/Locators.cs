public static class Locators
{
    public static class LoginPage
    {
        public const string UsernameInput = "//input[@id='UserName']";
        public const string PasswordInput = "//input[@id='Password']";
        public const string LoginButton = "//button[@id='loginBtn']";
    }

    public static class HomePage
    {
        public const string UsernameDisplay = "//h2[@tabindex='0']/span";
        public const string SetupLink = "(//a[@aria-label='Setup'])[1]";
    }

    public static class SetupPage
    {
        public const string PageTitle = "//h1[@class='pageTitle']";
        public const string ManageTeamMembersLink = "//a[@aria-label='Manage Team Members']";
        public const string AddTeamMemberButton = "//a[@title='Add Team Member']";
    }

    public static class Popups
    {
        public const string CloseButton = "//button[@class='btn-close']";
    }
}