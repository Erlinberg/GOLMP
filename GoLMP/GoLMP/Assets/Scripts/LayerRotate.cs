using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerRotate : MonoBehaviour {

    private void Start()
    {
        this.transform.parent = GameObject.Find("Center").transform;
    }
}
