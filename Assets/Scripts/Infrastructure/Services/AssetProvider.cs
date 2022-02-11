using UnityEngine;

namespace Infrastructure.Services
{
    public class AssetProvider : IAssetProvider
    {
        public GameObject Instantiate(string path, RectTransform rectTransform) => 
            Object.Instantiate(Resources.Load<GameObject>(path), rectTransform);

        public GameObject Instantiate(string path, Transform transform) =>
            Object.Instantiate(Resources.Load<GameObject>(path), transform);

        public GameObject Instantiate(string path, Vector3 at) =>
            Object.Instantiate(Resources.Load<GameObject>(path), at, Quaternion.identity);
        
        public GameObject Instantiate(string path) =>
            Object.Instantiate(Resources.Load<GameObject>(path));
    }
}
