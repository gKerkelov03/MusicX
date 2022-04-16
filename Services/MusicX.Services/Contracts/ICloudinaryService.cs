namespace MusicX.Services.Contracts;

using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using MusicX.Common.Conventions;

public interface ICloudinaryService : ITransientService

{
    Task<string> UploadPictureAsync(IFormFile pictureFile, string fileName);
}
