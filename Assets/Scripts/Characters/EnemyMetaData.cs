using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMetaData : MonoBehaviour
{
    public string MobName;

    override
    public string ToString()
    {
        return MobName;
    }
}
