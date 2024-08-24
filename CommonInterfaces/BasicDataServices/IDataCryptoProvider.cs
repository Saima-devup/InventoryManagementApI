using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonInterfaces.BasicDataServices
{
    /// <summary>
    /// As part of data confidentiality there could be some properties in an attribute that might need data encryption or hashing while before storing in DB
    /// This interface contains method that we need to implement and use in our service layer
    /// </summary>
    public interface IDataCryptoProvider
    {
        void Configure();
        void DecryptEntity<T>(T dataObject, CryptoType cryptoType);
        void EncryptEntity<T>(T dataObject, CryptoType cryptoType);
    }

    public enum CryptoType
    {
        None,
        InTable,
    }
}
