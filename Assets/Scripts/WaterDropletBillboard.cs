using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterDropletBillboard : MonoBehaviour
{
    Camera cam;
    public float gravity = 1f;
    public float speed = 0f;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        StartCoroutine(DieAfterSeconds(5));
    }
    IEnumerator DieAfterSeconds(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        Destroy(gameObject);

    }
    void Update()
    {
        transform.LookAt(cam.transform);
        speed -= gravity * Time.deltaTime;
        transform.position += new Vector3(0, speed * Time.deltaTime, 0);
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        if (other.gameObject.tag == "LiquidCollector")
        {
            GlassContainerController glassContainerController = other.gameObject.GetComponentInParent<GlassContainerController>();
            glassContainerController.IncrementFillAmount(glassContainerController.fillIncrement);
            Destroy(gameObject);
        }
    }

}
