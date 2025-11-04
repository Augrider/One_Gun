using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.SceneNavigation
{
    /// <summary>
    /// Used to go between menus and levels
    /// </summary>
    public class GameNavigation : MonoBehaviour
    {
        //Scene references

        //TODO: Proper scene management, main menu, pause menu
        public void StartGame()
        {
            SceneManager.LoadScene(0);
        }

        public void QuitGame()
        {
            Application.Quit();
        }
    }
}