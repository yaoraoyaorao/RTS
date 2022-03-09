/*-----------------------------------------------
 // 作    者：RCY
 // 文 件 名：RTSOBJManager
 // 创建日期：2022/3/9 15:47:10
 // 功能描述：物体管理器
 // 修改日期：
 // 修改描述：
-----------------------------------------------*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RTS
{
    public class RTSOBJManager:Singleton<RTSOBJManager>
    {
        //保存所有对象信息
        private Dictionary<int, RTSOBJ> allData;
        
        #region 属性
        public Dictionary<int, RTSOBJ> AllData => allData;

        #endregion

        public RTSOBJManager()
        {
            allData = new Dictionary<int, RTSOBJ>();
        }

        /// <summary>
        /// 加载默认资源
        /// </summary>
        public void LoadDefaultData()
        {

        }

        /// <summary>
        /// 加载其他资源
        /// </summary>
        public void LoadOtherData()
        {
            //加载建筑资源
            List<Build> builds = LoadExcel.GeneratePlaceBuildData();
            if(builds != null)
            {
                for (int i = 0; i < builds.Count; i++)
                {
                    //判断id有相同的情况
                    if (allData.ContainsKey(builds[i].ID))
                    {
                        //抛出一个错误
                        Debug.Log("ID冲突");
                    }
                    else
                    {
                        allData.Add(builds[i].ID, builds[i]);
                    }
                }
            }
            
        }

        /// <summary>
        /// 通过id获取资源
        /// </summary>
        /// <param name="id">对象ID</param>
        /// <returns></returns>
        public RTSOBJ GetObj(int id)
        {
            if (allData == null) return null;
            if (allData.ContainsKey(id))
            {
                return allData[id];
            }
            return null;
        }

        /// <summary>
        /// 通过名称获取对象
        /// </summary>
        /// <param name="name">对象名称</param>
        /// <returns></returns>
        public List<RTSOBJ> GetObj(string name)
        {
            List<RTSOBJ> objList = new List<RTSOBJ>();

            foreach (RTSOBJ item in allData.Values)
            {
                if (item.Name == name)
                {
                    objList.Add(item);
                }
            }
            return objList;

        }
    }
}

