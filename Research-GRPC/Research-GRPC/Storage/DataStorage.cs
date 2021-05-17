﻿using System;
using System.Collections.Generic;
using System.Linq;

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

        public static UserModel? GetUser(int userNumber)
        {
            if (userNumber < 0 || userNumber >= _storage.Count)
            {
                return null;
            }
            return _storage[userNumber];
        }
        public static int AddUser(UserModel model)
        {
            _storage.Add(model);
            Console.WriteLine(_storage.Count - 1);
            return (_storage.Count - 1);
        }
        public static List<UserModel> GetAllUsers()
        {
            var result = _storage.Select(x=>x).ToList();
            return result;
        }
    }
}