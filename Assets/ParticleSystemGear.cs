using UnityEngine;

public class ParticleSystemGear : MonoBehaviour
{
    public float emissionRate {
        get { return _emissionRate; }
        set {
            _emissionRate = value;
            GetComponent<ParticleSystem>().Play();
        }
    }

    float _emissionRate;

    void Start()
    {
        var ps = GetComponent<ParticleSystem>();
        _emissionRate = ps.emission.rate.constantMin;
    }

    void Update()
    {
        var em = GetComponent<ParticleSystem>().emission;
        em.rate = new ParticleSystem.MinMaxCurve(_emissionRate);
    }
}
