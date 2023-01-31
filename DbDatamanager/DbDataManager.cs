using Model;

namespace DbDatamanager;
public class DbDataManager : IDataManager
{
    public IChampionsManager ChampionsMgr => throw new NotImplementedException();

    public ISkinsManager SkinsMgr => throw new NotImplementedException();

    public IRunesManager RunesMgr => throw new NotImplementedException();

    public IRunePagesManager RunePagesMgr => throw new NotImplementedException();
}