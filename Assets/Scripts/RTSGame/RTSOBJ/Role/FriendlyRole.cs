/*-----------------------------------------------
 // 作    者：RCY
 // 文 件 名：FriendlyRole
 // 创建日期：2022/3/10 15:00:26
 // 功能描述：友方角色
 // 修改日期：
 // 修改描述：
-----------------------------------------------*/

using System.Collections.Generic;

namespace RTS
{
    public class FriendlyRole:IRole
    {
        public FriendlyRole(int id, string name, string info,E_RTSType type = E_RTSType.Role) : base(id, name, info,type) { }
        private List<RoleRes> demandList;

        //招募条件列表
        public List<RoleRes> DemandList { get => demandList; set => demandList = value; }
    }
}

