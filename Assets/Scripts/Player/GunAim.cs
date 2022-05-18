using UnityEngine;

public class GunAim : MonoBehaviour
{
    //Controls
    [SerializeField] private KeyCode right;
    [SerializeField] private KeyCode left;
    [SerializeField] private KeyCode up;
    [SerializeField] private KeyCode down;

    // Update is called once per frame
    void Update()
    {
        aimAngle();
    }


    // Aiming direction of gun
    private void aimAngle()
    {
        int angle;

        if ((Input.GetKey(right) || Input.GetKey(left)) && (Input.GetKey(up) || Input.GetKey(down)))
            angle = 45;
        else if (Input.GetKey(up) || Input.GetKey(down))
            angle = 90;
        else
            angle = 0;

        if (Input.GetKey(down))
            angle *= -1;

        transform.localEulerAngles = new Vector3(0, 0, angle);
    }
}
