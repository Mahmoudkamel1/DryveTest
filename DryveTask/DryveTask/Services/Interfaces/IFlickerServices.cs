using System.Collections.Generic;
using System.Threading.Tasks;
using DryveTask.Models;

namespace DryveTask.services.Interfaces
{
    public interface IFlickrServices
    {
        Task<List<Photo>> GetPictures();
    }
}