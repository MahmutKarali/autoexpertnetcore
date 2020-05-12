using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using WebAPI.Helper;
using WebAPI.Models;

namespace WebAPI.Component
{
    public class UserComponent
    {
        static FirebaseConnection firebase = new FirebaseConnection();

        public static async System.Threading.Tasks.Task SaveUserAsync(UserModel model)
        {
            model.Id = Guid.NewGuid().ToString();
            string clearPasswd = GeneralHelper.CreateRandomPassword(5);
            model.Password = HashHelper.GenerateSaltedHash(new SecureData(clearPasswd), new SecureData(model.UserName.ToLower())).ToString(); ;
            model.RemainingCount = 5;

            var client = new FireSharp.FirebaseClient(firebase.config);
            var get = client.Get(@"User/");

            var rawdata = JsonConvert.DeserializeObject<Dictionary<string, UserModel>>(get.Body);
            List<UserModel> list = new List<UserModel>();

            if (rawdata != null)
            {
                foreach (var item in rawdata)
                {
                    list.Add(item.Value);
                }

                if (list.Where(q => q.UserName.Equals(model.UserName) || q.Email.Equals(model.Email)).ToList().Count != 0)
                {
                    throw new Exception("hata");
                }
            }
            await client.PushAsync(@"User/", model);
            await MailHelper.SendMail(model.Email, "Sayın " + model.UserName + " uygulamaya giriş için şifreniz : " + clearPasswd + "\n Kullanım hakkınız 5 dir.");
        }

        public static async System.Threading.Tasks.Task UpdateUser(string username)
        {
            var client = new FireSharp.FirebaseClient(firebase.config);
            var get = client.Get(@"User/");

            var rawdata = JsonConvert.DeserializeObject<Dictionary<string, UserModel>>(get.Body);
            List<UserModel> list = new List<UserModel>();

            if (rawdata != null)
            {
                foreach (var item in rawdata)
                {
                    if (item.Value.UserName == username)
                    {
                        UserModel user = item.Value;
                        user.RemainingCount -= 1;
                        await client.UpdateAsync(@"User/" + item.Key, user);
                    }
                }
            }
        }

        public static bool CheckUser(UserModel user, UserModel model)
        {
            if (HashHelper.GenerateSaltedHash(new SecureData(model.Password), new SecureData(model.UserName.ToLower())).ToString() == user.Password)
            {
                return true;
            }

            return false;
        }

        public static UserModel GetUser(string userName)
        {
            var client = new FireSharp.FirebaseClient(firebase.config);
            var get = client.Get(@"User/");

            var deser = JsonConvert.DeserializeObject<Dictionary<string, UserModel>>(get.Body);
            List<UserModel> list = new List<UserModel>();

            foreach (var item in deser)
            {
                list.Add(item.Value);
            }

            return list.Where(q => q.UserName.Equals(userName)).FirstOrDefault();
        }
    }
}
