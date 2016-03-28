using System.Collections.Generic;

using LibDbOperations.Model;

namespace LibDbOperations.Controller {

    internal interface IKeyDb {

        List<Key> GetKeys();

    }

}