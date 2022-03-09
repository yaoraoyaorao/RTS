/*-----------------------------------------------
 // 作    者：RCY
 // 文 件 名：GlobalPath
 // 创建日期：2022/3/9 16:22:06
 // 功能描述：全局路径
 // 修改日期：
 // 修改描述：
-----------------------------------------------*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RTS
{
    public static class GlobalPath
    {
        /// <summary>
        /// 默认对象资源加载,默认资源保存在Resources文件夹下
        /// </summary>
        public static string DEFAULTRESPATH = "/DefaultData/";
        /// <summary>
        /// 其他对象资源加载，其他资源保存在streamingAssets文件夹下
        /// </summary>
        public static string OTHERRESPATH = Application.streamingAssetsPath + "/OtherData/";

        #region 默认资源存放路径
        public static string PLACEDEFAUTPATH = DEFAULTRESPATH + "Place/";   //放置路径
        public static string ROLEDEFAULTPATH = DEFAULTRESPATH + "Role/";    //角色路径
        public static string RESDEFAULTPATH  = DEFAULTRESPATH + "Res/";     //资源路径
        #endregion

        #region 其他资源存放路径
        public static string PLACEOTHERRESPATH = OTHERRESPATH + "Place/";   //放置路径
        public static string ROLEOTHERRESPATH  = OTHERRESPATH + "Role/";    //角色路径
        public static string RESOTHERRESPATH   = OTHERRESPATH + "Res/";     //资源路径
        #endregion
    }
}

