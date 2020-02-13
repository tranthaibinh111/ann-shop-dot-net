using ann_shop_server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ann_shop_server.Services
{
    public class FlutterUserService: UserService
    {
        public static new FlutterUserService Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new FlutterUserService();
                }

                return (FlutterUserService)_instance;
            }
        }

        public FlutterUserModel confirmOTP(ConfirmOTPModel data)
        {
            if (!checkUser(data.phone.Trim()))
            {
                register(new UserRegisterModel() { phone = data.phone.Trim(), password = data.otp });
            }
            else
            {
                changePassword(data.phone.Trim(), data.otp);
            }

            return getUser(new UserRegisterModel() { phone = data.phone.Trim(), password = data.otp });
        }

        public new FlutterUserModel getUser(UserRegisterModel login)
        {
            var user = base.getUser(login);

            if (user != null)
            {
                return new FlutterUserModel() {
                    id = user.ID,
                    phone = user.Phone,
                    fullName = user.FullName,
                    birthDay = user.BirthDay,
                    gender = user.Gender,
                    address = user.Address,
                    city = user.City
                };
            }

            return null;
        }

        public new FlutterUserModel updateInfo(UserInfoModel info)
        {
            var user = base.updateInfo(info);

            if (user == null)
                throw new Exception(String.Format("Số điện thoại này {0} không tồn tại.", info.phone));

            return new FlutterUserModel()
            {
                id = user.ID,
                phone = user.Phone,
                fullName = user.FullName,
                birthDay = user.BirthDay,
                gender = user.Gender,
                address = user.Address,
                city = user.City
            };
        }

        public string createdPassword(FlutterCreatePasswordModel data)
        {
            var password = createPassword(data.phone, data.otp, data.passwordNew);

            if (password == null)
                throw new Exception("Số điện thoại hoặc OTP không đúng.");

            return password;
        }

        public new string changePassword(string phone, string passwordNew)
        {
            var password = base.changePassword(phone, passwordNew);

            if (password == null)
                throw new Exception(String.Format("Số điện thoại này {0} không tồn tại.", phone));

            return password;
        }

        public string passwordNewByBirthday(FlutterPasswordNewBirthdayModel data)
        {
            if (!checkUser(data.phone))
                throw new Exception(String.Format(String.Format("Số điện thoại này {0} không tồn tại.", data.phone)));

            var password = passwordNewByBirthday(data.phone, data.birthday, data.otp);

            if (password == null)
                throw new Exception(String.Format("Ngày sinh {0:dd-MM-yyyy} không chính xác", data.birthday));

            return password;
        }
    }
}