using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummieMove : MonoBehaviour
{
  public bool isMovingRight;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      if (Input.GetKeyDown(KeyCode.B))
      {
        //Vector3 Dir = 
        transform.position -= new Vector3( 1 , 0 , 0);        
      }
      if (Input.GetKeyDown(KeyCode.M))
      {
        //Vector3 Dir = 
        transform.position += new Vector3(1, 0, 0);
      }
  }
}
