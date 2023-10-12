using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animatie : MonoBehaviour
{
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        List<GameObject> cacti = new List<GameObject>();
        foreach (GameObject cactus in GameObject.FindObjectsOfType(typeof(GameObject)))
            if (cactus.name == "Cactus")
            {

                foreach (GameObject otherCactus in cacti)
                {
                    float distance = Vector3.Distance(cactus.transform.position, otherCactus.transform.position);
                    if (distance < 0.25)
                        animator.SetBool("isAttacking", true);
                    else
                        animator.SetBool("isAttacking", false);
                }

                cacti.Add(cactus);

            }

    }
}
