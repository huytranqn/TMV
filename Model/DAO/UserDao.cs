using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using PagedList;
using Models.Common;
using System.Data.SqlClient;


namespace Model.DAO
{
    public class UserDao
    {
        OnlineTMV  db = null;

        private static UserDao instance;

        public static UserDao Instance
        {
            get { if (instance == null) instance = new UserDao(); return UserDao.instance; }
            set { UserDao.instance = value; }
        }

        public UserDao()
        {
            db = new OnlineTMV();
        }

        public HT_NHANVIEN GetByName(string userName)
        {
            return db.HT_NHANVIEN.SingleOrDefault(x => x.TEN_DANGNHAP == userName);
        }

        public int Login(string userID, string passWord, bool isLoginAdmin = false)
        {
            var result = db.HT_NHANVIEN.SingleOrDefault(x => x.TEN_DANGNHAP == userID);
            if (result == null)
            {
                return 0;//tài khoản ko tồn tại
            }
            else
            {
                if (isLoginAdmin == true)
                {

                    if (result.HOAT_DONG == false)
                    {
                        return -1; //tài khoản bị khóa
                    }
                    else
                    {
                        if (result.MAT_KHAU == passWord)
                            return 1; //đăng nhập thành công
                        else
                            return -2; //mk ko đúng
                    }

                }
                else
                {
                    if (result.HOAT_DONG == false)
                    {
                        return -1;
                    }
                    else
                    {
                        if (result.MAT_KHAU == passWord)
                            return 1;
                        else
                            return -2;
                    }
                }
            }
        }
    }
}
