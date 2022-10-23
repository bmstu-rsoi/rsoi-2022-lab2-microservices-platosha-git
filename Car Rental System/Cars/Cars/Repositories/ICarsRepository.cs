using System.Collections.Generic;
using Cars.ModelsDB;

namespace Cars.Repositories
{
    public enum ExitCode
    {
        Success,
        Error
    }
    
    public interface ICarsRepository
    {
        List<Car> FindAll();
    }
}