/*-----------------------------------------------
 // 作    者：RCY
 // 文 件 名：LoadExcel
 // 创建日期：2022/3/9 19:00:10
 // 功能描述：加载Excel数据
 // 修改日期：
 // 修改描述：
-----------------------------------------------*/

using Excel;
using RTS;
using System.Collections.Generic;
using System.Data;
using System.IO;

public class LoadExcel
{
    /// <summary>
    /// 根据路径返回表集合
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    private static DataTableCollection LoadData(string path)
    {
        DirectoryInfo dInfo = Directory.CreateDirectory(path);
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

                return tables;
            }
        }
        return null;
    }

    #region 读取可建筑数据
    /// <summary>
    /// 读取其他放置资源
    /// </summary>
    /// <returns></returns>
    public static List<Build> GeneratePlaceBuildData()
    {
        return GeneratePlaceBuildData(LoadData(GlobalPath.PLACEOTHERRESPATH)[0]);
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
            build.Width = int.Parse(row[11].ToString());
            build.Hieght = int.Parse(row[12].ToString());
            //建筑位置
            build.X = int.Parse(row[13].ToString());
            build.Y = int.Parse(row[14].ToString());
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
            int time = int.Parse(shuxing[3].Split(':')[1]);

            build = new BuildRes(new IRes(1, "金币", "这是一枚金币"), buidNum, resoutPutNum, time);
            buildRes.Add(build);
        }
        return buildRes;

    }
    #endregion

    #region 读取不可建筑数据
    public static List<NotBuild> GenerateNotBuidData()
    {
        return GenerateNotBuidData(LoadData(GlobalPath.PLACEOTHERRESPATH)[1]);
    }

    private static List<NotBuild> GenerateNotBuidData(DataTable table)
    {
        List<NotBuild> notBuilds = new List<NotBuild>();
        NotBuild build;
        DataRow row;

        if (table.Rows.Count < 3)
        {
            return null;
        }
        for (int i = 3; i < table.Rows.Count; i++)
        {
            row = table.Rows[i];
            build = new NotBuild(int.Parse(row[0].ToString()), row[2].ToString(), row[3].ToString());
            //建筑资源条件列表
            build.BuildResList = GenerateBuildRes(row[4].ToString());
            build.ResPath = row[5].ToString();
            build.Width = int.Parse(row[6].ToString());
            build.Hieght = int.Parse(row[7].ToString());
            build.X = int.Parse(row[8].ToString());
            build.Y = int.Parse(row[9].ToString());
            notBuilds.Add(build);
        }
        return notBuilds;
    }
    #endregion

    #region 友方角色数据
    public static List<FriendlyRole> GenerateFriendlyRoleData()
    {
        return GenerateFriendlyRoleData(LoadData(GlobalPath.ROLEOTHERRESPATH)[0]);
    }
    public static List<FriendlyRole> GenerateFriendlyRoleData(DataTable table)
    {
        List<FriendlyRole> roleList = new List<FriendlyRole>();
        FriendlyRole role;
        DataRow row;

        if (table.Rows.Count < 3)
        {
            return null;
        }
        for (int i = 3; i < table.Rows.Count; i++)
        {
            row = table.Rows[i];
            role = new FriendlyRole(int.Parse(row[0].ToString()), row[2].ToString(), row[3].ToString());
            role.Hp = int.Parse(row[4].ToString());
            role.MaxHp = int.Parse(row[5].ToString());
            role.Level = int.Parse(row[6].ToString());
            role.MaxLevel = int.Parse(row[7].ToString());
            //招募条件
            role.DemandList = GenerateRoleRes(row[8].ToString());
            role.ResPath = row[9].ToString();
            role.X = int.Parse(row[10].ToString());
            role.Y = int.Parse(row[11].ToString());
            role.MoveSpeed = int.Parse(row[12].ToString());
            role.AtkDistance = int.Parse(row[13].ToString());
            role.Atk = int.Parse(row[14].ToString());
            role.AtkSpeed = int.Parse(row[15].ToString());
            role.View = int.Parse(row[16].ToString());
            roleList.Add(role);
        }

        return roleList;
    }

    private static List<RoleRes> GenerateRoleRes(string content)
    {
        List<RoleRes> roleResList = new List<RoleRes>();

        RoleRes roleRes;

        string[] strArray = content.Split(',');

        for (int i = 0; i < strArray.Length; i++)
        {
            string temp = strArray[i].TrimStart('{').TrimEnd('}');
            string[] shuxing = temp.Split(';');

            //类型

            //资源数量
            int resNum = int.Parse(shuxing[1].Split(':')[1]);
            //资源输出时间
            int time = int.Parse(shuxing[2].Split(':')[1]);
            roleRes = new RoleRes(new IRes(1, "金币", "这是一枚金币"), resNum,time);
            roleResList.Add(roleRes);
        }
        return roleResList;
    }
    #endregion

    #region 敌方角色数据
    public static List<EnemyRole> GenerateEnemyRoleData()
    {
        return GenerateEnemyRoleData(LoadData(GlobalPath.ROLEOTHERRESPATH)[1]);
    }
    public static List<EnemyRole> GenerateEnemyRoleData(DataTable table)
    {
        List<EnemyRole> roleList = new List<EnemyRole>();
        EnemyRole role;
        DataRow row;

        if (table.Rows.Count < 3)
        {
            return null;
        }
        for (int i = 3; i < table.Rows.Count; i++)
        {
            row = table.Rows[i];
            role = new EnemyRole(int.Parse(row[0].ToString()), row[2].ToString(), row[3].ToString());
            role.Hp = int.Parse(row[4].ToString());
            role.MaxHp = int.Parse(row[5].ToString());
            role.Level = int.Parse(row[6].ToString());
            role.MaxLevel = int.Parse(row[7].ToString());
            role.ResPath = row[8].ToString();
            role.X = int.Parse(row[9].ToString());
            role.Y = int.Parse(row[10].ToString());
            role.MoveSpeed = int.Parse(row[11].ToString());
            role.AtkDistance = int.Parse(row[12].ToString());
            role.Atk = int.Parse(row[13].ToString());
            role.AtkSpeed = int.Parse(row[14].ToString());
            role.View = int.Parse(row[15].ToString());
            roleList.Add(role);
        }

        return roleList;
    }
    #endregion

    #region 资源数据
    public static List<IRes> GenerateResData()
    {
        return GenerateResData(LoadData(GlobalPath.RESOTHERRESPATH)[0]);
    }

    public static List<IRes> GenerateResData(DataTable table)
    {
        List<IRes> resList = new List<IRes>();
        IRes role;
        DataRow row;
        if (table.Rows.Count < 3)
        {
            return null;
        }

        for (int i = 3; i < table.Rows.Count; i++)
        {
            row = table.Rows[i];
            role = new IRes(int.Parse(row[0].ToString()), row[1].ToString(), row[2].ToString());
            role.ResPath = row[3].ToString();

            resList.Add(role);
        }

        return resList;
    }
    #endregion

}
