using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardBehaviour : MonoBehaviour
{
    Rigidbody2D RB;
    float ReflectVelocity;
    AudioSource Audio;
    [SerializeField]
    AudioClip CardLaunch, CardStick, CardHitObject, CardBounces;
    public void FireCard(Vector3 velocity)
    {
        RB = GetComponent<Rigidbody2D>();
        RB.velocity = velocity;
        ReflectVelocity = velocity.magnitude;
        Audio = GetComponent<AudioSource>();
        PlaySound(CardLaunch);
        //RB.angularVelocity = -velocity.magnitude * 100;
    }
    private void Update()
    {
        if (transform.parent == null)
        {
            transform.rotation = Quaternion.Euler(Vector3.forward * Vector3.SignedAngle(Vector3.up, RB.velocity.normalized, Vector3.forward));
            transform.GetChild(0).Rotate(RB.velocity.magnitude * -100 * Time.deltaTime * Vector3.forward);
        }
            

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.collider.tag)
        {
            case Tags.Movable:
                //Rigidbody2D other = collision.gameObject.GetComponent<Rigidbody2D>();
                //other.AddForceAtPosition(RB.velocity * other.mass,
                //    collision.contacts[0].point, ForceMode2D.Impulse);
                RB.bodyType = RigidbodyType2D.Kinematic;
                RB.velocity = Vector2.zero;
                transform.parent = collision.transform;
                PlaySound(CardStick);
                break;
            case Tags.Stickable:
                RB.bodyType = RigidbodyType2D.Static;
                transform.parent = collision.transform;
                PlaySound(CardStick);
                break;
            case Tags.Reflector:
                PlaySound(CardBounces);
                break;
            case Tags.Finish:
                GameManager.Instance.GameComplete();
                break;
            default:
                transform.parent = collision.transform;
                PlaySound(CardHitObject);
                break;
        }
        transform.GetChild(0).localRotation = Quaternion.identity;

    }

    void PlaySound(AudioClip a)
    {
        Audio.clip = a;
        Audio.Play();
    }
    private void OnMouseDown()
    {
        if (!DeckController.Instance.enabled)
            return;
        DeckController.Instance?.Swap(transform);
    }
}
