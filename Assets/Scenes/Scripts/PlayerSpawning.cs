using System;
using UnityEngine;

namespace Scenes.Scripts
{
    public class PlayerSpawning : MonoBehaviour
    {
        [SerializeField] protected GameObject[] players;
        public void Start()
        {
            var selectedCharacterIndex = PlayerPrefs.GetInt("SelectedCharacter");
            Instantiate(players[selectedCharacterIndex], Vector2.zero, Quaternion.identity);
        }
    }
}