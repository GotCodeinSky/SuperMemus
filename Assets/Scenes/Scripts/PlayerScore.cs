using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScore : MonoBehaviour
{
    private float _timeLeft;
    private static int _score;

    public TMP_Text timeLeftUI;

    [SerializeField] private TMP_Text scoreUI;
    // Start is called before the first frame update
    void Start()
    {
        _timeLeft = 150f;
        _score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        _timeLeft -= Time.deltaTime;
        // _timeLeft = _timeLeft - Time.deltaTime;
        timeLeftUI.gameObject.GetComponent<TextMeshProUGUI>().text = "Time: " + (int)_timeLeft;
        scoreUI.GetComponent<TextMeshProUGUI>().text = "Score: " + _score;
        if ((int) _timeLeft == 0)
        {
            SceneManager.LoadScene("Scenes/Level1");
        }
    }

    public static void CollectMoney()
    {
        _score += 100;
    }
}
