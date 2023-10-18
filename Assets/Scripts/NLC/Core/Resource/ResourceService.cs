using System.Net;
using Cysharp.Threading.Tasks;
using UnityEngine.Video;

namespace NLC.Core.Resource
{
    public static class ResourceService
    {
        public static async UniTask<byte[]> Download(string url)
        {
            WebClient client = new();
            return await client.DownloadDataTaskAsync(url);
        }
    }
}