using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    #region Movement Vars

    public double followStartX = 0.0f;
    public double followEndX = 0.0f;
    public GameObject player;
    public GameObject cam;

    public float smoothSpeed = 0.125f;
    private Vector3 velo = Vector3.zero;

    #endregion

    private void Start()
    {
        Debug.Log("CameraController started.");
    }

    private void FixedUpdate()
    {


        if (player.transform.position.x > followStartX && cam.transform.position.x <= followEndX )
        {
            Vector3 pos = new Vector3(player.transform.position.x, cam.transform.position.y, cam.transform.position.z);
            Vector3 playPos = new Vector3(player.transform.position.x, 0, cam.transform.position.z);
            cam.transform.position = Vector3.SmoothDamp(cam.transform.position, playPos, ref velo ,smoothSpeed);
        }
    }

}
