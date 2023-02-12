using System;
using EntityFrameWorkLib;
using Model;

namespace DbDatamanager
{
	public class ChampionManager: IChampionsManager
    {
        private LolContext lolContext;

        public async Task<Champion?> AddItem(Champion? item)
        {
            if(item == null)
            {
                return null;

            }
            var addItem = await lolContext.AddAsync<Champion>(item);
            await lolContext.SaveChangesAsync();
            return addItem.Entity;
        }

        public async Task<bool> DeleteItem(Champion? item)
        {
            if (item == null)
            {
                return false;
            }
            var deleteItem = lolContext.Remove<Champion>(item);
            lolContext.SaveChanges();
            return true;
        }

        public Task<IEnumerable<Champion?>> GetItems(int index, int count, string? orderingPropertyName = null, bool descending = false)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Champion?>> GetItemsByCharacteristic(string charName, int index, int count, string? orderingPropertyName = null, bool descending = false)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Champion?>> GetItemsByClass(ChampionClass championClass, int index, int count, string? orderingPropertyName = null, bool descending = false)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Champion?>> GetItemsByName(string substring, int index, int count, string? orderingPropertyName = null, bool descending = false)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Champion?>> GetItemsByRunePage(RunePage? runePage, int index, int count, string? orderingPropertyName = null, bool descending = false)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Champion?>> GetItemsBySkill(Skill? skill, int index, int count, string? orderingPropertyName = null, bool descending = false)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Champion?>> GetItemsBySkill(string skill, int index, int count, string? orderingPropertyName = null, bool descending = false)
        {
            throw new NotImplementedException();
        }

        public async Task<int> GetNbItems()
        {
            var nbItems = lolContext.Champions.Count();
            return nbItems;
        }

        public Task<int> GetNbItemsByCharacteristic(string charName)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetNbItemsByClass(ChampionClass championClass)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetNbItemsByName(string substring)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetNbItemsByRunePage(RunePage? runePage)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetNbItemsBySkill(Skill? skill)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetNbItemsBySkill(string skill)
        {
            throw new NotImplementedException();
        }

        public Task<Champion?> UpdateItem(Champion? oldItem, Champion? newItem)
        {
            throw new NotImplementedException();
        }
    }
}

