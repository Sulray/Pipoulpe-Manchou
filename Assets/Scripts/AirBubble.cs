using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirBubble : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Pause()
    {
        gameObject.SetActive(false);
        new WaitForSeconds(3f);
        gameObject.SetActive(true);
    }
}
