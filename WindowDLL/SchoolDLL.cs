using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowIDLL;
using WindowModel.EntityModel;
using WindowShare;

namespace WindowDLL
{
    public class SchoolDLL: ISchoolDLL
    {
        public int Add(object param)
        {
            var strSql = new StringBuilder();
            strSql.Append(" Insert into EIC_School([ID],[SchoolCode],[SchoolName],[LogoImg] ,[SchoolEmail] ,[SchoolFax] ,[SchoolTel] ,[Linkman] ,[AddressCode]   ,[Address]  ,[CreatedBy] ,[CreateDate]  ,[ModifiedBy] ,[ModifiedDate])");
            strSql.Append(" Values(@ID,@SchoolCode,@SchoolName,@LogoImg,@SchoolEmail,@SchoolFax,@SchoolTel,@Linkman,@AddressCode,@Address,@CreatedBy,@CreateDate ,@ModifiedBy ,@ModifiedDate)");
            return DapperHelper<EIC_School>.Execute(strSql.ToString(), param);
        }

        public int DeleteById(string strsql, object param)
        {
            throw new NotImplementedException();
        }

        public EIC_School GetOneDataById(string id)
        {
            var strSql = new StringBuilder();
            strSql.Append(" Select [ID],[SchoolCode],[SchoolName],[LogoImg] ,[SchoolEmail] ,[SchoolFax] ,[SchoolTel] ,[Linkman] ,[AddressCode]   ,[Address]  ,[CreatedBy] ,[CreateDate]  ,[ModifiedBy] ,[ModifiedDate] from EIC_School ");
            strSql.Append(" Where ID =@ID");

            var parameters = new DynamicParameters();
            parameters.Add("@ID", id);

            #region  //参数方式二

            //var parameters = new EIC_School
            //{
            //    ID =id
            //};

            #endregion

            return DapperHelper<EIC_School>.QueryFirstOrDefault(strSql.ToString(), parameters);
        }

        public int UpdateTime(object param)
        {
            var strSql = new StringBuilder();
            strSql.Append(" Update EIC_School SET CreateDate = @CreateDate");

            var parames = new DynamicParameters();
            parames.Add("@CreateDate", param);
            return DapperHelper<EIC_School>.Execute(strSql.ToString(), parames);
        }
    }
}
