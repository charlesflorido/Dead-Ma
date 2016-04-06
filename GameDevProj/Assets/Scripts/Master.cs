using UnityEngine;
using System.Collections;

public class Master : MonoBehaviour {

    public int chance;
    public Transform target;
    public Transform spawn;

    public Spider spider1;
    public Spider spider2;
    public MinionZombie minion;
    public WeakZombie weak;

    void Start()
    {
        UserManager.instance.AddZombie();
    }

    void DecideToCreate()
    {

        int x = (int)Random.Range(1, Mathf.Abs(chance) + 1);

        if(x % chance == 0)
        {
            GetComponent<Animator>().SetBool("create", true);
        }
    }

    void StopCreating()
    {
        GetComponent<Animator>().SetBool("create", false);
    }

    void Create()
    {
        GetComponent<Animator>().SetBool("create", false);
        int x = (int)Random.Range(1, 4);

        if(x == 1)
        {
            InstanceSpider(spider1);
        }
        else if(x == 2)
        {
            InstanceWeak(weak);
            InstanceWeak(weak);
            InstanceWeak(weak);
        }
        else if(x == 3)
        {
            InstanceMinion(minion);
            InstanceMinion(minion);
        }
        else
        {
            InstanceSpider(spider2);
        }

    }

    public void InstanceSpider(Spider p)
    {
        p.target = target;
        p.GetComponent<EnemyAI>().target = target;
        Spider s = Instantiate(p, spawn.position, Quaternion.identity) as Spider;
       
    }

    public void InstanceWeak(WeakZombie p)
    {
        p.GetComponent<EnemyAI>().target = target;
        Instantiate(p, spawn.position, Quaternion.identity);
    }

    public void InstanceMinion(MinionZombie p)
    {
        p.GetComponent<EnemyAI>().target = target;
        Instantiate(p, spawn.position, Quaternion.identity);
    }

    
}
