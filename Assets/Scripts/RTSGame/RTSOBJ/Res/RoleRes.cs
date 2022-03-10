/*-----------------------------------------------
 // 作    者：RCY
 // 文 件 名：RoleRes
 // 创建日期：2022/3/10 15:08:52
 // 功能描述：角色所需要的资源
 // 修改日期：
 // 修改描述：
-----------------------------------------------*/

namespace RTS
{
    public class RoleRes
    {
        //资源类型
        private IRes res;
        //资源数量
        private int num;
        //时薪
        private int time;

        public IRes Res { get => res; set => res = value; }
        public int Num { get => num; set => num = value; }
        public int Time { get => time; set => time = value; }

        public RoleRes(IRes r,int n,int t)
        {
            res = r;
            num = n;
            time = t;
        }
    }

}

