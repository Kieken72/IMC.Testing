using System.Collections.Generic;

namespace IMC.Testing.Mocking
{
    public interface IExternalFileShareRepository
    {
        IEnumerable<string> GetAllItems();
        void Save(IEnumerable<string> allLines);
    }
}