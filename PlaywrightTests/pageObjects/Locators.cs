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

    public static class AddTeamMember
    {
        public const string RoleDropdown_Xpath = "//select[@id='memberRoleSelection']";
        public static string RoleOption_Xpath(string roleValue) => $"//option[@value='{roleValue}']";

        public const string FirstName_Xpath = "//input[@id='firstName']";
        public const string LastName_Xpath = "//input[@id='lastName']";
        public const string Email_Xpath = "//input[@id='email']";
        public const string Phone_Xpath = "//input[@id='phone']";
        public const string Username_Xpath = "//input[@id='username']";
        public const string Password_Xpath = "//input[@id='password']";
        public const string ConfirmPassword_Xpath = "//input[@id='confirmPassword']";

        public const string SaveAndCloseButton_Xpath = "//button[@class='btn btn-primary btn-icon-left']";

        public const string AssignStudentsButton_Xpath = "//button[@class='btn btn-success btn-icon']";

        public const string TeacherTypeDropdown_Xpath = "//select[@id='memberEduTypeSelection']";
        public static string TeacherTypeOption_Xpath(string teacherTypeValue) => $"//option[@value='{teacherTypeValue}']";

        public const string AvailableStudentsText_Xpath = "(//h3)[2]";

        public static string Alert_Xpath = "//ngb-alert[@role='alert']";
        public static string SearchTeamMembers_Xpath = "//input[@placeholder='Search team members']";

        public static string TeamMemberRowColumn = "//tbody/tr[{0}]/td[{1}]";
        public static string DeleteUserbutton_Xpath = "//button[@type='button'][2]";
        public static string DeleteUserPop_UP_Xpath = "(//button[@type='button'])[7]";
    }
}
