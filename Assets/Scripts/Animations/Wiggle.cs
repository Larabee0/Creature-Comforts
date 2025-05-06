using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wiggle : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float magnitude;
    [SerializeField] GameObject phoneDialogue;
    [SerializeField] GeneralAudio generalAudio;
    Transform tf;
    Vector3 startRot;
    float clock = 0;

    private void Start()
    {
        tf = gameObject.transform;
        startRot = tf.rotation.eulerAngles;
    }

    public bool wiggling;

    public void SetWiggling(bool b)
    {
        phoneDialogue.SetActive(b);
        wiggling = b;
        if (!b)
        {
            tf.rotation = Quaternion.Euler(startRot);
            clock = 0;
        }
        else
        {
            generalAudio.PlayPhone();
        }
    }

    void Update()
    {
        if (wiggling)
        {
            clock += Time.deltaTime * speed;

            tf.rotation = Quaternion.Euler(startRot + new Vector3(0, 0, Mathf.Sin(clock) * magnitude));
            if (!generalAudio.audioSource.isPlaying)
            {
                generalAudio.PlayPhone();
            }
        }
    }
}
