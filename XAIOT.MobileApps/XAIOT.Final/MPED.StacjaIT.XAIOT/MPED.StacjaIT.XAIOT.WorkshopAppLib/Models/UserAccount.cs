using MPED.StacjaIT.XAIOT.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MPED.StacjaIT.XAIOT.Models
{
    public class UserAccountToken
    {
        public string access_token { get; set; }
        public string expires_in { get; set; }
        public string token_type { get; set; }
        public string userName { get; set; }
    }
    public class UserAccount : BindableBase
    {
        private string id;
        private string userName;
        private string email;
        private string password;
        private string phoneNumber;
        private string firstName;
        private string lastName;
        private string departmentId;
        private string userAccountTypeId;
        private bool isActive;
        private byte[] photo;
        private bool isChangePasswordFormActive;
        private DateTime? lastLoggedOn;
        private ICommand saveCommand;
        private ICommand deleteCommand;

        public bool IsPasswordValid { get; set; }
        public string Id
        {
            get { return this.id; }
            set { this.SetProperty(ref this.id, value); }
        }
        public string UserName
        {
            get { return this.userName; }
            set { this.SetProperty(ref this.userName, value); }
        }
        public string Email
        {
            get { return this.email; }
            set { this.SetProperty(ref this.email, value); }
        }
        public string UserPassword
        {
            get { return this.password; }
            set { this.SetProperty(ref this.password, value); }
        }
        public string PhoneNumber
        {
            get { return this.phoneNumber; }
            set { this.SetProperty(ref this.phoneNumber, value); }
        }
        public string FirstName
        {
            get { return this.firstName; }
            set { this.SetProperty(ref this.firstName, value); }
        }
        public string LastName
        {
            get { return this.lastName; }
            set { this.SetProperty(ref this.lastName, value); }
        }
        public string DepartmentId
        {
            get { return this.departmentId; }
            set { this.SetProperty(ref this.departmentId, value); }
        }
        public string UserAccountTypeId
        {
            get { return this.userAccountTypeId; }
            set { this.SetProperty(ref this.userAccountTypeId, value); }
        }
        public bool IsActive
        {
            get { return this.isActive; }
            set { this.SetProperty(ref this.isActive, value); }
        }
        public bool IsChangePasswordFormActive
        {
            get { return this.isChangePasswordFormActive; }
            set { this.SetProperty(ref this.isChangePasswordFormActive, value); }
        }
        public DateTime? LastLoggedOn
        {
            get { return this.lastLoggedOn; }
            set { this.SetProperty(ref this.lastLoggedOn, value); }
        }

        public byte[] Photo
        {
            get { return this.photo; }
            set { this.SetProperty(ref this.photo, value); }
        }

        public string Status
        {
            get { return this.isActive == true ? "Aktywny" : "Nieaktywny"; }
        }

        public string PhotoFileName { get; set; }

        //public static explicit operator RegisterBindingModel(UserAccountViewModel user)
        //{
        //    if (user == null)
        //        return null;

        //    RegisterBindingModel obj = new RegisterBindingModel()
        //    {
        //        UserName = user.UserName,
        //        Email = user.Email,
        //        DepartmentId = user.DepartmentId,
        //        FirstName = user.FirstName,
        //        IsActive = user.IsActive,
        //        LastName = user.LastName,
        //        PhoneNumber = user.PhoneNumber,
        //        Photo = user.Photo,
        //        UserAccountTypeId = user.UserAccountTypeId
        //    };

        //    return obj;
        //}

        //public static explicit operator UserAccountViewModel(UserAccountModel user)
        //{
        //    if (user == null)
        //        return null;

        //    UserAccountViewModel obj = new UserAccountViewModel()
        //    {
        //        UserName = user.UserName,
        //        Email = user.Email,
        //        DepartmentId = user.DepartmentId,
        //        FirstName = user.FirstName,
        //        IsActive = user.IsActive,
        //        LastName = user.LastName,
        //        PhoneNumber = user.PhoneNumber,
        //        Photo = user.Photo,
        //        UserAccountTypeId = user.UserAccountTypeId,
        //        Id = user.Id,
        //        LastLoggedOn = user.LastLoggedOn,
        //        IsChangePasswordFormActive = user.IsChangePasswordFormActive
        //    };

        //    return obj;
        //}

        //public static explicit operator SaveUserAccountModel(UserAccountViewModel user)
        //{
        //    if (user == null)
        //        return null;

        //    SaveUserAccountModel obj = new SaveUserAccountModel()
        //    {
        //        UserName = user.UserName,
        //        Email = user.Email,
        //        DepartmentId = user.DepartmentId,
        //        FirstName = user.FirstName,
        //        IsActive = user.IsActive,
        //        LastName = user.LastName,
        //        PhoneNumber = user.PhoneNumber,
        //        Photo = user.Photo,
        //        UserAccountTypeId = user.UserAccountTypeId,
        //        LastLoggedOn = user.LastLoggedOn,
        //        IsChangePasswordFormActive = user.IsChangePasswordFormActive
        //    };

        //    return obj;
        //}

        public ICommand SaveCommand
        {
            get { return this.saveCommand; }
        }

        public ICommand DeleteCommand
        {
            get { return this.deleteCommand; }
        }

        //private async void Save_Executed(object parameter)
        //{
        //    Mouse.OverrideCursor = Cursors.Wait;

        //    try
        //    {
        //        if (AppHelper.IsValid((DependencyObject)((MainWindow)Window.GetWindow((DependencyObject)parameter)).MainFrame.NavigationService.Content) && this.IsPasswordValid)
        //        {
        //            if (string.IsNullOrEmpty(this.Id))
        //            {
        //                RegisterBindingModel rbm = (RegisterBindingModel)this;

        //                PasswordBox passwordBox = parameter as PasswordBox;

        //                if (passwordBox != null)
        //                {
        //                    if (!string.IsNullOrEmpty(passwordBox.Password))
        //                    {
        //                        rbm.Password = passwordBox.Password;
        //                        rbm.ConfirmPassword = passwordBox.Password;
        //                    }
        //                    else
        //                    {
        //                        MessageBox.Show(UITexts.PasswordValidationError);
        //                    }
        //                }

        //                //rbm.IsActive = true;

        //                UserAccountWebService userAccountWebService = new UserAccountWebService();
        //                await userAccountWebService.RegisterUser(App.Token.access_token, rbm);
        //            }
        //            else
        //            {
        //                SaveUserAccountModel suam = (SaveUserAccountModel)this;

        //                UserAccountWebService userAccountWebService = new UserAccountWebService();
        //                await userAccountWebService.SaveUser(App.Token.access_token, suam, this.Id);
        //            }

        //            AccountPage accountPage = parameter as AccountPage;
        //            if (accountPage != null)
        //            {
        //                ((MainWindow)Window.GetWindow((DependencyObject)parameter)).ChangePage(accountPage);
        //            }
        //            else
        //            {
        //                ((MainWindow)Window.GetWindow((DependencyObject)parameter)).ChangePage("UsersListPage.xaml");
        //            }
        //        }
        //        else
        //        {
        //            MessageBox.Show(UITexts.FormInvalid);
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        LogHelper.Error(GetType(), ex);
        //    }
        //    finally
        //    {
        //        Mouse.OverrideCursor = null;
        //    }
        //}

        //private async void Delete_Executed(object parameter)
        //{
        //    Mouse.OverrideCursor = Cursors.Wait;

        //    try
        //    {
        //        MessageBoxResult result = MessageBox.Show(string.Format(UITexts.UserAccountDeleteQuestion, this.FirstName, this.LastName), UITexts.Confirmation, MessageBoxButton.YesNo, MessageBoxImage.Question);
        //        if (result == MessageBoxResult.Yes)
        //        {
        //            UserAccountWebService userAccountWebService = new UserAccountWebService();
        //            await userAccountWebService.DeleteUser(App.Token.access_token, this.Id);
        //        }

        //        ((MainWindow)Window.GetWindow((DependencyObject)parameter)).ChangePage("UsersListPage.xaml");
        //    }
        //    catch (Exception ex)
        //    {
        //        LogHelper.Error(GetType(), ex);
        //    }
        //    finally
        //    {
        //        Mouse.OverrideCursor = null;
        //    }
        //}

        //public UserAccountViewModel()
        //{
        //    this.saveCommand = new DelegateCommand(this.Save_Executed);
        //    this.deleteCommand = new DelegateCommand(this.Delete_Executed);
        //}
    }
}
