using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    public GameObject player; //玉のオブジェクト

    private Vector3 offset; //玉からカメラまでの距離

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + offset;
    }
}
