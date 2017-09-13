using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class StatPreviewUI : MonoBehaviour {

    public Text label,previewText;
    public GameObject previewPanel;

    public void StatPreview(int i)
    {
        if (!previewPanel.activeSelf)
        {
            previewPanel.SetActive(true);
        }

        Debug.Log(label.text);

        //Dropdown d = chs[i].transform.Find("Job").GetComponent<Dropdown>();
        int hp, str, def, intel, mdef, spe;
        //Job j1 = JobManager.instance.getJob(d.captionText.text); //trabajo actual
        Job j2 = JobManager.instance.getJob(label.text); //trabajo "nuevo"
        Character c = Party.instance.characters[i];
        string s = "";

        //establecemos las variables provisionales para el preview
        hp = c.maxHp;
        str = c.str;
        def = c.def;
        intel = c.intelect;
        mdef = c.mdef;
        spe = c.spe;

        //quitamos los efectos del trabajo actual
        /*hp -= (int)(hp * j1.hp);
        str -= (int)(str * j1.str);
        def -= (int)(def * j1.def);
        intel -= (int)(intel * j1.intelect);
        mdef -= (int)(mdef * j1.mdef);
        spe -= (int)(spe * j1.spe);*/

        //aplicamos los efectos del "nuevo" trabajo
        hp += (int)(hp * j2.hp);
        str += (int)(str * j2.str);
        def += (int)(def * j2.def);
        intel += (int)(intel * j2.intelect);
        mdef += (int)(mdef * j2.mdef);
        spe += (int)(spe * j2.spe);

        //rellenamos el texto de la preview
        //Principio hp
        if (hp > c.m_hp)
            s += "<color=green>" + hp + "\n\n</color>";
        else if (hp < c.m_hp)
            s += "<color=red>" + hp + "\n\n</color>";
        else
            s += hp + "\n\n";
        //fin hp


        //principio fuerza
        if (str > c.m_str)
            s += "<color=green>" + str + "\n\n</color>";
        else if (str < c.m_str)
            s += "<color=red>" + str + "\n\n</color>";
        else
            s += str + "\n\n";
        //fin fuerza

        //principio defensa
        if (def > c.m_def)
            s += "<color=green>" + def + "\n\n</color>";
        else if (def < c.m_def)
            s += "<color=red>" + def + "\n\n</color>";
        else
            s += def + "\n\n";
        //fin defensa

        //principio intelecto
        if (intel > c.m_int)
            s += "<color=green>" + intel + "\n\n</color>";
        else if (intel < c.m_int)
            s += "<color=red>" + intel + "\n\n</color>";
        else
            s += intel + "\n\n";
        //fin intelecto

        //principio mdef
        if (mdef > c.m_mdef)
            s += "<color=green>" + mdef + "\n\n</color>";
        else if (mdef < c.m_mdef)
            s += "<color=red>" + mdef + "\n\n</color>";
        else
            s += mdef + "\n\n";
        //fin mdef

        //principio velocidad
        if (spe > c.m_spe)
            s += "<color=green>" + spe + "\n\n</color>";
        else if (spe < c.m_spe)
            s += "<color=red>" + spe + "\n\n</color>";
        else
            s += spe + "\n\n";
        //fin velocidad

        previewText.text = s;
    }

    public void HidePreview()
    {
        if (previewPanel.activeSelf)
        {
            previewPanel.SetActive(false);
        }
    }
}
