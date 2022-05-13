using UnityEngine;

public class FaceMouse2D : MonoBehaviour
{
    public Transform gun;

    void Update()
    {
        if (transform.rotation.z >= 0.7 || transform.rotation.z <= -0.7)
        {
            gun.transform.localScale = new Vector3(1, -1, 1);
        }
        else
        {
            gun.transform.localScale = new Vector3(1, 1, 1);
        }

        Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 dir = Input.mousePosition - pos;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}