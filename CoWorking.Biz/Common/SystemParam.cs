using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoWorking.Biz.Common
{
    public class SystemParam
    {
        // Default
        public const int SUCCESS = 1;
        public const int ERROR = 0;
        // Register
        public const int ERROR_REGISTER_FIELDS_INVALID = 1;
        public const string MESSAGE_REGISTER_FIELDS_INVALID = "Vui lòng nhập đầy đủ thông tin bắt buộc";
        public const int ERROR_REGISTER_PHONE_INVALID = 2;
        public const string MESSAGE_REGISTER_PHONE_INVALID = "Số điện thoại không đúng định dạng";
        public const int ERROR_REGISTER_PHONE_EXIST = 3;
        public const string MESSAGE_REGISTER_PHONE_EXIST = "Số điện thoại đã tồn tại";
        public const int ERROR_REGISTER_EMAIL_INVALID = 4;
        public const string MESSAGE_REGISTER_EMAIL_INVALID = "Email không đúng định dạng";
        public const int ERROR_REGISTER_EMAIL_EXIST = 5;
        public const string MESSAGE_REGISTER_EMAIL_EXIST = "Email đã tồn tại";
        public const int ERROR_PHONE_NOT_EXIST = 6;
        public const string MESSAGE_PHONE_NOT_EXIST = "Số điện thoại không tồn tại";
        public const int ERROR_REGISTER_ACCOUNT_EXIST = 7;
        public const string MESSAGE_REGISTER_ACCOUNT_EXIST = "Taì khoản đã tồn tại";
    }
}
