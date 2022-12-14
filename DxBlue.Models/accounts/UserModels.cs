using System.Collections.Generic;

namespace DxBlue.Models.accounts
{
    public class UserModel
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string DisplayName { get; set; }
        public int BranchId { get; set; }
        public int RMA_contactId { get; set; }
        public int SALES_contactId { get; set; }
        public bool Disable { get; set; }
        public string UserSource { get; set; }
        public string ReturnUrl { get; set; }
        public string Platform { get; set; }
        public bool IsValid { get; set; } = false;
        public bool Keep_logged { get; set; } = false;
        public string ProfilePic { get; set; } = "";
        public int DefaultBranchId { get; set; }
        public string UserType { get; set; }
        public string ContactNo { get; set; }
        //public string Areas { get; set; }
        public string Status { get; set; }

        public List<UserManagerModel> UserManagers { get; set; }
        public List<UserAreaModel> UserAreas { get; set; }
        public List<UserRoleModel> UserRoles { get; set; }

        public List<int> Managers { get; set; }
        public List<int> Areas { get; set; }
        public List<int> Roles { get; set; }
        public int DaysLock { get; set; }
        public int IsCustomer { get; set; }
        public int SourceId { get; set; }
        public int CustomerId { get; set; }
        public bool IsDsrAccountStatus { get; set; } = false;
    }
    public class UserManagerModel
    {
        public int ManagerId { get; set; }
        public string ManagerName { get; set; }
    }
    public class UserAreaModel
    {
        public int AreaId { get; set; }
        public string AreaName { get; set; }
    }

    public class UserTypeModel
    {
        public string UserTypeCode { get; set; }
        public string UserTypeName { get; set; }
    }
    public class UserRoleModel
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
    }
    public class ChangePasswordModel
    {
        public int LoginId { get; set; }
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
