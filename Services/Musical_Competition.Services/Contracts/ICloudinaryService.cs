namespace Musical_Competition.Services.Contracts;

using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Musical_Competition.Common.Conventions;

public interface ICloudinaryService : ITransientService

{
    Task<string> UploadPictureAsync(IFormFile pictureFile, string fileName);
}
