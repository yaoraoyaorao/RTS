/*-----------------------------------------------
 // 作    者：RCY
 // 文 件 名：BuildRes
 // 创建日期：2022/3/9 18:14:37
 // 功能描述：建筑所需要的资源和资源时间
 // 修改日期：
 // 修改描述：
-----------------------------------------------*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RTS
{
    public class BuildRes
    {
        private IRes type;              //资源类型
        private int buildNum;           //建造所需数量
        private int resOutPutNum;       //资源输出数量
        private int resOutPutTime;      //资源输出时间
        private int recoveryTime;       //资源恢复时间


        public BuildRes(IRes t,int num,int ouputNum,int time)
        {
            Type = t;
            BuildNum = num;
            ResOutPutNum = ouputNum;
            ResOutPutTime = time;
        }

        public IRes Type { get => type; set => type = value; }
        public int BuildNum { get => buildNum; set => buildNum = value; }
        public int ResOutPutNum { get => resOutPutNum; set => resOutPutNum = value; }
        public int ResOutPutTime { get => resOutPutTime; set => resOutPutTime = value; }
        public int RecoveryTime { get => recoveryTime; set => recoveryTime = value; }
    }

}
