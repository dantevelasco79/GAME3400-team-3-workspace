using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EvidenceScript : MonoBehaviour
{
    public Text evidenceText;
    // Start is called before the first frame update
    void Start()
    {
        evidenceText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 5))
        {
            if (hit.collider.CompareTag("Evidence"))
            {
                evidenceText.gameObject.SetActive(true);
            }
            else
            {
                evidenceText.gameObject.SetActive(false);
            }
        }
        else
        {
            evidenceText.gameObject.SetActive(false);
        }
    }
}
