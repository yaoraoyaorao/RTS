/*-----------------------------------------------
 // 作    者：RCY
 // 文 件 名：RTSOBJ
 // 创建日期：2022/3/9 15:12:31
 // 功能描述：游戏中所有游戏对象的基类
 // 修改日期：
 // 修改描述：
-----------------------------------------------*/

namespace RTS
{
    public class RTSOBJ
    {
        private string name;
        private int id;
        private E_RTSType type;
        private string info;
        
        public RTSOBJ(int id,string name,string info, E_RTSType type)
        {
            ID = id;
            Name = name;
            Type = type;
            Info = info;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public E_RTSType Type
        {
            get { return type; }
            set { type = value; }
        }

        public string Info
        {
            get { return info; }
            set { info = value; }
        }
    }
}

