using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;

namespace Model.DAO
{
    public class NhanvienDao
    {
        /**
   * Constants
   */
        private OnlineTMV db = null;

        /**
         * @description -- init
         */

        public NhanvienDao()
        {
            db = new OnlineTMV();
        }

        private static NhanvienDao instance;

        public static NhanvienDao Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new NhanvienDao();
                }
                return instance;
            }
        }

        public List<HT_NHANVIEN> GetListActive()
        {
            return db.HT_NHANVIEN.Where(x => x.HOAT_DONG == true).OrderByDescending(x => x.MODIFIED).ToList();
        }

        public HT_NHANVIEN getByID(String _key)
        {
            return db.HT_NHANVIEN.SingleOrDefault(obj => obj.TEN_DANGNHAP == _key);
        }
    }
}
