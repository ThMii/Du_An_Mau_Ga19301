using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class Heart : MonoBehaviour
    {
        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                GameSession gameSession = FindObjectOfType<GameSession>();
                if (gameSession != null)
                {
                    gameSession.AddLife();
                }
                Destroy(gameObject);
            }
        }
    }
}

