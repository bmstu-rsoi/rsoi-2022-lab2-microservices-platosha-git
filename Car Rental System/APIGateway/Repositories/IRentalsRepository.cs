using ModelsDTO.Rentals;

namespace APIGateway;

public interface IRentalsRepository
{
    Task<PaginationRentalsDTO?> FindAllByUsername(string username);
}
