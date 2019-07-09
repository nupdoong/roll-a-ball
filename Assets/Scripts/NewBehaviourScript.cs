using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    public Text countText;
	private Rigidbody rb;
    int count;

    // Start is called before the first frame update
    void Start()
    {
		rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
		float MoveHorizontal = Input.GetAxis("Horizontal");
		float MoveVertical = Input.GetAxis("Vertical");

		Vector3 movement = new Vector3(MoveHorizontal, 0.0f, MoveVertical);
		rb.AddForce(movement);
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Item")
        {
            other.gameObject.SetActive(false);
            count += 1;
            SetCountText();
        } 
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
    }
}
