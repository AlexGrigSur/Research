using System;
using System.Collections.Generic;
using System.Linq;

namespace Research_GRPC.Storage
{
    public class DataStorage
    {
        private static DataStorage _instance;
        private Dictionary<int,UserModel> _storage = new()
        {
            [1]=new UserModel
            {
                FirstName = "Alex",
                LastName = "Grigoryan",
                Email = "alex.grig.sur@gmail.com",
                Password = "11112222"
            },
            [2]=new UserModel
            {
                FirstName = "Stas",
                LastName = "Boretsky",
                Email = "tiChegoVolchara@porvu.ru",
                Password = "7777777777777"
            },
            [3]=new UserModel
            {
                FirstName = "Zubenko",
                LastName = "Mikhail-Petrovich",
                Email = "mafioznik@mail.ru",
                Password = "666666"
            }
        };

        public static DataStorage GetInstance()
        {
            if (_instance == null)
            {
                _instance = new DataStorage();
            }
            return _instance;
        }

        public UserModel? GetUser(int userNumber)
        {
            lock (_storage)
            {
                UserModel result;
                _storage.TryGetValue(userNumber, out result);
                return result;
            }
        }
        public void AddUser(UserModelWithKey userModel)
        {
            lock (_storage)
            {
                _storage[userModel.Key] = userModel.Model;
            }
        }
        public Dictionary<int,UserModel> GetAllUsers()
        {
            lock (_storage)
            {
                return _storage.ToDictionary(entry => entry.Key, entry => entry.Value);
            }
        }
    }
}