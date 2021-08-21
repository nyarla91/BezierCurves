using System;
using System.Collections;
using System.Collections.Generic;
using NyarlaEssentials;
using UnityEngine;
using Random = UnityEngine.Random;

public class ShadowShooter : MonoBehaviour
{
    [SerializeField] private GameObject _boltPrefab;
    [SerializeField] private float _period;
    [SerializeField] private int _boltsAtOnce;
    [SerializeField] private float _speed;
    [SerializeField] [Range(0, 1)] private float _alignT;
    [SerializeField] private float _alignAmpletude;

    [SerializeField] private List<BoltTrajectory> bolts = new List<BoltTrajectory>();

    private float logT;

    private void Awake()
    {
        StartCoroutine(BoltLauncher());
    }

    public IEnumerator BoltLauncher()
    {
        while (true)
        {
            for (int i = 0; i < _boltsAtOnce; i++)
            {
                BoltTrajectory newBolt = new BoltTrajectory();
                newBolt.projectile = Instantiate(_boltPrefab, transform.position, Quaternion.identity).transform;
                Vector3[] points = new Vector3[4];
                points[0] = transform.position;
                points[3] = -transform.position;
                for (int j = 0; j <= 1; j++)
                {
                    float t = j == 0 ? _alignT : 1 - _alignT;
                    Vector3 startingPoint = Vector3.Lerp(transform.position, -transform.position, t);
                    Vector3 alignDirection = VectorHelper.Rotate(transform.position, 90).normalized;
                    points[j + 1] = startingPoint + alignDirection * Random.Range(-_alignAmpletude, _alignAmpletude);
                }
                newBolt.bezier = new BezierCurve(points);
                newBolt.CalculateLength();
                bolts.Add(newBolt);
            }
            yield return new WaitForSeconds(_period);
        }
    }

    private void Update()
    {        
        logT += 0.1f;
        for (int i = bolts.Count - 1; i > 0; i--)
        {
            bolts[i].time += Time.deltaTime * _speed / bolts[i].TrajectoryLength;
            if (bolts[i].time >= 1f)
            {
                GameObject projectileToDestroy = bolts[i].projectile.gameObject;
                bolts.RemoveAt(i);
                Destroy(projectileToDestroy);
                continue;
            }
            bolts[i].projectile.position = bolts[i].bezier.Evaluate(bolts[i].time);
        }
        //bolts.RemoveAll(bolt => bolt.projectile == null);
    }

    [System.Serializable]
    private class BoltTrajectory
    {
        public BezierCurve bezier;
        public Transform projectile;
        public float time;

        public float TrajectoryLength { private set; get; }

        public void CalculateLength()
        {
            TrajectoryLength = bezier.PathLength(8);
        }
    }
}
