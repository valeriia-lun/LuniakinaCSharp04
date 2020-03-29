using System;
using System.Collections.Generic;
using System.IO;
using Luniakina04.Models;
using Luniakina04.Tools.Managers;

namespace Luniakina04.Tools.DataStorage
{
    internal class SerializedDataStorage : IDataStorage
    {
        private readonly List<Person> _users;

        internal SerializedDataStorage()
        {
            try
            {
                _users = SerializationManager.Deserialize<List<Person>>(FileFolderHelper.StorageFilePath);
            }
            catch (FileNotFoundException)
            {
                _users = new List<Person>();
                string[] names =
                {
                    "Sophie",
                    "Adam",
                    "Karlos",
                    "Anastasia",
                    "Brandan",
                    "Jake",
                    "Helen",
                    "Lisa",
                    "Viktoriia",
                    "Blair",
                    "Chack",
                    "Eva",
                    "Tom",
                    "Serena",
                    "Mickael",
                    "Simon",
                    "John",
                    "Ken",
                    "Jord",
                    "Justin",
                    "Charlie",
                    "Lili",
                    "Monika",
                    "Marie",
                    "Claire",
                    "Mike",
                    "Bryana",
                    "Alex",
                    "Jord",
                    "Coul",
                    "Dylan",
                    "Peter",
                    "Robert",
                    "Lana",
                    "Emma",
                    "Robert",
                    "Charls",
                    "Serg",
                    "Louisa",
                    "Karla",
                    "Stephani",
                    "Milana",
                    "Stassi",
                    "Valerie",
                    "David",
                    "Anna",
                    "Steve",
                    "Alise",
                    "Kylie",
                    "Travis"
                };
                string[] surnames =
                {
                    "Wolfhard",
                    "Woldorf",
                    "Green",
                    "Johnson",
                    "Williams",
                    "Johns",
                    "Brown",
                    "Davis",
                    "Miller",
                    "Anderson",
                    "Taylor",
                    "Tomas",
                    "Moore",
                    "Martin",
                    "Jackson",
                    "White",
                    "Lotos",
                    "Lii",
                    "Harris",
                    "Lavis",
                    "Clarck",
                    "Robinson",
                    "Walker",
                    "Hall",
                    "Allen",
                    "King",
                    "Baker",
                    "Adams",
                    "Nalson",
                    "Hill",
                    "Mittchel",
                    "Roberts",
                    "Houston",
                    "Evans",
                    "Terner",
                    "Torres",
                    "Paker",
                    "Collins",
                    "Edvards",
                    "Stuart",
                    "Morris",
                    "Morphi",
                    "Rivera",
                    "Cook",
                    "Morgan",
                    "Peterson",
                    "Copper",
                    "Rit",
                    "Bell",
                    "Hovard"
                };
                string[] mails =
                {

                    "wolfhard",
                    "woldorf",
                    "green",
                    "johnson",
                    "williams",
                    "johns",
                    "brown",
                    "davis",
                    "miller",
                    "anderson",
                    "taylor",
                    "tomas",
                    "moore",
                    "martin",
                    "jackson",
                    "white",
                    "lotos",
                    "lii",
                    "harris",
                    "lavis",
                    "clarck",
                    "robinson",
                    "walker",
                    "hall",
                    "allen",
                    "king",
                    "baker",
                    "adams",
                    "nalson",
                    "hill",
                    "mittchel",
                    "roberts",
                    "houston",
                    "evans",
                    "terner",
                    "torres",
                    "paker",
                    "collins",
                    "edvards",
                    "stuart",
                    "morris",
                    "morphi",
                    "rivera",
                    "cook",
                    "morgan",
                    "peterson",
                    "copper",
                    "rit",
                    "bell",
                    "hovard"
                };
                Random random = new Random();
                for (int i = 0; i < 50; ++i)
                {
                    var birthday = new DateTime(random.Next(1970, 2019), random.Next(1, 12), random.Next(1, 28));
                    Person person = new Person(names[i], surnames[i], mails[i] + "@gmail.com", birthday);
                    _users.Add(person);
                }

                SaveChanges();
            }
        }



        public void Add(Person person)
        {
            _users.Add(person);
            SaveChanges();
        }

        public void Remove(Person person)
        {
            _users.Remove(person);
            SaveChanges();
        }

        public void DoChanges()
        {
            SaveChanges();
        }

        public List<Person> PersonsList
        {
            get { return _users; }
        }

        private void SaveChanges()
        {
            SerializationManager.Serialize(_users, FileFolderHelper.StorageFilePath);
        }
    }
}
