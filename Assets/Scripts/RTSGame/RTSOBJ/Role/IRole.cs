/*-----------------------------------------------
 // 作    者：RCY
 // 文 件 名：IRole
 // 创建日期：2022/3/9 17:04:10
 // 功能描述：角色基类 继承rts对象
 // 修改日期：
 // 修改描述：
-----------------------------------------------*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RTS
{
    public class IRole : RTSOBJ
    {
        public IRole(int id, string name,string info ,E_RTSType type) : base(id, name, info, type) { }
    }
}

