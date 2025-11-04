using UnityEngine;
using Zenject;

namespace Game.SceneNavigation
{
    public class GameNavigationMethods : MonoBehaviour
    {
        [Inject] private GameNavigation gameNavigation;


        public void StartGame()
        {
            gameNavigation.StartGame();
        }

        public void QuitGame()
        {
            gameNavigation.QuitGame();
        }

    }
}