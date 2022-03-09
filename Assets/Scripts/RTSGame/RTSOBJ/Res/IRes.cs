/*-----------------------------------------------
 // 作    者：RCY
 // 文 件 名：IRes
 // 创建日期：2022/3/9 17:05:24
 // 功能描述：资源基类 继承rtsobj
 // 修改日期：
 // 修改描述：
-----------------------------------------------*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RTS
{
    public class IRes : RTSOBJ
    {
        public IRes(int id, string name,string info, E_RTSType type = E_RTSType.Res) : base(id, name, info,type) { }
    }
}

