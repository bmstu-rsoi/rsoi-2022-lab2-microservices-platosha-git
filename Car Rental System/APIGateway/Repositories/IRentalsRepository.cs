using ModelsDTO.Rentals;

namespace APIGateway;

public interface IRentalsRepository
{
    Task<List<RentalsDTO>?> FindAllByUsername(string username);
    Task<RentalsDTO?> FindByUsernameAndUid(string username, Guid rentalUid);
}
