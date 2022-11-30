using ModelsDTO.Cars;

namespace APIGateway;

public interface ICarsRepository
{
    Task<PaginationCarsDTO?> FindAll(int page, int size, bool showAll);
}