using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProcessController : MonoBehaviour
{


    public List<Process> processes = new List<Process>();

    public Material defoultMaterial;
    public Material zMaterial;
    public Material material;

    private int tempProcess;
    public Process zProcess;



    public PlayerBase ourPlayer;

    private float new_X;

    private void Start()
    {

        if (ourPlayer.GetComponent<Player1>())
        {
            new_X = -0.5f;
        }
        if (ourPlayer.GetComponent<Player2>())
        {
            new_X = 0.5f;
          
        }
    }

    public void ProcessesManager(Process process) {

        if (zProcess != null && process != zProcess) {
            return;
        }

        if (zProcess != null && process == zProcess) {
            process.gameObject.GetComponent<Renderer>().material = defoultMaterial;
            zProcess = null;
            return;
        }

        if (process == processes[0])
        {
            Debug.Log(CheckActiveElemets());
            if (CheckActiveElemets())
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + new_X);
            }
            else
            {
                for (int i = 0; i < tempProcess; i++)
                {
                    processes[i].gameObject.transform.position = new Vector3(processes[i].gameObject.transform.position.x, processes[i].gameObject.transform.position.y, processes[i].gameObject.transform.position.z + new_X);
                    processes[tempProcess + 1].gameObject.GetComponent<Renderer>().material = defoultMaterial;
                    processes.Remove(processes[tempProcess]);
                }
            }
        }

        if (process != processes[0] && process != processes[processes.Count-1]) {
            tempProcess = processes.IndexOf(process);
            processes[tempProcess + 1].gameObject.GetComponent<Renderer>().material = material;
            process.gameObject.SetActive(false);
        }


    }

    public void ZProcess(Process process) {
        zProcess = process;
        process.gameObject.GetComponent<Renderer>().material = zMaterial;
    }

    bool CheckActiveElemets() {
        for (int i = 0; i < processes.Count; i++) {
            if (processes[i].gameObject.active==false) {
                tempProcess = i;
                return false;
            } 
        }

        return true;
    }
}
