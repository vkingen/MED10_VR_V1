using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    [SerializeField] private string nameOfSceneToChangeTo;

    public void ChangeScene()
    {
        SceneManager.LoadScene(nameOfSceneToChangeTo);
    }
}
