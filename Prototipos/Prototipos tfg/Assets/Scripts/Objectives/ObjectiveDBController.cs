using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ObjectiveDBController : MonoBehaviour {

    public ObjectiveDB db;

    void Start()
    {
        string datos = File.ReadAllText(Application.dataPath + "/Resources/objectives.json"); //establezco la ruta donde se encuentra el fichero json
        db = JsonUtility.FromJson<ObjectiveDB>(datos);
    }

    public List<Objective> completed()
    {
        return db.objectives.FindAll(x => x.complete == true);
    }

    public List<Objective> currentObjectives()
    {
        return db.objectives.FindAll(x => x.active == true && x.complete == false);
    }

    public void unlocks(int id) //este metdo desbloquea todos aquellos objetivos que se desbloquean a partir del objetivo pasado por parametro (en caso de poderse)
    {
        Objective ob = db.objectives.Find(x => x.id == id);//obtenemos el objetivo que nos concierne
        
        foreach(int i in ob.unlocks)//miramos en cada objetivo que desbloquea
        {
            if(isUnlockable(i))//en caso de que pueda ser desbloqueado
            {
                db.objectives.Find(x => x.id == i).active = true;//se activa
            }
        }
    }

    public bool activate(int i)
    {
        Objective ob = db.objectives.Find(x => x.id == i);

        if(ob.active)
        {
            return false;
        }
        else
        {
            ob.active = true;
            return true;
        }
    }

    public void complete(int id)
    {
        Objective ob = db.objectives.Find(x => x.id == id);

        if(!ob.complete)
        {
            ob.complete = true;
            unlocks(id);
        }
        GameManager.instance.currentObjectives = currentObjectives();
    }

    public bool isUnlockable(int id)
    {
        List<bool> results = new List<bool>();//lista para guardar si los requisitos para desbloqueo se cumplen

        Objective ob = db.objectives.Find(x => x.id == id);//obtenemos el objetivo a desbloquear

        foreach(int i in ob.requisits)//miramos si cada uno de los prerequisitos esta completado y añadimos el resultado de la consulta en la lista de resultados
        {
            results.Add(isCompleted(i));
        }


        //en caso de que haya 1 solo prerequisito no completado este objetivo no se puede activar
        if(results.Contains(false))
        {
            return false;
        }
        else
        {
            return true;
        }

    }

    public bool isCompleted(int i)
    {
        return db.objectives.Find(x => x.id == i).complete;
    }

    public void Save()
    {

    }

}
