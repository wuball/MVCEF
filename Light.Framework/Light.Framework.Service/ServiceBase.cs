using System;
using Light.Framework.Core.Logging;
using Light.Framework.Data;

namespace Light.Framework.Service
{
    public interface IServiceBase
    {

    }

    public abstract class ServiceBase
    {
        protected LightDbContext NewDB()
        {
            return new LightDbContext();
        }

        protected void Try(Action action)
        {
            try
            {
                action();
            }
            catch (Exception ex)
            {
                Logger.Error("ServiceBase.Try", ex);
            }
        }

    }


}
