using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    double timeInstantiated;

    public float assignedTime;

    void Start()
    {
        timeInstantiated = SongManager.GetAudioSourceTime();
    }

    public void OnTriggerEnter(Collider collision)
    {
        transform.parent.GetComponent<Lane>().CollisionDetected(this);
        Debug.Log("Parent collided child ");
        //    if(collision.gameObject.name == "Ball") {
        //      GameObject.Find("Timer").GetComponent<Timer>().whateverYouWant();
        //    }
    }

    // Update is called once per frame
    void Update()
    {
        double timeSinceInstantiated =
            SongManager.GetAudioSourceTime() - timeInstantiated;
        float t =
            (
            float
            )(timeSinceInstantiated / (SongManager.Instance.noteTime * 2));

        if (t > 1)
        {
            Destroy (gameObject);
        }
        else
        {
            transform.localPosition =
                Vector3
                    .Lerp(Vector3.forward * SongManager.Instance.noteSpawnY,
                    Vector3.forward * SongManager.Instance.noteDespawnY,
                    t);
            GetComponent<SpriteRenderer>().enabled = true;
            GetComponentInChildren<MeshRenderer>().enabled = true;            
        }
    }
}
