using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using TMPro;



public class DisplayThrowScore : MonoBehaviour
{
    Vector3 posBeforeThrow;
    XRGrabInteractable grabbable;
    public TMP_Text distanceTextBox;
    public TMP_Text bestDistanceTextBox;

    float bestDistance = 0f;


    // Start is called before the first frame update
    void Start()
    {

        grabbable = GetComponent<XRGrabInteractable>();
        grabbable.selectExited.AddListener(SetPosBeforeThrow);
        
    }

    void SetPosBeforeThrow(SelectExitEventArgs arg)
    {
        posBeforeThrow = this.transform.position;
        Debug.Log(posBeforeThrow);
    }


    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Target")
        {
            float distance = Vector3.Distance(posBeforeThrow, this.transform.position);
            Debug.Log("Distanta parcursa: " + distance);

            distanceTextBox.SetText($"Distance: {String.Format("{0:0.00}", distance)}");

            if (distance > bestDistance) {
                bestDistance = distance;
                bestDistanceTextBox.SetText($"Best Distance: {String.Format("{0:0.00}", bestDistance)}");
            }
        }
    }
}
