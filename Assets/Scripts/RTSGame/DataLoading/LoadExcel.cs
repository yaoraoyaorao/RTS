/*-----------------------------------------------
 // 作    者：RCY
 // 文 件 名：LoadExcel
 // 创建日期：2022/3/9 19:00:10
 // 功能描述：加载Excel数据
 // 修改日期：
 // 修改描述：
-----------------------------------------------*/

using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using RTS;
using Excel;
using System.Data;

public class LoadExcel
{

    /// <summary>
    /// 读取其他放置资源
    /// </summary>
    /// <returns></returns>
    public static List<Build> GeneratePlaceBuildData()
    {
        DirectoryInfo dInfo = Directory.CreateDirectory(GlobalPath.PLACEOTHERRESPATH);
        FileInfo[] files = dInfo.GetFiles();

        DataTableCollection tables;
        for (int i = 0; i < files.Length; i++)
        {
            if (files[i].Extension != ".xlsx" &&
               files[i].Extension != ".xls")
                continue;
            using (FileStream fs = files[i].Open(FileMode.Open, FileAccess.Read))
            {
                IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(fs);
                tables = excelReader.AsDataSet().Tables;

                //可建造表
                return GeneratePlaceBuildData(tables[0]);
            }
        }
        return null;
    }

    /// <summary>
    /// 生成放置资源
    /// </summary>
    /// <param name="table"></param>
    /// <returns></returns>
    private static List<Build> GeneratePlaceBuildData(DataTable table)
    {
        List<Build> placeList = new List<Build>();
        Build build;
        DataRow row;

        if (table.Rows.Count < 3)
        {
            return null;
        }

        
        //------需要加上一个错误判断
        //从第三行开始读取数据
        for (int i = 3; i < table.Rows.Count; i++)
        {
            row = table.Rows[i];

            build = new Build(int.Parse(row[0].ToString()), row[2].ToString(), row[3].ToString());
            
            //血量
            build.Hp = int.Parse(row[4].ToString());
            //最大血量
            build.MaxHp = int.Parse(row[5].ToString());
            //等级
            build.Level = int.Parse(row[6].ToString());
            //最大等级
            build.MaxLevel = int.Parse(row[7].ToString());
            //建筑条件
            build.BuildConditionList = GenerateBuildRes(row[8].ToString());
            //资源路径
            build.ResPath = row[9].ToString();
            //资源影子路径
            build.ResGhostPath = row[10].ToString();
            //建筑尺寸
            build.Size = new Vector2Int(int.Parse(row[11].ToString()), int.Parse(row[12].ToString()));
            //建筑位置
            build.Position = new Vector2Int(int.Parse(row[13].ToString()), int.Parse(row[14].ToString()));
            placeList.Add(build);
        }

        return placeList;
    }

    /// <summary>
    /// 生成建筑资源
    /// </summary>
    /// <param name="content"></param>
    /// <returns></returns>
    private static List<BuildRes> GenerateBuildRes(string content)
    {
        List<BuildRes> buildRes = new List<BuildRes>();

        BuildRes build;

        string[] strArray = content.Split(',');

        for (int i = 0; i < strArray.Length; i++)
        {
            string temp = strArray[i].TrimStart('{').TrimEnd('}');
            string[] shuxing = temp.Split(';');

            //类型

            //建造所需数量
            int buidNum = int.Parse(shuxing[1].Split(':')[1]);
            //资源输出数量
            int resoutPutNum = int.Parse(shuxing[2].Split(':')[1]);
            //资源输出时间
            float time = float.Parse(shuxing[3].Split(':')[1]);

            build = new BuildRes(new IRes(1, "金币", "这是一枚金币"), buidNum, resoutPutNum, time);
            buildRes.Add(build);
        }
        return buildRes;

    }

}
