using UnityEngine.SceneManagement;

namespace Jenga.Services.Common
{
    public class SceneLoader : ISceneLoader
    {
        public void LoadScene(string name)
        {
            SceneManager.LoadScene(name);
        }
    }
}
