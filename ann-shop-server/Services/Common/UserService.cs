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
    public class UserService: Service<UserService>
    {
        public User register(UserRegisterModel data)
        {
            using (var con = new inventorymanagementEntities())
            {
                if (con.Users.Where(x => x.Phone == data.phone.Trim()).FirstOrDefault() != null)
                    throw new Exception("Số điện thoại này đã tồn tại");

                var now = DateTime.Now;
                var userNew = new User()
                {
                    Phone = data.phone,
                    Password = Security.Encrypt(data.password),
                    CreatedDate = now,
                    ModifiedDate = now
                };

                con.Users.Add(userNew);
                con.SaveChanges();

                return userNew;
            }
        }

        public User getUser(string phone)
        {
            using (var con = new inventorymanagementEntities())
            {
                var user = con.Users.Where(x => x.Phone == phone).FirstOrDefault();

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

                if (user != null)
                {
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
                else
                {
                    throw new Exception(String.Format("Số điện thoại này {0} không tồn tại.", info.phone));
                }
            }
        }

        public string changePassword(UserRegisterModel user)
        {
            using (var con = new inventorymanagementEntities())
            {
                var userOld = con.Users.Where(x => x.Phone == user.phone).FirstOrDefault();

                if (userOld != null)
                {
                    userOld.Password = Security.Encrypt(user.password);
                    userOld.ModifiedDate = DateTime.Now;
                    con.SaveChanges();

                    return user.password;
                }
                else
                {
                    throw new Exception(String.Format("Số điện thoại này {0} không tồn tại.", user.phone));
                }
            }
        }

        public string passwordNew(UserPhoneModel user)
        {
            using (var con = new inventorymanagementEntities())
            {
                var userOld = con.Users.Where(x => x.Phone == user.phone).FirstOrDefault();

                if (userOld != null)
                {
                    var password = Security.CreatePassword(6);
                    userOld.Password = Security.Encrypt(password);
                    userOld.ModifiedDate = DateTime.Now;
                    con.SaveChanges();

                    return password;
                }
                else
                {
                    throw new Exception(String.Format("Số điện thoại này {0} không tồn tại.", user.phone));
                }
            }
        }
    }
}