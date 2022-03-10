/*-----------------------------------------------
 // 作    者：RCY
 // 文 件 名：EnemyRole
 // 创建日期：2022/3/10 15:16:00
 // 功能描述：敌方角色
 // 修改日期：
 // 修改描述：
-----------------------------------------------*/

namespace RTS
{
    public class EnemyRole:IRole
    {
        public EnemyRole(int id, string name, string info, E_RTSType type = E_RTSType.Role) : base(id, name, info, type) { }
    }
}

