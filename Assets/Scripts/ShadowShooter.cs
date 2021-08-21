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
            BoltTrajectory newBolt = new BoltTrajectory();
            newBolt.projectile = Instantiate(_boltPrefab, transform.position, Quaternion.identity).transform;
            newBolt.points[0] = transform.position;
            newBolt.points[3] = -transform.position;
            for (int i = 0; i <= 1; i++)
            {
                float t = i == 0 ? _alignT : 1 - _alignT;
                Vector3 startingPoint = Vector3.Lerp(transform.position, -transform.position, t);
                Vector3 alignDirection = VectorHelper.Rotate(transform.position, 90).normalized;
                newBolt.points[i + 1] = startingPoint + alignDirection * Random.Range(-_alignAmpletude, _alignAmpletude);
            }
            bolts.Add(newBolt);
            yield return new WaitForSeconds(_period);
        }
    }

    private void Update()
    {        
        Debug.Log($"{logT}  {Bezier.Evaluate(Vector3.right, Vector3.zero, Vector3.up, (Vector3) Vector2.one, logT)}");
        logT += 0.1f;
        for (int i = bolts.Count - 1; i > 0; i--)
        {
            bolts[i].time += Time.deltaTime * _speed;
            if (bolts[i].time >= 1f)
            {
                GameObject projectileToDestroy = bolts[i].projectile.gameObject;
                bolts.RemoveAt(i);
                Destroy(projectileToDestroy);
                continue;
            }
            bolts[i].projectile.position = Bezier.Evaluate(bolts[i].points[0], bolts[i].points[1], bolts[i].points[2], bolts[i].points[3], bolts[i].time);
        }
        //bolts.RemoveAll(bolt => bolt.projectile == null);
    }

    [System.Serializable]
    private class BoltTrajectory
    {
        public Vector3[] points = new Vector3[4];
        public Transform projectile;
        public float time;
    }
}
