using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public float Speed;
    public float rotationSpeed;

    public Rigidbody rb;
    bool Go;
    private void OnEnable()
    {
        CornerScript.Corner += Rotate;
        MenuController.LevelBegin += LevelStart;
        LevelManagerNew.Fail += fail;
        LevelManagerNew.LevelEnd += fail;
        MenuController.RestartPanelActive += GoToggle;
    }
    private void OnDisable()
    {
        CornerScript.Corner -= Rotate;
        MenuController.LevelBegin -= LevelStart;
        LevelManagerNew.Fail -= fail;
        LevelManagerNew.LevelEnd -= fail;
        MenuController.RestartPanelActive -= GoToggle;
    }
    void GoToggle(bool b)
    {
        b = !b;
        Debug.Log("переключил" + b);
        Go = b;
    }
    void fail()
    {
        Go = false;
    }
    void LevelStart()
    {
        Go = true;
    }
    private void FixedUpdate()
    {
        if (Go)
        {
            MoveIt();
        }
        
    }
    private void MoveIt()
    {
        Vector3 moveDirection = transform.forward * Speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + moveDirection);
    }
    //public void Rotate(bool right)
    //{   
    //    float Amount = right ? 90f : -90f;
    //    Debug.Log("" + Amount);
    //    Quaternion Rotation = Quaternion.Euler(0, transform.eulerAngles.y + Amount, 0);
    //    transform.rotation = Rotation;
    //}
    bool isRotating;
    public void Rotate(bool right)
    {
        if (!isRotating)
        {
            float amount = right ? 90f : -90f;
            float targetAngle = transform.eulerAngles.y + amount;
            StartCoroutine(RotateTowardsAngle(targetAngle));
        }
    }

    private IEnumerator RotateTowardsAngle(float targetAngle)
    {
        isRotating = true;
        Quaternion targetRotation = Quaternion.Euler(0, targetAngle, 0);

        while (Quaternion.Angle(transform.rotation, targetRotation) > 0.1f)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            yield return null;
        }

        transform.rotation = targetRotation;
        isRotating = false;
    }
}


