using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD : MonoBehaviour
{
    public GameObject[] lifes;
        void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DeactiveLife(int index)
    {
        lifes[index].SetActive(false);
    }
    public void ActivateLife(int index)
    {
        lifes[index].SetActive(true);
    }
}
