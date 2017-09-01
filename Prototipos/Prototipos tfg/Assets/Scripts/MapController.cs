using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour {

    private Transform target;
    Camera cam; //main camera
    public float cam_speed; //velocidad a la que se mueve la camara
    private FadeManager fm;



    // Use this for initialization
    void Start () {
        cam = GetComponent<Camera>();
        target = Player.instance.transform;
        transform.position = Vector3.Lerp(transform.position, target.position, cam_speed) + new Vector3(0, 0, -10);
        
    }
	
	// Update is called once per frame
	void Update () {

        cam.orthographicSize = (Screen.height / 100f) / 4f; //ajustamos el tamaño de la camara

        if(target != null)
        {
            transform.position = Vector3.Lerp(transform.position, target.position, cam_speed) + new Vector3(0, 0, -10);
        }       
	}
}
