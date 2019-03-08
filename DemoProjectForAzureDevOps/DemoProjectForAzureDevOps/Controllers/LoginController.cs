using BAL.LoginAndSignUpOperations;
using BAL.Models;
using BAL.Repositories;
using DemoProjectForAzureDevOps.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace DemoProjectForAzureDevOps.Controllers
{
	//[CustomException]
	public class LoginController : Controller
	{
		private IUnitOfWork _repoUnitOfWork;
		public LoginController()
		{
			_repoUnitOfWork = new UnitOfWork();
		}
		public ActionResult LoginView()
		{
			Session["Signup"] = null;
			return View();
		}
		[HttpPost]
		public ActionResult LoginView(LoginMaster loginMaster)
		{
			try
			{
				if (loginMaster != null && !string.IsNullOrEmpty(loginMaster.UserName) && !string.IsNullOrEmpty(loginMaster.Password))
				{
					if (!_repoUnitOfWork.LoginRepository.ValidateUserName(loginMaster.UserName))
					{
						string _devOpsApplication = System.Configuration.ConfigurationManager.AppSettings["Key"];
						string _devOpsHasTable = System.Configuration.ConfigurationManager.AppSettings["HasTable"];
						if (!string.IsNullOrEmpty(_devOpsApplication) && !string.IsNullOrEmpty(_devOpsHasTable))
						{
							string encryptedPasword = loginMaster.Password.GetEncryptedPassword(_devOpsApplication, _devOpsHasTable);
							if (!string.IsNullOrEmpty(encryptedPasword))
							{
								var loginMasterData = _repoUnitOfWork.LoginRepository.LoginUser(loginMaster.UserName, encryptedPasword);
								loginMaster.Message = "User Not Found. Signup";

								if (loginMasterData != null && loginMasterData.LoginUserId != null)
								{

								}
								else
								{
									//loginMaster.Message = "User Not Found. Signup";
								}
							}
						}
					}
				}
			}
			catch (Exception ex)
			{

			}
			return View(loginMaster);
		}
		public string ForgotPassword(string userName)
		{
			try
			{
				if (!string.IsNullOrEmpty(userName))
				{
					string _devOpsApplication = System.Configuration.ConfigurationManager.AppSettings["Key"];
					string _devOpsHasTable = System.Configuration.ConfigurationManager.AppSettings["HasTable"];
					if (!string.IsNullOrEmpty(_devOpsApplication) && !string.IsNullOrEmpty(_devOpsHasTable))
					{
						string encryptedUserName = userName.GetEncryptedPassword(_devOpsApplication, _devOpsHasTable);
						if (!string.IsNullOrEmpty(encryptedUserName))
						{
							ExtensionMethods.SendResetPasswordLink("vsrivastava@ishir.com", encryptedUserName);
						}
					}

					return "Success";
				}
			}
			catch (Exception ex)
			{
				return "Failed";
			}
			return "Success";
		}
		public ActionResult ResetPassword(string ResetPasswordRequest)
		{
			try
			{
				if (!string.IsNullOrEmpty(ResetPasswordRequest))
				{
					string _devOpsApplication = System.Configuration.ConfigurationManager.AppSettings["Key"];
					string _devOpsHasTable = System.Configuration.ConfigurationManager.AppSettings["HasTable"];
					if (!string.IsNullOrEmpty(_devOpsApplication) && !string.IsNullOrEmpty(_devOpsHasTable))
					{
						string encryptedUserName = ResetPasswordRequest.GetDecryptedPassword(_devOpsApplication, _devOpsHasTable);
					}
					return View();
				}
			}
			catch (Exception ex)
			{
				return View("Login");
			}
			return View("Login");
		}
		public ActionResult Signup()
		{
			Session["Signup"] = "True";
			return View();
		}
		[HttpPost]
		public ActionResult Signup(UserProfileMaster userProfileData)
		{
			try
			{
				if (userProfileData != null && !string.IsNullOrEmpty(userProfileData.UserName) && !string.IsNullOrEmpty(userProfileData.FirstName) && !string.IsNullOrEmpty(userProfileData.LastName) && !string.IsNullOrEmpty(userProfileData.PrimaryEmail) && !string.IsNullOrEmpty(userProfileData.MobileNumber))
				{
					DAL.DbContextSettings.UserProfileMaster castedUserProfileData = new DAL.DbContextSettings.UserProfileMaster();
					castedUserProfileData = userProfileData.GetCastedObject<DAL.DbContextSettings.UserProfileMaster>(castedUserProfileData);
					if (castedUserProfileData != null && !string.IsNullOrEmpty(castedUserProfileData.PrimaryEmail))
					{
						castedUserProfileData.UserProfileId = Guid.NewGuid();
						_repoUnitOfWork.SignupRepository.Add(castedUserProfileData);
						_repoUnitOfWork.Complete();
						if (castedUserProfileData.UserProfileId != null)
						{
							DAL.DbContextSettings.LoginMaster castedLoginMaster = new DAL.DbContextSettings.LoginMaster();
							castedLoginMaster = userProfileData.GetCastedObject<DAL.DbContextSettings.LoginMaster>(castedLoginMaster);
							castedLoginMaster.LoginMasterId = Guid.NewGuid();
							castedLoginMaster.UserName = userProfileData.UserName;
							string _devOpsApplication = System.Configuration.ConfigurationManager.AppSettings["Key"];
							string _devOpsHasTable = System.Configuration.ConfigurationManager.AppSettings["HasTable"];
							string encryptedUserName = string.Empty;
							if (!string.IsNullOrEmpty(_devOpsApplication) && !string.IsNullOrEmpty(_devOpsHasTable))
							{
								encryptedUserName = userProfileData.UserName.GetEncryptedPassword(_devOpsApplication, _devOpsHasTable);
								if (!string.IsNullOrEmpty(encryptedUserName))
									castedLoginMaster.LoginPassword = encryptedUserName;
							}
							castedLoginMaster.UserProfileId = castedUserProfileData.UserProfileId;
							_repoUnitOfWork.LoginRepository.Add(castedLoginMaster);
							int saved = _repoUnitOfWork.Complete();
							if (saved > -1)
							{
								string guidToken = castedLoginMaster.LoginMasterId.ToString();
								if (!string.IsNullOrEmpty(_devOpsApplication) && !string.IsNullOrEmpty(_devOpsHasTable))
									guidToken = guidToken.GetEncryptedPassword(_devOpsApplication, _devOpsHasTable);
								ExtensionMethods.SendResetPasswordLink("vsrivastava@ishir.com", encryptedUserName, true, guidToken);
								Session["Signup"] = null;
								Session["SignupSuccessfully"] = "True";
								return RedirectToAction("LoginView");
							}
						}
					}
				}
				else
					return View();
			}
			catch (Exception ex)
			{

			}
			return View();
		}
		public ActionResult SetPassword(string PasswordRequest, string token)
		{
			try
			{
				if (!string.IsNullOrEmpty(PasswordRequest) && !string.IsNullOrEmpty(token))
				{
					string encryptedUserName = string.Empty;
					string _devOpsApplication = System.Configuration.ConfigurationManager.AppSettings["Key"];
					string _devOpsHasTable = System.Configuration.ConfigurationManager.AppSettings["HasTable"];
					if (!string.IsNullOrEmpty(_devOpsApplication) && !string.IsNullOrEmpty(_devOpsHasTable))
					{
						encryptedUserName = PasswordRequest.GetDecryptedPassword(_devOpsApplication, _devOpsHasTable);
						token = token.GetDecryptedPassword(_devOpsApplication, _devOpsHasTable);
					}
					DAL.DbContextSettings.LoginMaster logMaster = new DAL.DbContextSettings.LoginMaster();
					logMaster.UserName = encryptedUserName;
					logMaster.LoginMasterId = Guid.Parse(token);
					return View(logMaster);
				}
				return View();
			}
			catch (Exception ex)
			{
				return View();
			}
		}
		[HttpPost]
		public ActionResult SetPassword(DAL.DbContextSettings.LoginMaster _loginMaster)
		{
			try
			{
				DAL.DbContextSettings.LoginMaster _loginMasterForUpdate = _repoUnitOfWork.LoginRepository.Find(a => a.LoginMasterId == _loginMaster.LoginMasterId);
				_loginMasterForUpdate.LoginPassword = _loginMaster.LoginPassword;
				_repoUnitOfWork.LoginRepository.Update(_loginMasterForUpdate);
				int updatedId = _repoUnitOfWork.Complete();
				if (updatedId > -1)
				{
					return RedirectToAction("LoginView");
				}
				return View();
			}
			catch (Exception ex)
			{
				return View("Login");
			}

		}
	}
}