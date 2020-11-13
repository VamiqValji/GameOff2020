using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiddleBottomSideCheck : MonoBehaviour
{
    public GameObject BottomFollowSideCheck;
    public float Distance = 10f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void FollowPlayer(float maxHeight)
    {
        //BottomFollowSideCheck.position.y = BottomFollowSideCheck.transform.up + maxHeight;
        BottomFollowSideCheck.transform.Translate(transform.position.x, transform.position.y - Distance, transform.position.z);
        Debug.Log("followplayer");
    }
}
