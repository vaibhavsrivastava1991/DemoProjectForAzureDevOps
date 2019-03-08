using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BAL.LoginAndSignUpOperations
{
	public static class ExtensionMethods
	{
		public static T GetCastedObject<T>(this object castingObject, T castInto)
		{
			try
			{
				PropertyInfo[] allProp = castingObject.GetType().GetProperties();
				if (allProp != null && allProp.Count() > 0)
				{
					foreach (var eachProp in allProp)
					{
						object at = castingObject.GetType().GetProperty(eachProp.Name).GetValue(castingObject);
						if (castingObject.GetType().GetProperty(eachProp.Name) != null)
							castInto.GetType().GetProperty(eachProp.Name).SetValue(castInto, at);
					}
				}
			}
			catch (Exception)
			{

			}
			return castInto;
		}
		public static string GetEncryptedPassword(this string password, string keyForDecrypt, string _hasTableKey)
		{
			try
			{
				string ToReturn = "";
				string _key = keyForDecrypt;
				string _iv = _hasTableKey;
				byte[] _ivByte = { };
				_ivByte = System.Text.Encoding.UTF8.GetBytes(_iv.Substring(0, 8));
				byte[] _keybyte = { };
				_keybyte = System.Text.Encoding.UTF8.GetBytes(_key.Substring(0, 8));
				MemoryStream ms = null;
				CryptoStream cs = null;
				byte[] inputbyteArray = System.Text.Encoding.UTF8.GetBytes(password);
				using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
				{
					ms = new MemoryStream();
					cs = new CryptoStream(ms, des.CreateEncryptor(_keybyte, _ivByte), CryptoStreamMode.Write);
					cs.Write(inputbyteArray, 0, inputbyteArray.Length);
					cs.FlushFinalBlock();
					ToReturn = Convert.ToBase64String(ms.ToArray());
				}
				return ToReturn;
			}
			catch (Exception ae)
			{
				return "";
			}
		}
		public static string GetDecryptedPassword(this string password, string keyForDecrypt, string _hasTableKey)
		{

			try
			{
				string ToReturn = "";
				string _key = keyForDecrypt;
				string _iv = _hasTableKey;
				byte[] _ivByte = { };
				_ivByte = System.Text.Encoding.UTF8.GetBytes(_iv.Substring(0, 8));
				byte[] _keybyte = { };
				_keybyte = System.Text.Encoding.UTF8.GetBytes(_key.Substring(0, 8));
				MemoryStream ms = null; CryptoStream cs = null;
				byte[] inputbyteArray = new byte[password.Replace(" ", "+").Length];
				inputbyteArray = Convert.FromBase64String(password.Replace(" ", "+"));
				using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
				{
					ms = new MemoryStream();
					cs = new CryptoStream(ms, des.CreateDecryptor(_keybyte, _ivByte), CryptoStreamMode.Write);
					cs.Write(inputbyteArray, 0, inputbyteArray.Length);
					cs.FlushFinalBlock();
					Encoding encoding = Encoding.UTF8;
					ToReturn = encoding.GetString(ms.ToArray());
				}
				return ToReturn;
			}
			catch (Exception ae)
			{
				return "";
				//throw new Exception(ae.Message, ae.InnerException);
			}
		}
		async public static Task SendResetPasswordLink(this string email, string userName, bool isSignup = false, string loginUserId = "")
		{
			try
			{
				await Task.Run(() =>
				{
					string resetPasswordLink = string.Empty;
					if (!isSignup)
						resetPasswordLink = "http://localhost:51179/Login/ResetPassword?ResetPasswordRequest=" + userName;
					else
						resetPasswordLink = "http://localhost:51179/Login/SetPassword?PasswordRequest=" + userName + "&token=" + loginUserId;
					MailMessage mail = new MailMessage();
					string emailSubject = string.Empty;
					if (!isSignup)
						emailSubject = "Forgot Password Reset Link";
					else
						emailSubject = "Update Password";
					SmtpClient SmtpServer = new SmtpClient("smtp.office365.com", 587);
					mail.From = new MailAddress("vsrivastava@ishir.com");
					mail.To.Add(email);
					mail.Subject = emailSubject;//MAIL_Subject;
					if (!isSignup)
						mail.Body = "<html><head></head><body><br>Reset Password Link: " + resetPasswordLink + "</p>Sincerely<br>Test Mail</body></html>";
					else
						mail.Body = "<html><head></head><body><br>Successfully Signedup. Please Click On Link To Reset Your Password: " + resetPasswordLink + "</p>Sincerely<br>Test Mail</body></html>";
					mail.IsBodyHtml = true;
					SmtpServer.Credentials = new System.Net.NetworkCredential("vsrivastava@ishir.com", "kgtftmbmfspgbhft");
					SmtpServer.EnableSsl = true;
					SmtpServer.Send(mail);
				});
			}
			catch (Exception ex)
			{

			}
		}
	}
}
