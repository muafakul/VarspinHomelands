using UnityEngine;
using System.Collections;

public class HealthPickup : MonoBehaviour {

    public Collider playerCol;
    public SphereCollider myCol;

	// Use this for initialization
	void Start () {
        playerCol = GameObject.FindGameObjectWithTag("Player").GetComponentInParent<Collider>();
        myCol = GetComponent<SphereCollider>();
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.Equals(playerCol)) {
            FindObjectOfType<Canvas>().GetComponent<CharStats>().CurrentHealth += 15;
            GameObject.Destroy(this.gameObject);
        }
    }
}
