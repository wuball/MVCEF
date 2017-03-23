
using System.Data.Entity;
using Light.Framework.Data;
using DbConfiguration = Light.Framework.Data.DbConfiguration;

namespace Light.Framework.Service.Helpers
{
    /// <summary>
    /// 初始化数据
    /// </summary>
    public static class InitData
    {
        /// <summary>
        /// 初始化
        /// </summary>
        public static void Init()
        {
            //启用EF自动迁移
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<LightDbContext, DbConfiguration>());

            //关闭自动迁移，从不创建数据库(不建议使用此方法)
            //Database.SetInitializer<JuCheapContext>(null);
        }
    }
}
