using UnityEngine;

namespace Infrastructure.Services
{
    public interface IAssetProvider : IService
    {
        GameObject Instantiate(string path, RectTransform rectTransform);
        GameObject Instantiate(string path, Transform transform);
        GameObject Instantiate(string path, Vector3 at);
        GameObject Instantiate(string path);
    }
}
