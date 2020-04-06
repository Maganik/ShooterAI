using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentManager : MonoBehaviour
{
    public RecurentNet network;
    public float reactionSpeed;
    public GameObject bulletPrefab;
    public int team;
    public float bulletTime;
    private float timeToShoot;
    public int maxHealth;
    private float fitness;
    private int healthPoints;


    // Start is called before the first frame update

    void Start()
    {
        timeToShoot = 0f;
        fitness = 0;
        healthPoints = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        timeToShoot -= Time.deltaTime;
        network.feedForward(getInputs());

        if (network.Output[0] > 0.5f)
        {
            moveForward(3f);
        }
        else
        {
            stopMoving();
        }
        if(network.Output[1] > 0.5f)
        {
            rotate(true, 30f);
        }
        if (network.Output[2] > 0.5f)
        {
            rotate(false, 30f);
        }
        if (network.Output[3] > 0.5f)
        {
            shoot();
        }

    }

    private void stopMoving()
    {
        gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
    }

    private void moveForward(float speed)
    {
        gameObject.GetComponent<Rigidbody>().velocity = gameObject.transform.forward * speed ;
    }

    private void rotate(bool rotWay, float rotSpeed)
    {
        if (rotWay)
            this.transform.Rotate(transform.up * rotSpeed * Time.deltaTime);
        else
            this.transform.Rotate(-transform.up * rotSpeed * Time.deltaTime);
    }

    private void shoot()
    {
        addFitness(-1f);
        if(timeToShoot<= 0f)
        {
            timeToShoot = bulletTime;
            GameObject bullet = GameObject.Instantiate(bulletPrefab, this.transform.position + transform.forward, Quaternion.identity);
            
            bullet.GetComponent<BulletManager>().direction = transform.forward;
            bullet.GetComponent<BulletManager>().emitingAgent = gameObject;
            bullet.transform.parent = gameObject.transform.parent;
        }
        else
        {
            addFitness(-1);
        }
    }

    private List<float> getInputs()
    {
        List<float> sensors = new List<float>();
        Vector3 pos = this.gameObject.transform.position;
        RaycastHit hit;
        
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit))
        {
            
            sensors.Add(1 - (hit.distance / 10f));
            if (hit.transform.gameObject.tag != "Agent")
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
                sensors.Add(1f);
            }     
            else
                sensors.Add(0f);
            if (hit.transform.gameObject.tag == "Agent" && hit.transform.gameObject.GetComponent<AgentManager>().team == this.team)
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.green);
                sensors.Add(1f);
            }
            else
                sensors.Add(0f);
            if (hit.transform.gameObject.tag == "Agent" && hit.transform.gameObject.GetComponent<AgentManager>().team != this.team)
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.red);
                sensors.Add(1f);
            }
            else
                sensors.Add(0f);
        }

        sensors.Add(timeToShoot);
        return sensors;
    }

    public float getFitness()
    {
        return fitness;
    }

    public void addFitness(float value)
    {
        fitness += value;
    }

}