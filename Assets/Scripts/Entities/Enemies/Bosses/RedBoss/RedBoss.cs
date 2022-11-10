using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBoss : Boss
{
    public GameObject Blomb;
    public Transform BlombSpawnArea;

    public GameObject fireball, boulder;
    public Transform WheelOfFire;

    protected override void Awake()
    {
        base.Awake();
        AgroState = new BossAgroState(this, StateMachine, (RedBossData)data, "");
        AttackState = new BossAttackState(this, StateMachine, (RedBossData)data, "");
    }

    protected override void Start()
    {
        base.Start();
        Attacks.Add(new MortarStrike(this, (RedBossData)data, ""));
        Attacks.Add(new FireBolt(this, (RedBossData)data, ""));
        Attacks.Add(new BlombSquad(this, (RedBossData)data, ""));
        Attacks.Add(new WheelOfFire(this, (RedBossData)data, ""));

        //GameObject b = Instantiate(Blomb, transform.position + new Vector3(4, 0, 0), Quaternion.identity);
        //b.GetComponent<Blomb>().target = target;
    }
}
