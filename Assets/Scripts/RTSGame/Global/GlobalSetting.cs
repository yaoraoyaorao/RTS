/*-----------------------------------------------
 // 作    者：RCY
 // 文 件 名：GlobalSetting
 // 创建日期：2022/3/9 16:16:11
 // 功能描述：
 // 修改日期：
 // 修改描述：
-----------------------------------------------*/

using UnityEngine;

namespace RTS
{
    public static class GlobalSetting
    {
        /// <summary>
        /// 默认对象资源加载
        /// </summary>
        public static string DEFAULTRESPATH = Application.streamingAssetsPath + "/Default/";
        /// <summary>
        /// 其他对象资源加载
        /// </summary>
        public static string OTHERRESPATH = Application.streamingAssetsPath + "/Other";
    }
}

