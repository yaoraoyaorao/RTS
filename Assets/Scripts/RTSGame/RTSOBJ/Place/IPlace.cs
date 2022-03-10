/*-----------------------------------------------
 // 作    者：RCY
 // 文 件 名：IPlace
 // 创建日期：2022/3/9 17:06:05
 // 功能描述：放置类型   继承RTSOBJ
 // 修改日期：
 // 修改描述：
-----------------------------------------------*/

namespace RTS
{
    public class IPlace : RTSOBJ
    {
        public IPlace(int id, string name,string info, E_PlaceType placeType, E_RTSType type = E_RTSType.Place):base(id,name,info, type)
        {
            PlaceType = placeType;
        }

        //宽
        private int width;
        //高
        private int hieght;
        //x轴位置
        private int x;
        //y轴位置
        private int y;
        //类型
        private E_PlaceType placeType;
        //模型资源路径
        private string resPath;                     
        //模型影子路径
        private string resGhostPath;                

        public E_PlaceType PlaceType { get => placeType; set => placeType = value; }
        public int Width { get => width; set => width = value; }
        public int Hieght { get => hieght; set => hieght = value; }
        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }
        public string ResPath { get => resPath; set => resPath = value; }
        public string ResGhostPath { get => resGhostPath; set => resGhostPath = value; }
    }

}
