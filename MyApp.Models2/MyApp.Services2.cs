using MyApp.Models;
using MyApp.Models2;

namespace MyApp.Services2
{
    public class InfoService : IInfoService
    {
        private readonly string filePath;
        private readonly List<Info> infos;
        private readonly List<Profession> professions;

        public InfoService(string filePath)
        {
            this.filePath = filePath;
            this.infos = LoadInfos();
            this.professions = LoadProfessions();
        }

        private List<Info> LoadInfos()
        {
            if (!File.Exists(filePath))
            {
                return new List<Info>();
            }

            var jsonData = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<List<Info>>(jsonData) ?? new List<Info>();
        }

        private List<Profession> LoadProfessions()
        {
            return new List<Profession>
            {
                new Profession { Id = 1, Name = "Software Engineer" },
                new Profession { Id = 2, Name = "Data Scientist" },
                new Profession { Id = 3, Name = "Product Manager" }
            };
        }

        private void SaveInfos()
        {
            var jsonData = JsonConvert.SerializeObject(infos);
            File.WriteAllText(filePath, jsonData);
        }

        public List<Info> GetAll() => infos;

        public Info GetById(int id) => infos.FirstOrDefault(i => i.Id == id);

        public void Add(Info info)
        {
            info.Id = infos.Any() ? infos.Max(i => i.Id) + 1 : 1;
            infos.Add(info);
            SaveInfos();
        }

        public void Update(Info info)
        {
            var existingInfo = infos.FirstOrDefault(i => i.Id == info.Id);
            if (existingInfo != null)
            {
                existingInfo.Name = info.Name;
                existingInfo.IsActive = info.IsActive;
                existingInfo.Age = info.Age;
                existingInfo.Salary = info.Salary;
                existingInfo.BirthDate = info.BirthDate;
                existingInfo.Profession = info.Profession;
                SaveInfos();
            }
        }

        public void Delete(int id)
        {
            var info = infos.FirstOrDefault(i => i.Id == id);
            if (info != null)
            {
                infos.Remove(info);
                SaveInfos();
            }
        }

        public List<Profession> GetProfessions() => professions;
    }
}
