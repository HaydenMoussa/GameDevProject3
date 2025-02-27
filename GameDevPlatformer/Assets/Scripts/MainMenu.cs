using UnityEngine;
using UnityEngine.SceneManagement;
//Play button script from https://www.youtube.com/watch?v=DX7HyN7oJjE
public class MainMenu : MonoBehaviour
{
    public void PlayGame(){
        SceneManager.LoadScene(1);
    }
    public void Credits(){
        SceneManager.LoadScene(2);
    }
    public void MainMenuBack(){
        SceneManager.LoadScene(0);
    }
}
