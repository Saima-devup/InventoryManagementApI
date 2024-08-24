using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonInterfaces.BasicDataServices
{
    /// <summary>
    /// This interface contains methods that are required to implement change tracking. 
    /// Change tracking means that we need a feature in our API where we need to keep track of changes in the object
    /// for example if user1 updates the description or price of the product entity, as part of this feature system
    /// will keep previous object before modifications and we can also get the change and compare change made by a certain user
    /// </summary>
    public interface IChangeTrackManager
    {
        public void SaveChange<T>(T item, string pk, ChangeType changeType, Dictionary<string, object> extraValues);
        public T GetSavedChange<T>(long id);
    }

    public enum ChangeType
    {
        None,
        Created,
        Viewed,
        Modified,
        Removed
    }
}
