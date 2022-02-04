using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Clouds : MonoBehaviour
{
    [SerializeField] private int CloudSpeed = 1;
    [SerializeField] private float CloudDirection = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CloudDirection -= Time.deltaTime * CloudSpeed;
        transform.position = new Vector3(CloudDirection, transform.position.y, transform.position.z);
    }
}
