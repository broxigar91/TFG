﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;




[System.Serializable]
public class Character:Unit{

    public struct currentJobData
    {
        public int currentJoblvl; //nivel del trabajo actual
        public int jobXP;  //experiencia del trabajo actual
    }


    public string portrait; //"foto" del personaje
    public int currentExp; //experiencia actual del personaje
    public int lvlupExp; //experiencia necesaria para subir de nivel
    
    public bool activaded; //esta variable se usa para activar al personaje dentro de la party.
    public Dictionary<string,currentJobData> jobsInfo; //estructura que guardará el nivel de cada trabajo en cada personaje
    public Job job;
    public currentJobData currentJobInfo;



    public void expGain(int expGained)
    {
        currentExp += expGained;

        if(currentExp >= lvlupExp)
        {
            currentExp = currentExp - lvlupExp; //si es = sera 0, si es > será la diferencia
            lvlUp();
        }

    }

    public void lvlUp()
    {
        level++;
        lvlupExp = level * 100; //1 -> 100, 2-> 200, 3-> 300
    }

    public void setJob(string j)
    {
        job = GameManager.instance.jobManager.GetComponent<JobManager>().getScript(j);
        applyJobStats(); //aplicamos los nuevos multiplicadores
    }


    public void changeJob(string j)
    {
        unapplyJobStats();//volvemos los stats a su forma original 

        //si el diccionario ya tenia un registro del trabajo actual se actualiza
        if (jobsInfo.ContainsKey(job.jobName))
        {
            jobsInfo[job.jobName] = currentJobInfo;
        }
        else //en caso contrario se crea el registro
        {
            jobsInfo.Add(job.jobName, currentJobInfo);
        }

        if(jobsInfo.ContainsKey(j))//si ya existia registro del trabajo a cambiar, actualizamos la informacion actual del trabajo a la vez que ajustamos 
        {
            setJob(j);
            currentJobInfo = jobsInfo[j];
        }
        else //en caso de no existir registro, actualizo el trabajo asociado y pongo los valores base a la información de éste
        {
            setJob(j);
            currentJobInfo.currentJoblvl = 1;
            currentJobInfo.jobXP = 0;
        }

    }

    public void applyJobStats()
    {
        if(job !=null)
        {
            hp += (int)(hp * job.hp);
            str += (int)(str * job.str);
            def += (int)(def * job.def);
            intelect += (int)(intelect * job.intelect);
            mdef += (int)(mdef * job.mdef);
            spe += (int)(spe * job.spe);
        }
    }

    public void unapplyJobStats()
    {
        if (job != null)
        {
            hp -= (int)(hp * job.hp);
            str -= (int)(str * job.str);
            def -= (int)(def * job.def);
            intelect -= (int)(intelect * job.intelect);
            mdef -= (int)(mdef * job.mdef);
            spe -= (int)(spe * job.spe);
        }
    }
}


[System.Serializable]
public class CharDB
{
    public List<Character> characters;
}