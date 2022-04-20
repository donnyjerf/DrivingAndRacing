using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    public GameObject Player;
    private controller RR;
    public GameObject cameraConstraint;
    public GameObject cameralookAt;
    public float speed;
    public float defaltFOV = 0, desireFOV = 0;
    [Range(0, 2)]public float smothTime = 0;

    private void Awake() {
        Player = GameObject.FindGameObjectWithTag("Player");
        cameraConstraint = Player.transform.Find("camera constraint").gameObject;
        cameralookAt = Player.transform.Find("camera lookAt").gameObject;
        RR = Player.GetComponent<controller>();
        defaltFOV = Camera.main.fieldOfView;
    }

    void FixedUpdate() {
        follow();
        bootsFOV();
    }

    private void follow() {

        if (speed <= 23)
            speed = Mathf.Lerp(speed, RR.KPH / 2, Time.deltaTime);
        else
            speed = 23;

        gameObject.transform.position = Vector3.Lerp(transform.position, cameraConstraint.transform.position, Time.deltaTime * speed);
        gameObject.transform.LookAt(cameralookAt.gameObject.transform.position);
    }
    private void bootsFOV()
    {
        if (Input.GetKey(KeyCode.LeftShift))
            Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, desireFOV, Time.deltaTime * smothTime);
        else
            Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, defaltFOV, Time.deltaTime * smothTime);
    }
}
