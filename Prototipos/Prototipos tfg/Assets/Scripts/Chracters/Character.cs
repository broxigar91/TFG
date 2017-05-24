using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[System.Serializable]
public class Character:Unit{

    public struct currentJobData
    {
        public int currentJoblvl; //nivel del trabajo actual
        public int jobXP;  //experiencia del trabajo actual
    }

    public int currentExp; //experiencia actual del personaje
    public int lvlupExp; //experiencia necesaria para subir de nivel
    
    public bool activaded; //esta variable se usa para activar al personaje dentro de la party.
    public Dictionary<string,currentJobData> jobsInfo; //estructura que guardará el nivel de cada trabajo en cada personaje
    public Job job;
    public currentJobData currentJobInfo;
    public Dictionary<Itemtype, Item> equip;
    public List<char> grow;



    public void expGain(int expGained,int jobxP)
    {
        currentExp += expGained;
        currentJobInfo.jobXP += jobxP;

        while(currentExp >= lvlupExp)
        {
            currentExp = currentExp - lvlupExp; //si es = sera 0, si es > será la diferencia
            lvlUp();
        }

        while(currentJobInfo.jobXP>=job.joblvl[currentJobInfo.currentJoblvl])
        {
            currentJobInfo.jobXP -= job.joblvl[currentJobInfo.currentJoblvl];
            currentJobInfo.currentJoblvl++;
        }

    }

    public void lvlUp()
    {
        level++;
        lvlupExp = level * 100; //1 -> 100, 2-> 200, 3-> 300

        maxHp += growUp(grow[0], true);
        str += growUp(grow[1], false);
        def += growUp(grow[2], false);
        intelect += growUp(grow[3], false);
        mdef += growUp(grow[4], false);
        spe += growUp(grow[5], false);
    }

    private int growUp(char range, bool isHP)
    {
        int points=0;
        int rng;
        rng = Random.Range(0, 100);
        switch (range)
        {
            case 'S':
                if(level >=1 && level <=19)
                {      
                    if (isHP)
                    {
                        if(rng < 50)
                        {
                            points = 24;
                        }
                        else
                        {
                            points = 23;
                        }
                    }
                    else
                    {
                        if(rng < 25)
                        {
                            points = 5;
                        }
                        else
                        {
                            points = 4;
                        }
                    }
                }
                else if(level >=20 && level <=59)
                {
                    if (isHP)
                    {
                        if (rng < 50)
                        {
                            points = 10;
                        }
                        else
                        {
                            points = 9;
                        }
                    }
                    else
                    {
                        if (rng < 75)
                        {
                            points = 3;
                        }
                        else
                        {
                            points = 2;
                        }
                    }
                }
                else if (level >=60 && level <=99)
                {
                    if (isHP)
                    {
                        if (rng < 50)
                        {
                            points = 6;
                        }
                        else
                        {
                            points = 4;
                        }
                    }
                    else
                    {
                        if (rng < 50)
                        {
                            points = 1;
                        }
                        else
                        {
                            points = 0;
                        }
                    }
                }

                break;
            case 'A':
                if (level >= 1 && level <= 19)
                {
                    if (isHP)
                    {
                        if (rng < 50)
                        {
                            points = 20;
                        }
                        else
                        {
                            points = 18;
                        }
                    }
                    else
                    {
                        if (rng < 90)
                        {
                            points = 5;
                        }
                        else
                        {
                            points = 4;
                        }
                    }
                }
                else if (level >= 20 && level <= 59)
                {
                    if (isHP)
                    {
                        if (rng < 50)
                        {
                            points = 10;
                        }
                        else
                        {
                            points = 8;
                        }
                    }
                    else
                    {
                        if (rng < 90)
                        {
                            points = 2;
                        }
                        else
                        {
                            points = 1;
                        }
                    }
                }
                else if (level >= 60 && level <= 99)
                {
                    if (isHP)
                    {
                        if (rng < 50)
                        {
                            points = 6;
                        }
                        else
                        {
                            points = 4;
                        }
                    }
                    else
                    {
                        if (rng < 50)
                        {
                            points = 1;
                        }
                        else
                        {
                            points = 0;
                        }
                    }
                }
                break;
            case 'B':
                if (level >= 1 && level <= 19)
                {
                    if (isHP)
                    {
                        if (rng < 50)
                        {
                            points = 12;
                        }
                        else
                        {
                            points = 10;
                        }
                    }
                    else
                    {
                        if (rng < 35)
                        {
                            points = 4;
                        }
                        else
                        {
                            points = 3;
                        }
                    }
                }
                else if (level >= 20 && level <= 59)
                {
                    if (isHP)
                    {
                        if (rng < 50)
                        {
                            points = 9;
                        }
                        else
                        {
                            points = 8;
                        }
                    }
                    else
                    {
                        if (rng < 35)
                        {
                            points = 3;
                        }
                        else
                        {
                            points = 2;
                        }
                    }
                }
                else if (level >= 60 && level <= 99)
                {
                    if (isHP)
                    {
                        if (rng < 50)
                        {
                            points = 6;
                        }
                        else
                        {
                            points = 4;
                        }
                    }
                    else
                    {
                        if (rng < 50)
                        {
                            points = 1;
                        }
                        else
                        {
                            points = 0;
                        }
                    }
                }
                break;
            case 'C':
                if (level >= 1 && level <= 19)
                {
                    if (isHP)
                    {
                        if (rng < 50)
                        {
                            points = 10;
                        }
                        else
                        {
                            points = 9;
                        }
                    }
                    else
                    {
                        if (rng < 40)
                        {
                            points = 3;
                        }
                        else
                        {
                            points = 2;
                        }
                    }
                }
                else if (level >= 20 && level <= 59)
                {
                    if (isHP)
                    {
                        if (rng < 50)
                        {
                            points = 9;
                        }
                        else
                        {
                            points = 7;
                        }
                    }
                    else
                    {
                        if (rng < 75)
                        {
                            points = 2;
                        }
                        else
                        {
                            points = 1;
                        }
                    }
                }
                else if (level >= 60 && level <= 99)
                {
                    if (isHP)
                    {
                        if (rng < 50)
                        {
                            points = 6;
                        }
                        else
                        {
                            points = 4;
                        }
                    }
                    else
                    {
                        if (rng < 50)
                        {
                            points = 1;
                        }
                        else
                        {
                            points = 0;
                        }
                    }
                }
                break;
            case 'D':
                if (level >= 1 && level <= 19)
                {
                    if (isHP)
                    {
                        if (rng < 50)
                        {
                            points = 9;
                        }
                        else
                        {
                            points = 7;
                        }
                    }
                    else
                    {
                        if (rng < 40)
                        {
                            points = 2;
                        }
                        else
                        {
                            points = 1;
                        }
                    }
                }
                else if (level >= 20 && level <= 59)
                {
                    if (isHP)
                    {
                        if (rng < 50)
                        {
                            points = 7;
                        }
                        else
                        {
                            points = 5;
                        }
                    }
                    else
                    {
                        if (rng < 90)
                        {
                            points = 1;
                        }
                        else
                        {
                            points = 0;
                        }
                    }
                }
                else if (level >= 60 && level <= 99)
                {
                    if (isHP)
                    {
                        if (rng < 50)
                        {
                            points = 6;
                        }
                        else
                        {
                            points = 4;
                        }
                    }
                    else
                    {
                        if (rng < 50)
                        {
                            points = 1;
                        }
                        else
                        {
                            points = 0;
                        }
                    }
                }
                break;
            case 'E':
                if (level >= 1 && level <= 19)
                {
                    if (isHP)
                    {
                        if (rng < 50)
                        {
                            points = 7;
                        }
                        else
                        {
                            points = 5;
                        }
                    }
                    else
                    {
                        if (rng < 90)
                        {
                            points = 1;
                        }
                        else
                        {
                            points = 0;
                        }
                    }
                }
                else if (level >= 20 && level <= 59)
                {
                    if (isHP)
                    {
                        if (rng < 50)
                        {
                            points = 4;
                        }
                        else
                        {
                            points = 3;
                        }
                    }
                    else
                    {
                        if (rng < 60)
                        {
                            points = 1;
                        }
                        else
                        {
                            points = 0;
                        }
                    }
                }
                else if (level >= 60 && level <= 99)
                {
                    if (isHP)
                    {
                        if (rng < 50)
                        {
                            points = 6;
                        }
                        else
                        {
                            points = 4;
                        }
                    }
                    else
                    {
                        if (rng < 50)
                        {
                            points = 1;
                        }
                        else
                        {
                            points = 0;
                        }
                    }
                }
                break;
        }

        return points;
    }


    public void setJob(string j)
    {

        job = JobManager.instance.getJob(j);
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

    public void equipItem(Item i)
    {
        if(equip.ContainsKey(i.type))
        {
            unapplyItemStats(equip[i.type]);
            equip[i.type] = i;
            applyItemStats(i);
        }
        else
        {
            equip.Add(i.type, i);
            applyItemStats(i);
        }
    }

    void applyItemStats(Item i)
    {
        hp += i.hp;
        str += i.str;
        def += i.def;
        intelect += i.intelect;
        mdef += i.mdef;
        spe += i.spe;
    }

    void unapplyItemStats(Item i)
    {
        hp -= i.hp;
        str -= i.str;
        def -= i.def;
        intelect -= i.intelect;
        mdef -= i.mdef;
        spe -= i.spe;
    }
}




[System.Serializable]
public class CharDB
{
    public List<Character> characters;
}