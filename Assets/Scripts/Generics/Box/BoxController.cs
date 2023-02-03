using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : MonoBehaviour {

    private Rigidbody2D body;
    [SerializeField] public GravGunController gunController;

    Coroutine delayCO;

    private void Awake() {
        body = GetComponent<Rigidbody2D>();
        delayCO = StartCoroutine(delay());
    }


    private void OnCollisionEnter2D(Collision2D collision) {
        if (gunController.hasObj && collision.gameObject.CompareTag("Player")) {
            body.mass = 0;
            if (delayCO != null) {
                StopCoroutine(delayCO);
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision) {
        if (gunController.hasObj && collision.gameObject.CompareTag("Player")) {
            StartCoroutine(delay());
        }
    }

    IEnumerator delay() {
        yield return new WaitForSeconds(0.1f);
        body.mass = 1;
    }

}
