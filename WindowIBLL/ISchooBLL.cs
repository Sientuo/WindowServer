using WindowIBLL;
using WindowModel.EntityModel;

namespace WindowBLL
{
    public interface ISchooBLL: IBaseBLL
    {
        //增
        int Add(object param);
        //删
        int DeleteById(string strsql, object param);
        //查询一笔数据
        EIC_School GetOneDataById(string id);
        //更新时间
        int UpdateTime(object param);

        int Test();

        string MySelf();
    }
}
