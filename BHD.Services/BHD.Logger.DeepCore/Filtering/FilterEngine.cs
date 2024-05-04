using BHD.Logger.DeepCore.Storage;

namespace BHD.Logger.DeepCore;

public class FilterEngine
{
    private readonly DeepStorage _storage;

    public FilterEngine(DeepStorage deepStorage)
    {
        _storage = deepStorage;
    }

    
}
