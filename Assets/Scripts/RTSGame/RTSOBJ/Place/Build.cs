/*-----------------------------------------------
 // 作    者：RCY
 // 文 件 名：Build
 // 创建日期：2022/3/9 17:34:00
 // 功能描述：可建筑类型
 // 修改日期：
 // 修改描述：
-----------------------------------------------*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace RTS
{
    public class Build:IPlace
    {
        public Build(int id, string name, string info, E_PlaceType type = E_PlaceType.Buildable) : base(id, name, info, type) { }


        private int hp;                             //血量
        private int maxHp;                          //最大血量
        private List<BuildRes> buildConditionList;  //建筑条件资源列表
        private int level;                          //建筑等级
        private int maxLevel;                       //建筑最高等级
        private string resPath;                     //艺术资源路径
        private string resGhostPath;                //艺术影子资源路径

        public UnityAction ConstructionTimeEvent;   //建造时的事件
        public UnityAction DestoryEvent;            //拆除时的事件
        public UnityAction BuildEvent;              //建筑事件

        #region 属性
        public int Hp { get => hp; set => hp = value; }
        public int MaxHp { get => maxHp; set => maxHp = value; }
        public List<BuildRes> BuildConditionList { get => buildConditionList; set => buildConditionList = value; }
        public int Level { get => level; set => level = value; }
        public int MaxLevel { get => maxLevel; set => maxLevel = value; }
        public string ResPath { get => resPath; set => resPath = value; }
        public string ResGhostPath { get => resGhostPath; set => resGhostPath = value; }
        #endregion

        #region 方法
        public void CallEvent()
        {
            ConstructionTimeEvent?.Invoke();
            DestoryEvent?.Invoke();
            BuildEvent?.Invoke();
        }
        #endregion
    }
}

