using System.IO;
using System.Linq;

namespace ASP_Angular.Core.Models
{
    public class PhotoSettings
    {
        public int MaxByte { get; set; }
        public string[] AcceptedFileType { get; set; }
        public bool IsSupportFile(string fileName){
            return AcceptedFileType.Any(s=>s == Path.GetExtension(fileName).ToLower());
         }
    }
}