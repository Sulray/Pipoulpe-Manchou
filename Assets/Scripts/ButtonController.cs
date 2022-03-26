using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//(commmentaire de basile) ça sert que pour launch des platformes? faudra ptet le rename/changer le code
public class ButtonController : MonoBehaviour
{
    public bool isPushed;
    [SerializeField] private GameObject Platform;
    private void OnCollisionEnter2D(Collision2D collision) //faudra passer en trigger quand on aura un sol
    {
        isPushed = true;
        Platform.gameObject.GetComponent<PlatformMovement>().launchPlatform();
    }

    void Start()
    {
        isPushed = false;
    }

    
    void Update()
    {
        print(isPushed);
    }
}
