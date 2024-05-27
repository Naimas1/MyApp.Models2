using System.Collections.Generic;
using MyApp.Models;

namespace MyApp.Services
{
    public interface IInfoService
    {
        List<Info> GetAll();
        Info GetById(int id);
        void Add(Info info);
        void Update(Info info);
        void Delete(int id);
        object GetProfessions();
    }
}
