using APITraining.Models.Domain;
using System.Net;

namespace APITraining.Repositories
{
    public interface IImageRepository
    {
        Task <Image>Upload(Image image);
    }
}
