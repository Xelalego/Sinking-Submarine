using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public string HoverMessage = "Click to interact";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public virtual void Hover()
    {

    }

    public virtual void Interact()
    {
        print(HoverMessage);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
