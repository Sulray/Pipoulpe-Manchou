using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubblesManager : MonoBehaviour
{
    [SerializeField] private List<AirBubble> bubbles;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i< bubbles.Count; i += 1)
        {
            if(!bubbles[i].gameObject.activeSelf)
            {
                StartCoroutine("Respawn");
            }
        }
    }

    IEnumerable Respawn()
    {
        yield return new WaitForSeconds(3f);
        //bubble.SetActive(true);
    }
}
