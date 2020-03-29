using System;
using System.Collections.Generic;
using Luniakina04.Models;

namespace Luniakina04.Tools.DataStorage
{
    internal interface IDataStorage
    {

        void Add(Person person);

        void Remove(Person person);

        void DoChanges();

        List<Person> PersonsList { get; }
    }
}
