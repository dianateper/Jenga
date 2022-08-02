using UnityEngine;

namespace Jenga.Services.Common
{
    public class ResourceProvider
    {
        public GameObject LoadGameObject(string path)
        {
            return Resources.Load<GameObject>(path);
        }
    }
}