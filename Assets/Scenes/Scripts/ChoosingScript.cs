using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChoosingScript : MonoBehaviour
{
    public void LoadScene()
    {
        SceneManager.LoadScene("Scenes/Level1");
    }

    public void ChooseCharacter(int playerIndex)
    {
        PlayerPrefs.SetInt("SelectedCharacter", playerIndex);
    }
}
