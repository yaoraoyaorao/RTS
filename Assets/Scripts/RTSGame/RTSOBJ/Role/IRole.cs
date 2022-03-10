/*-----------------------------------------------
 // 作    者：RCY
 // 文 件 名：IRole
 // 创建日期：2022/3/9 17:04:10
 // 功能描述：角色基类 继承rts对象
 // 修改日期：
 // 修改描述：
-----------------------------------------------*/

namespace RTS
{
    public class IRole : RTSOBJ
    {
        public IRole(int id, string name,string info ,E_RTSType type) : base(id, name, info, type) { }

        private int hp;                 //生命值
        private int maxHp;              //最高生命值
        private int armor;              //护甲
        private int moveSpeed;          //移动速度
        private int atkDistance;     //移动距离
        private int atk;                //攻击力
        private int atkSpeed;           //攻击速度
        private int view;               //视野
        private int level;              //等级
        private int maxLevel;           //最高等级
        private string resPath;         //资源路径
        private int x;                  //x轴位置
        private int y;                  //y轴位置


        public int Hp { get => hp; set => hp = value; }
        public int Armor { get => armor; set => armor = value; }
        public int MoveSpeed { get => moveSpeed; set => moveSpeed = value; }
        public int AtkDistance { get => atkDistance; set => atkDistance = value; }
        public int Atk { get => atk; set => atk = value; }
        public int AtkSpeed { get => atkSpeed; set => atkSpeed = value; }
        public int View { get => view; set => view = value; }
        public string ResPath { get => resPath; set => resPath = value; }
        public int MaxHp { get => maxHp; set => maxHp = value; }
        public int Level { get => level; set => level = value; }
        public int MaxLevel { get => maxLevel; set => maxLevel = value; }
        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }
    }
}

