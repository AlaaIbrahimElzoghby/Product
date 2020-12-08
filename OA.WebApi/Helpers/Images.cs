using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace OA.WebApi.Helpers
{
    public class Images
    {
        #region SingletonImplementation        
        private Images()
        {

        }
        public static Images Instance => Nested.Instance;
        private static class Nested
        {
            static Nested()
            {
                Instance = new Images();
            }
            public static Images Instance { get; private set; }
        }
        #endregion

        #region Methods
        public string Base64ToImage(string imageString)
        {
            try
            {
                // Convert from base64 representation to image
                byte[] imageBytes = Convert.FromBase64String(imageString);

                //Path to save image
                String path = "~/Images/Products/";

                // Generating unique name for image
                string imageName = GetUniqueFileName("productImage");

                //set the image path
                string imgPath = Path.Combine(path, imageName);

                // Saving image
                File.WriteAllBytes(imgPath, imageBytes);

                // Return image name to save in database
                return imageName;
            }
            catch (Exception ex)
            {
                // we can log exception here.
                return null;
            }
        }

        private string GetUniqueFileName(string fileName)
        {
            fileName = Path.GetFileName(fileName);
            return Path.GetFileNameWithoutExtension(fileName)
                      + "_"
                      + Guid.NewGuid().ToString().Substring(0, 4)
                      + Path.GetExtension(fileName);
        }
    }
}
#endregion