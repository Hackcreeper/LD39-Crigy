using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class SceneButton : MonoBehaviour
    {
        public string sceneName;

        public void Switch()
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
