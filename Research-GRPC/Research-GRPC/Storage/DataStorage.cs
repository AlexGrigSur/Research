using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Research_GRPC.Storage
{
    public static class DataStorage
    {
        // non-unique rows
        private static List<UserModel> _storage = new List<UserModel>()
        {
            new UserModel()
            {
                FirstName = "Alex",
                LastName = "Grigoryan",
                Email = "alex.grig.sur@gmail.com",
                Password = "11112222"
            },
            new UserModel()
            {
                FirstName = "Stas",
                LastName = "Boretsky",
                Email = "tiChegoVolchara@porvu.ru",
                Password = "7777777777777"
            },
            new UserModel()
            {
                FirstName = "Zubenko",
                LastName = "Mikhail-Petrovich",
                Email = "mafioznik@mail.ru",
                Password = "666666"
            }
        };

        public static UserModel? GetData(int userId)
        {
            try
            {
                return _storage[userId];
            }
            catch (IndexOutOfRangeException)
            {
                return null;
            }
        }
        public static int SetData(UserModel model)
        {
            _storage.Add(model);
            Console.WriteLine(_storage.Count - 1);
            return (_storage.Count - 1);
        }
        public static UserModel[] GetAll()
        {
            var result = new UserModel[_storage.Count];
            _storage.CopyTo(result);
            return result;
        }
    }
}