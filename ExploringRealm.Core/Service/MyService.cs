using System;
using System.Collections.Generic;
using System.Linq;
using ExploringRealm.Core.Model;
using Realms;

namespace ExploringRealm.Core.Service
{
    public class MyService
    {
        private readonly MapperService _mapper;

        public MyService()
        {
            _mapper = new MapperService();
        }

        public void ClearAllItems()
        {
            try
            {
                using(var realm = Realm.GetInstance())
                {
                    using(var transaction = realm.BeginWrite()) 
                    {
                        realm.RemoveAll<MyModelDto>();
                        transaction.Commit();
                    }
                }
            }
            catch(Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

        public List<MyModel> GetItems()
        {
            try
            {
                using(var realm = Realm.GetInstance())
                {
                    var items = realm.All<MyModelDto>();
                    if (items != null)
                    {
                        return _mapper.Mapper.Map<List<MyModel>>(items);
                    }
                }
            }
            catch(Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }

            return new List<MyModel>();
        }

        public MyModel GetItem(Guid id)
        {
            try
            {
                using(var realm = Realm.GetInstance())
                {
                    var item = realm.All<MyModelDto>()?.FirstOrDefault(i => i.Id == id.ToString());
                    if (item != null)
                    {
                        return _mapper.Mapper.Map<MyModel>(item);
                    }
                }
            }
            catch(Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }

            return new MyModel();
        }

        public void SaveItem(MyModel item)
        {
            try
            {
                using(var realm = Realm.GetInstance())
                {
                    using(var transaction = realm.BeginWrite()) 
                    {
                        var itemDb = _mapper.Mapper.Map<MyModelDto>(item);

                        realm.Add(itemDb);

                        transaction.Commit();
                    }
                }
            }
            catch(Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }
    }
}