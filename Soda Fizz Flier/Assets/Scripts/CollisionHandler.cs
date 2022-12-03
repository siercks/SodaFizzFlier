using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag)
        {
            case "Finish":
                Debug.Log("You reached the ending!");
                break;
            case "Obstacle":
                Debug.Log("You hit an obstacle!");
                break;
            case "Fuel":
                Debug.Log("You fueled up!");
                break;
            default:
                //ReloadLevel();
                break;
        }
    }
    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
