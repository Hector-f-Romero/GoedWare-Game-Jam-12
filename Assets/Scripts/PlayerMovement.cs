using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float _speed = 5f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            this.transform.position += Vector3.left * this._speed * Time.deltaTime;
        }else if(Input.GetKey(KeyCode.D))
        {
            this.transform.position += Vector3.right * this._speed * Time.deltaTime;
        }
    }
}
