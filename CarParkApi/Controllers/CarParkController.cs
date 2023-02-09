using CarParkApi.Domain;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CarParkApi.Controllers
{
    [ApiController]
    [Route("api/v1/car-park")]
    public class CarParkController : ControllerBase
    {
        private readonly ICarParkRepository _carParkRepository;

        public CarParkController(ICarParkRepository carParkRepository) =>
            _carParkRepository = carParkRepository;

        /*
         * This endpoint differs slightly from the one proposed on the test because I thought it
         * made more sense from a user perspective to want a list of spaces that are available for
         * a duration rather than just listing the spaces available on a single day.
         * 
         * i.e. the user want's to specify the duration they want to park their car and the API
         * only returns the available spaces. 
         */

        [HttpGet]
        [Route("available-spaces")]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(IEnumerable<AvailableSpaceResponse>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAvailableSpaces([FromQuery] AvailableSpacesRequest request)
        {
            /*
             * In a real-world solution I'd use someting like FluentValidation to create a validator
             * to ensure the incoming request is valid so that the validation occurs before the request
             * even gets to the controller.
             */

            if (request.StartDate < DateTime.UtcNow.Date)
                return BadRequest("'start-date' cannot be in the past.");

            if (!DateRange.CanBeCreatedFrom(request.StartDate, request.EndDate))
                return BadRequest("'start-date' must be less than or equal to 'end-date'.");

            /*
             * Likewise this logic would be in some sort of service class e.g. var spaces = _carParkService.GetAvailableSpaces(duration);
             */

            var duration = DateRange.Between(request.StartDate, request.EndDate);
            var carPark = await _carParkRepository.Get();
            var availableSpaces = carPark
                .AvailableSpaces(duration)
                .Select(s => new AvailableSpaceResponse { Id = s.Id, Name = s.Name });

            return Ok(availableSpaces);
        }
    }
}
