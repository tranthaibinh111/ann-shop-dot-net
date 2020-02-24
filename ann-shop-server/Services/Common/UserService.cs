using ann_shop_server.Models;
using ann_shop_server.Utils;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ann_shop_server.Services
{
    public class UserService: IANNService
    {
        public User register(UserRegisterModel data)
        {
            if (checkUser(data.phone.Trim()))
                return null;

            using (var con = new inventorymanagementEntities())
            {
                var now = DateTime.Now;
                var userNew = new User()
                {
                    Phone = data.phone.Trim(),
                    Password = Security.Encrypt(data.password),
                    CreatedDate = now,
                    ModifiedDate = now
                };

                con.Users.Add(userNew);
                con.SaveChanges();

                return userNew;
            }
        }

        public User getUser(UserRegisterModel login)
        {
            using (var con = new inventorymanagementEntities())
            {
                var sha256 = Security.Encrypt(login.password);
                var user = con.Users.Where(x => x.Phone == login.phone && x.Password == sha256).FirstOrDefault();

                return user;
            }
        }

        public Task<User> getUser(string phone, string password)
        {
            return Task.Run(() =>
            {
                using (var con = new inventorymanagementEntities())
                {
                    var sha256 = Security.Encrypt(password);

                    var user = con.Users
                        .Where(x => x.Phone == phone)
                        .Where(x => x.Password == sha256)
                        .FirstOrDefault();

                    return user;
                }
            });
        }

        public User updateInfo(UserInfoModel info)
        {
            using (var con = new inventorymanagementEntities())
            {
                var user = con.Users.Where(x => x.Phone == info.phone).FirstOrDefault();

                if (user == null)
                    return null;

                var textInfo = new CultureInfo("vi-VN", false).TextInfo;

                user.FullName = textInfo.ToTitleCase(info.fullName.Trim());
                user.BirthDay = info.birthday.Date;
                if (info.gender.Trim() == "M" || info.gender.Trim() == "F")
                    user.Gender = info.gender.Trim();
                user.Address = info.address.Trim();
                user.City = info.city.Trim();
                user.ModifiedDate = DateTime.Now;
                con.SaveChanges();

                return user;
            }
        }

        public string createPassword(string phone, string passwordOld, string passwordNew)
        {
            using (var con = new inventorymanagementEntities())
            {
                passwordOld = Security.Encrypt(passwordOld);

                var userOld = con.Users
                    .Where(x => x.Phone == phone)
                    .Where(x => x.Password == passwordOld)
                    .FirstOrDefault();

                if (userOld == null)
                    return null;

                userOld.Password = Security.Encrypt(passwordNew);
                userOld.ModifiedDate = DateTime.Now;
                con.SaveChanges();

                return passwordNew;
            }
        }

        public string changePassword(string phone, string passwordNew)
        {
            using (var con = new inventorymanagementEntities())
            {
                var userOld = con.Users.Where(x => x.Phone == phone).FirstOrDefault();

                if (userOld == null)
                    return null;

                userOld.Password = Security.Encrypt(passwordNew);
                userOld.ModifiedDate = DateTime.Now;
                con.SaveChanges();

                return passwordNew;
            }
        }

        public bool checkUser(string phone)
        {
            using (var con = new inventorymanagementEntities())
            {
                var user = con.Users.Where(x => x.Phone == phone).FirstOrDefault();

                return user != null;
            }
        }

        public string passwordNewByBirthday(string phone, DateTime birthday, string passwordNew)
        {
            using (var con = new inventorymanagementEntities())
            {
                birthday = birthday.Date;

                var user = con.Users
                    .Where(x => x.Phone == phone)
                    .Where(x => x.BirthDay.HasValue && x.BirthDay.Value == birthday)
                    .FirstOrDefault();

                if (user == null)
                    return null;

                user.Password = Security.Encrypt(passwordNew);
                user.ModifiedDate = DateTime.Now;
                con.SaveChanges();

                return passwordNew;
            }
        }
    }
}