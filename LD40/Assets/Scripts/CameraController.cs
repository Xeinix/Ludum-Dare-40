using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    #region Movement Vars

    public double followStartX = 0.0f;
    public double followEndX = 0.0f;
    public GameObject player;
    public GameObject cam;

    #endregion

    private void Start()
    {
        Debug.Log("CameraController started.");
    }

    private void Update()
    {


        if (player.transform.position.x > followStartX && cam.transform.position.x <= followEndX )
        {
            cam.transform.position = new Vector3(player.transform.position.x, cam.transform.position.y, cam.transform.position.z);
        }
    }

}
