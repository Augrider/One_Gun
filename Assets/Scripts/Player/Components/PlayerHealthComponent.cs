using Runtime.Entities.Effects;
using UnityEngine;

namespace Player
{
    public class PlayerHealthComponent : MonoBehaviour, INormalDamageAble
    {
        public int health;


        public void Receive(int damage)
        {
            health -= damage;
        }
    }
}