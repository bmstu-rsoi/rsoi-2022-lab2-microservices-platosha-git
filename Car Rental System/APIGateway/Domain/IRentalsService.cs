using APIGateway.ModelsDTO;
using ModelsDTO.Rentals;

namespace APIGateway.Domain;

public interface IRentalsService
{
    Task<List<RentalResponse>?> GetAllAsync(string username);
    /*Task<RentalsDTO?> FindByUsernameAndUid(string username, Guid rentalUid);
    Task<CreateRentalResponse> BookCar(string username, CreateRentalRequest request);
    */
}