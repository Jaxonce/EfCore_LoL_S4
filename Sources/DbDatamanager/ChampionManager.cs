using System;
using EntityFrameWorkLib;
using Model;
using Shared;

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

        public async Task<IEnumerable<Champion?>> GetItems(int index, int count, string? orderingPropertyName = null, bool descending = false)
        {
            IEnumerable<Champion> champions = lolContext.Champions.Skip(index * count)
                                                                  .Take(count)
                                                                  .OrderBy(champions => orderingPropertyName)
                                                                  .Select(champions => champions.ToPoco());
            return champions;

        }

        public Task<IEnumerable<Champion?>> GetItemsByName(string substring, int index, int count, string? orderingPropertyName = null, bool descending = false)

            => lolContext.Champions.Select(champion=> champion.ToPoco()).GetItemsWithFilterAndOrdering(champ => filterByName(champ, substring), index, count, orderingPropertyName, descending);

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

        public async Task<int> GetNbItems() => lolContext.Champions.Count();

        private Func<Champion, string, bool> filterByName = (champ, substring) => champ.Name.Contains(substring, StringComparison.InvariantCultureIgnoreCase);

        public Task<int> GetNbItemsByName(string substring)
        
           => lolContext.Champions.GetNbItemsWithFilter(champ => filterByName(champ.ToPoco(), substring));

        public Task<Champion?> UpdateItem(Champion? oldItem, Champion? newItem)

           => lolContext.Champions.Select(champions => champions.ToPoco()).ToList().UpdateItem(oldItem, newItem);


        //Pas fait => mettre en place skillentity etc...

        private Func<Champion, string, bool> filterByCharacteristic = (champ, charName) => champ.Characteristics.Keys.Any(k => k.Contains(charName, StringComparison.InvariantCultureIgnoreCase));

        public Task<IEnumerable<Champion?>> GetItemsByCharacteristic(string charName, int index, int count, string? orderingPropertyName = null, bool descending = false)
        
            => lolContext.Champions.Select(champion=>champion.ToPoco()).GetItemsWithFilterAndOrdering(
                          champ => filterByCharacteristic(champ, charName),
                          index, count, orderingPropertyName, descending);

        private Func<Champion, ChampionClass, bool> filterByClass = (champ, championClass) => champ.Class == championClass;
        public Task<IEnumerable<Champion?>> GetItemsByClass(ChampionClass championClass, int index, int count, string? orderingPropertyName = null, bool descending = false)

            => lolContext.Champions.Select(champion=>champion.ToPoco()).GetItemsWithFilterAndOrdering(
                    champ => filterByClass(champ, championClass),
                    index, count, orderingPropertyName, descending);

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

        public Task<int> GetNbItemsByCharacteristic(string charName)
        
          =>  lolContext.Champions.GetNbItemsWithFilter(champ => filterByCharacteristic(champ.ToPoco(), charName));


        public Task<int> GetNbItemsByClass(ChampionClass championClass)

            => lolContext.Champions.GetNbItemsWithFilter(champ => filterByClass(champ.ToPoco(), championClass));
    }
}

