using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    // Dit maakt een private voor startPos.
    private Vector3 startPos;
    
    // Dit maakt een private voor repeatWidth.
    private float repeatWidth;
    
    void Start()
    {
        // Hier maken we duidelijk dat startPos transform.position heet.
        startPos = transform.position;
        
        // Hier maken we duidelijk dat repeatWitdh transform.position heet.
        repeatWidth = GetComponent<BoxCollider>().size.x / 2;
    }

    // Dit zorgt ervoor dat alles wat er tussen staa constant wordt uitgevoert.
    void Update()
    {
        // Dit zorgt ervoor dat als de achtergrond op een bepaalde plek is hij wordt herhaald.
        if (transform.position.x < startPos.x - repeatWidth)
        {
            transform.position = startPos;
        }
    }
}
