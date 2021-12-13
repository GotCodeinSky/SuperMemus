    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Health : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (gameObject.transform.position.y < -4)
        {
            Die();
        }
    }

    void Die()
    {
        SceneManager.LoadScene("Scenes/Level1");
    }
}
