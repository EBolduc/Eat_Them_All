using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detonation : MonoBehaviour
{
  
    public Vector3 bombPos;
    public float Power;
    public float Radius;

    void Awake()
    {
        
    }

    private void Update()
    {
        print(BombScript.instance.hasExplode);

        if (BombScript.instance.hasExplode == true)
        {
            AddExplosionForce(GetComponent<Rigidbody2D>(), Power * 100, bombPos, Radius);
            print("it was a great Bomb");
        }

    }


    public static void AddExplosionForce(Rigidbody2D body, float expForce, Vector3 expPosition, float expRadius)
    {
        var dir = (body.transform.position - expPosition);
        float calc = 1 - (dir.magnitude / expRadius);
        if (calc <= 0)
        {
            calc = 0;
        }

        body.AddForce(dir.normalized * expForce * calc);
    }


}
