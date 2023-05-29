using UnityEngine;

public class ParticlesController : MonoBehaviour
{
    [SerializeField] private ParticleSystem particleSystemForward;
    [SerializeField] private ParticleSystem particleSystemBack;
    [SerializeField, ColorUsage(true, true)] private Color color;
    [SerializeField] private float timeToChangeDir;

    private Material materialForward;
    private Material materialBack;
    private float time = 0;
    private float duration;
    private bool value=true;

    void Start()
    {
        duration = particleSystemForward.main.duration;
        materialForward = particleSystemForward.GetComponent<Renderer>().material;
        materialBack = particleSystemBack.GetComponent<Renderer>().material;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            ChangeColor();
        }

        ChangeDirection();
    }

    private void ChangeDirection()
    {     
        time += Time.deltaTime;
        if(time>=duration+timeToChangeDir)
        {
            PlayParticles(value);
            value = !value;
            time = 0;
        }
    }

    private void PlayParticles(bool value)
    {
        if (value)
        {
            particleSystemForward.Play();
        }
        else
        {
            particleSystemBack.Play();
        }
    }

    private void ChangeColor()
    {
        materialBack.color = color;
        materialForward.color = color;
    }
}
