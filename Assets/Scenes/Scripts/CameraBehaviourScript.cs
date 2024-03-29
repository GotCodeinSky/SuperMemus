using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviourScript : MonoBehaviour
{
    [SerializeField] private int xmin = -5;
    [SerializeField] private int xmax = 55;
    [SerializeField] private int ymin = -5;
    [SerializeField] private int ymax = 25;
    [SerializeField] private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        if (gameObject == null)
        {
            GameObject.FindGameObjectWithTag("Player");
        }
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (player == null) return;
        
        float x = Mathf.Clamp(player.transform.position.x, xmin, xmax);
        float y = Mathf.Clamp(player.transform.position.y, ymin, ymax);
        gameObject.transform.position = new Vector3 (x, y, gameObject.transform.position.z);
    }
}
