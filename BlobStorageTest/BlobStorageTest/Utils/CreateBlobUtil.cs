namespace BlobStorageTest.Utils;
public static class CreateBlobUtil
{
    public static string GetNewBlobFileName(string filename)
    {
        var guid = Guid.NewGuid().ToString().Replace("-", string.Empty);
        var date = DateTime.Now;
        filename = filename.Replace(" ", string.Empty);
       return guid + "-" + date.Day + date.Month + date.Year + date.Hour + date.Minute + date.Second + "-" + filename;
    }
}

