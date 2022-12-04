using APIGateway.ModelsDTO;
using ModelsDTO.Rentals;
using ModelsDTO.Cars;

namespace APIGateway;

public interface IRentalsRepository
{
    Task<List<RentalsDTO>?> GetAllAsyncByUsername(string username);
    /*Task<RentalsDTO?> FindByUsernameAndUid(string username, Guid rentalUid);
    Task<RentalsDTO?> CreateRental(RentalsDTO rental);
    */
}
