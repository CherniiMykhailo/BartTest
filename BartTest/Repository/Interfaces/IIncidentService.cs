using BartTest.Dto;
using BartTest.Entities;

namespace BartTest.Repository.Interfaces
{
    public interface IIncidentService
    {
        Task<Incident> AddNewIncidentAsync(AddNewIncidentDto addNewIncidentDto);
    }
}
