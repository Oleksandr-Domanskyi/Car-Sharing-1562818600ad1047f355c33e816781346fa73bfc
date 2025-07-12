using CarSharingDomain.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using Image = CarSharingDomain.DomainModels.Image;

namespace CarSharingDomain.Interfaces
{
    public interface ICarSharingRepositories
    {
        Task<IEnumerable<CarProfileModel?>> GetAll();
        Task<CarProfileModel?> GetByName(Guid Id);

        Task<IEnumerable<CarProfileModel?>> GetBySearchName(string Search);

        Task<Image?> GetImageById(Guid imageId);

        Task Create (CarProfileModel model);

        Task SaveChanges();

        Task DeleteImageById(Guid id);

        Task DeleteCarSharing(Guid id);
    }
}
