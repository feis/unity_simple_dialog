using UnityEngine;

public class SharedAsset : MonoBehaviour
{
    public DialogMessageData Data;
    public int Index;

    private void Start()
    {
        if (name == "SharedSceneA")
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(
                "SharedSceneB", UnityEngine.SceneManagement.LoadSceneMode.Additive);
        }
        Data.Messages[Index] = name;
    }
}
