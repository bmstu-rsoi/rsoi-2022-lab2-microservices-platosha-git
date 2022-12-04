using System.Web;
using APIGateway.ModelsDTO;
using Microsoft.AspNetCore.Mvc;
using ModelsDTO.Cars;
using ModelsDTO.Payments;
using ModelsDTO.Rentals;

namespace APIGateway.Domain;

public class RentalsService : IRentalsService
{
    private readonly ICarsRepository _carsRepository;
    private readonly IRentalsRepository _rentalsRepository;
    private readonly IPaymentsRepository _paymentsRepository;

    public RentalsService(ICarsRepository carsRepository, IRentalsRepository rentalsRepository, 
        IPaymentsRepository paymentsRepository)
    {
        _carsRepository = carsRepository;
        _rentalsRepository = rentalsRepository;
        _paymentsRepository = paymentsRepository;
    }

    private RentalResponse GetRentalResponse(RentalsDTO rental)
    {
        var response = new RentalResponse()
        {
            RentalUid = rental.RentalUid,
            Status = rental.Status,
            DateFrom = rental.DateFrom,
            DateTo = rental.DateTo
        };
        return response;
    }

    private async Task<RentalResponse> AddCarInfoAsync(Guid carUid, RentalResponse rental)
    {
        var car = await _carsRepository.GetAsyncByUid(carUid);
        rental.Car = new CarInfo()
        {
            CarUid = carUid,
            Brand = car.Brand,
            Model = car.Model,
            RegistrationNumber = car.RegistrationNumber
        };

        return rental;
    }
    
    private async Task<RentalResponse> AddPaymentInfoAsync(Guid paymentUid, RentalResponse rental)
    {
        var payment = await _paymentsRepository.GetAsyncByUid(paymentUid);
        rental.Payment = new PaymentInfo()
        {
            PaymentUid = payment.PaymentUid,
            Status = payment.Status,
            Price = payment.Price
        };

        return rental;
    }

    public async Task<List<RentalResponse>?> GetAllAsync(string username)
    {
        var rentals = await _rentalsRepository.GetAllAsyncByUsername(username);
        var response = new List<RentalResponse>(rentals.Count);
        foreach (var rental in rentals)
        {
            var res = GetRentalResponse(rental);
            await AddCarInfoAsync(rental.CarUid, res);
            await AddPaymentInfoAsync(rental.PaymentUid, res);
            response.Add(res);
        }

        return response;
    }
    
    /*public async Task<List<RentalsDTO>?> FindAllByUsername(string username)
    {
        var rental = await _rentalsRepository.FindAllByUsername(username);
    }

    public async Task<RentalsDTO?> FindByUsernameAndUid(string username, Guid rentalUid)
    {
        var query = HttpUtility.ParseQueryString(string.Empty);
        query["X-User-Name"] = username;

        var response = await _httpClient.GetAsync($"/api/v1/rental/{rentalUid}/?{query}");
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<RentalsDTO?>();
    }
    
    public async Task<CreateRentalResponse> BookCar(string username, CreateRentalRequest request)
    {
        // var response = new CreateRentalResponse();
        // var newRental = GetRentalFromRequest(request, username);
        // var createdRental = await _rentalsRepository.CreateRental(newRental);
    }
    */
}