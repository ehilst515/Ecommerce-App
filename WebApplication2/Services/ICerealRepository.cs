using System;

namespace ECommerceApp.Controllers
{
    public interface ICerealRepository

    {
    }

    public class CerealRepository : ICerealRepository
    {
        internal static object GetAll()
        {
            throw new NotImplementedException();
        }
    }

}
