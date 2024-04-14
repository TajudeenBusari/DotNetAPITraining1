using APITraining.Data;
using APITraining.Models.Domain;

namespace APITraining.Repositories
{
    public class LocalImageRepository : IImageRepository
        
    {
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly NZWalksDBContext dBContext;

        public LocalImageRepository(IWebHostEnvironment webHostEnvironment, 
            IHttpContextAccessor httpContextAccessor,
            NZWalksDBContext dBContext)
        {
            this.webHostEnvironment = webHostEnvironment;
            this.httpContextAccessor = httpContextAccessor;
            this.dBContext = dBContext;
        }

        public async Task<Image> Upload(Image image)
        {
            //create a local file path
            var localFilePath = Path.Combine(webHostEnvironment.ContentRootPath, "Images", 
                $"{image.FileName}{image.FileExtension}");

            //read the file path and create it and copy to stream
            //copyToAsync is part of the IFormFile methods
            //Upload image to local path
            using var stream = new FileStream(localFilePath, FileMode.Create);
            await image.File.CopyToAsync(stream);



            //https://localhost:1234/images/image.jpg
            var urlFilePath = $"{httpContextAccessor.HttpContext.Request.Scheme}://{httpContextAccessor.HttpContext.Request.Host}{httpContextAccessor.HttpContext.Request.PathBase}/Images/{image.FileName}{image.FileExtension}";
           
            image.FilePath = urlFilePath;

            //Add Image to the Image table
            await dBContext.Images.AddAsync(image);
            await dBContext.SaveChangesAsync();
            return image;

        }
    }
}




/*We created a folder to store image into
 we will use web hosting to get the path of the folder
we need to inject the HttpcontextAccessor in the program.cs
file so we will able to access image via url*/