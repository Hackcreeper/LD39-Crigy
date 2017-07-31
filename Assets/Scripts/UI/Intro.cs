using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class Intro : MonoBehaviour
    {
        private void Update()
        {
            if (Input.anyKeyDown)
            {
                SceneManager.LoadScene("Game");
            }
        }
    }
}