using UnityEngine;

public class Blink : MonoBehaviour
{
    private float frequence = .5f;

    private float timer;

    private bool hidden;

    public MonoBehaviour component;

    private void Start()
    {
        timer = frequence;
        hidden = false;
    }

    private void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            hidden = !hidden;
            component.enabled = hidden;

            timer = frequence;
        }
    }
}