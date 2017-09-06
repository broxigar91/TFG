using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BattleController : MonoBehaviour {

    public enum BattleState
    {
        START,
        WAITING,
        PLAYER_CHOICE,
        ENEMY_CHOICE,
        SELECT_TARGET,
        DMG_PHASE,
        ITEM_USE,
        WIN,
        LOSE,
        EXIT
    }

    public struct targetingInfo
    {
        public int target;
        public Skill skill;
        public Item it;
        public bool enemy;
    }

    public targetingInfo info;
    private List<Character> battleMembers = new List<Character>();
    private List<Enemy> enemyMembers = new List<Enemy>();
    private BattleState currentState;
    private int enemyType;
    private float waitTime;
    private float cd1;
    private int pchoice,echoice,dmg;
    private bool actionRealized;
    private int zone;
    private string optionSelected;
    public List<Image> timebars,backgrounds,enemySprites;
    public Image c1, c2, c3, portrait1, portrait2, portrait3, ee1, ee2, ee3, background;
    public List<Text> health;
    public List<Text> mana;
    public GameObject actionPanel,skills,skillUIPrefab,selector,items,itemUIPrefab;
    public List<Skill> current_skills;
    public List<Text> dmgUI;
    private Selector sel;

    // Use this for initialization
	void Start () {
        zone = GameManager.instance.zona_actual;
        battleMembers = Party.instance.characters;
        enemyMembers = EnemyManager.instance.toBattle(zone);

        waitTime = 10.0f;

        actionRealized = false;
        actionPanel.SetActive(false);

        if(zone!=4)
        {
            enemySprites[0].sprite = EnemyManager.instance.getSprite(enemyMembers[0].id);
            enemySprites[1].sprite = EnemyManager.instance.getSprite(enemyMembers[1].id);
            enemySprites[2].sprite = EnemyManager.instance.getSprite(enemyMembers[2].id);

        }
        else
        {
            enemySprites[1].sprite = EnemyManager.instance.getSprite(enemyMembers[0].id);
            ee1.transform.parent.gameObject.SetActive(false);
            ee3.transform.parent.gameObject.SetActive(false);
        }

        sel = selector.GetComponent<Selector>();
        portrait1.sprite = Party.instance.getPortrait(battleMembers[0].Unitname);
        portrait2.sprite = Party.instance.getPortrait(battleMembers[1].Unitname);
        portrait3.sprite = Party.instance.getPortrait(battleMembers[2].Unitname);

        //current_skills = new List<Skill>();

        if (GameManager.instance.zona_actual==1)
        {
            background.sprite = backgrounds[0].sprite;
        }
        if(GameManager.instance.zona_actual==3)
        {
            background.sprite = backgrounds[1].sprite;
        }

        currentState = BattleState.START;
    }
	
	// Update is called once per frame
	void Update () {
		
        switch(currentState)
        {
            case BattleState.START:
                
                //battleMembers = Party.instance.characters;
                c1.fillAmount = 0.0f;
                c2.fillAmount = 0.0f;
                c3.fillAmount = 0.0f;
                ee1.fillAmount = 0.0f;
                ee2.fillAmount = 0.0f;
                ee3.fillAmount = 0.0f;

                int cont = 0;
                foreach(Text t in health)
                {
                    t.text = battleMembers[cont].hp + " / " + battleMembers[cont].maxHp;
                    cont++;
                }



                
                currentState = BattleState.WAITING;
                break;

            case BattleState.PLAYER_CHOICE:

                if(actionPanel.activeInHierarchy==false)
                {
                    actionPanel.SetActive(true);
                }

                //Debug.Log("El delta time es " + Time.deltaTime);



                break;

            case BattleState.ENEMY_CHOICE:

                    int min = 100000;
                    foreach (Character c in battleMembers)
                    {
                        if (c.hp != 0 && c.hp < min)
                        {
                            min = c.hp;
                            info.target = battleMembers.IndexOf(c);
                        }
                    }

                    currentState = BattleState.DMG_PHASE;
                
                break;

            case BattleState.DMG_PHASE:

                Unit target;

                //inflinge daño el jugador
                if (pchoice!=-1)
                {
                    
                    if(info.enemy)
                    {
                        target = enemyMembers[info.target];
                    }
                    else
                    {
                        target = battleMembers[info.target];
                    }

                    if(info.skill!=null)
                    {
                        if (info.skill.sType == Skill.skillType.HEAL)
                        {
                            target.hp += (int)(info.skill.damage + battleMembers[pchoice].m_int * 0.8);
                        }
                        else if (info.skill.sType == Skill.skillType.DAMAGE)
                        {
                            if (info.skill.magicdmg)
                            {
                                Debug.Log("vida inicial: " + enemyMembers[info.target].hp);
                                dmg = (int)(battleMembers[pchoice].m_int / target.mdef * info.skill.damage);

                                if (dmg < 0)
                                {
                                    dmg = 0;
                                }

                                target.hp -= dmg;
                                Debug.Log("Daño inflingido: " + dmg);
                                Debug.Log("vida final: " + enemyMembers[info.target].hp);
                            }
                            else
                            {
                                dmg= (int)(battleMembers[pchoice].m_str / target.def * info.skill.damage);
                                target.hp -= dmg; 
                            }
                            StartCoroutine(DmgUI(info.target, true, dmg));
                        }
                    }
                    else
                    {
                        Debug.Log("Enemigo:" + info.target);
                        Debug.Log("Vida antes del ataque: " + target.hp);
                        dmg= (int)(battleMembers[pchoice].m_str - target.def);

                        if (dmg < 0)
                        {
                            dmg = 0;
                        }

                        target.hp -= dmg;
                        StartCoroutine(DmgUI(info.target,true, dmg));
                        Debug.Log("Vida despuess del ataque: " + target.hp);
                        Debug.Log("jeje ok:" + enemyMembers[info.target].hp);
                        Debug.Log("ataque normal");
                    }
                    actionRealized = true;
                }
                else // daño de los enemigos
                {
                    
                    //target = battleMembers[info.target];
                    //de momento solo daño fisico
                    
                    dmg = (int)(enemyMembers[echoice].str - battleMembers[info.target].m_def);

                    if (dmg < 0)
                    {
                        dmg = 0;
                    }

                    battleMembers[info.target].m_hp -= dmg;

                    StartCoroutine(DmgUI(info.target, false, dmg));
                    Debug.Log("EL ENEMIGO ATACO");
                    actionRealized = true;

                    health[info.target].text = battleMembers[info.target].m_hp.ToString() + " / " + battleMembers[info.target].maxHp.ToString();


                }

                for(int i=0;i<enemyMembers.Count;i++)
                {
                    if(enemyMembers[i].hp==0)
                    {
                        enemyMembers[i].transform.parent.gameObject.SetActive(false);
                    }
                }

                currentState = BattleState.WAITING;


                if (enemyMembers.FindAll(x => x.hp == 0).Count == 3)
                {
                    currentState = BattleState.WIN;
                }
                if(battleMembers.FindAll(x=>x.m_hp ==0).Count==3)
                {
                    currentState = BattleState.LOSE;
                }

                break;

            case BattleState.SELECT_TARGET:


                if(sel.target_selected)
                {
                    info.target = sel.targetSelected();
                    info.enemy = sel.enemySelected();
                    currentState = BattleState.DMG_PHASE;
                    Debug.Log("he pasado a fase de daño");
                    sel.target_selected = false;
                }

                break;

            case BattleState.WAITING:

                actionPanel.SetActive(false);

                if (actionRealized == true)
                {
                    if (pchoice == 0)
                    {
                        c1.fillAmount = 0.0f;
                    }
                    else if (pchoice == 1)
                    {
                        c2.fillAmount = 0.0f;
                    }
                    else
                    {
                        c3.fillAmount = 0.0f;
                    }

                    if(echoice==0)
                    {
                        ee1.fillAmount = 0.0f;
                    }
                    else if(echoice==1)
                    {
                        ee2.fillAmount = 0.0f;
                    }
                    else
                    {
                        ee3.fillAmount = 0.0f;
                    }
                    actionRealized = false;
                    currentState = BattleState.WAITING;
                }
                                
                pchoice = -1;
                echoice = -1;
                
                if(c1.fillAmount>=1.0f)
                {
                    pchoice = 0;
                    currentState = BattleState.PLAYER_CHOICE;
                    break;
                }
                else if(c2.fillAmount>=1.0)
                {
                    pchoice = 1;
                    currentState = BattleState.PLAYER_CHOICE;
                    break;
                }
                else if(c3.fillAmount>=1.0)
                {
                    pchoice = 2;
                    currentState = BattleState.PLAYER_CHOICE;
                    break;
                }
                else if(ee1.fillAmount>=1.0)
                {
                    echoice = 0;
                    pchoice = -1;
                    currentState = BattleState.ENEMY_CHOICE;
                    break;
                }
                else if (ee2.fillAmount >= 1.0)
                {
                    echoice = 1;
                    pchoice = -1;
                    currentState = BattleState.ENEMY_CHOICE;
                    break;
                }
                else if (ee3.fillAmount >= 1.0)
                {
                    echoice = 2;
                    pchoice = -1;
                    currentState = BattleState.ENEMY_CHOICE;
                    break;
                }


                if (c1.fillAmount<1.0f && battleMembers[0].m_hp!=0)
                {
                    c1.fillAmount += (battleMembers[0].m_spe *0.1f) / waitTime * Time.deltaTime;
                }


                if (c2.fillAmount < 1.0f && battleMembers[1].m_hp != 0)
                {
                    c2.fillAmount += (battleMembers[1].m_spe * 0.1f) / waitTime * Time.deltaTime;
                }

                
                if (c3.fillAmount < 1.0f && battleMembers[2].m_hp != 0)
                {
                    c3.fillAmount += (battleMembers[2].m_spe * 0.1f) / waitTime * Time.deltaTime;
                }

                if (ee1.fillAmount<1.0f && enemyMembers[0].hp!=0)
                {
                    ee1.fillAmount += (enemyMembers[0].spe * 0.1f) / waitTime * Time.deltaTime;
                }

                if (ee2.fillAmount < 1.0f && enemyMembers[0].hp != 0)
                {
                    ee2.fillAmount += (enemyMembers[1].spe * 0.1f) / waitTime * Time.deltaTime;
                }

                if (ee3.fillAmount < 1.0f && enemyMembers[0].hp != 0)
                {
                    ee3.fillAmount += (enemyMembers[2].spe * 0.1f) / waitTime * Time.deltaTime;
                }

                break;

            case BattleState.ITEM_USE:

                if(info.it.hp_restore!=0)
                {
                    
                }

                if(info.it.status_restore!=-1)
                {
                    
                }

                break;
            case BattleState.WIN:

                /*set xp*/
                int totalexp = 0;
                int jobexp = 0;
                enemyMembers.ForEach(x =>
                {
                    totalexp += x.baseExp;
                    jobexp += x.jobExp;
                });

                battleMembers.ForEach(x =>
                {
                    x.expGain(totalexp, jobexp);
                });

                currentState = BattleState.EXIT;

                break;

            case BattleState.LOSE:
                break;

            case BattleState.EXIT:
                GameManager.instance.state = GameState.MAP;
                SceneManager.LoadScene("Prototipo movimiento mapa");
                break;
        }

	}


    public void Attack()
    {
        currentState = BattleState.SELECT_TARGET;
        selector.SetActive(true);
    }

    public void Exit()
    {
        int rn;
        rn = Random.Range(0, 100);

        if(rn > 50)
        {
            currentState = BattleState.EXIT;
        }
        actionRealized = true;
    }

    public void toggleSkills()
    {
        if(!skills.activeInHierarchy)
        {
            skills.SetActive(true);
            getSkills();
            optionSelected = "skills";
        }
        else
        {
            skills.SetActive(false);
        }
    }

    public void toggleItems()
    {
        if (!items.activeInHierarchy)
        {
            items.SetActive(true);
            getPotions();
            optionSelected = "items";
        }
        else
        {
            skills.SetActive(false);
        }
    }

    public void getSkills()
    {
        if(current_skills.Count!=0)
        {
            reloadSkills();
        }

        current_skills = SkillManager.instance.getByJob(battleMembers[pchoice].job.jobName);
        Transform go = skills.transform.Find("Content");

        Debug.Log(current_skills.Count+"skills");

        foreach(Skill sk in current_skills)
        {
            GameObject ob = Instantiate(skillUIPrefab);
            ob.transform.Find("Skill").GetComponentInChildren<Text>().text = sk.abilityName;
            ob.transform.GetComponentInChildren<Button>().onClick.AddListener(delegate { sk.use(); });
            ob.transform.Find("Cost").GetComponent<Text>().text= sk.manaCost.ToString();
            ob.transform.SetParent(go);
            ob.transform.localScale = new Vector3(1, 1, 1);
        }

        Debug.Log(go.childCount + "asdaaaadddwww");
    }

    public void getPotions()
    {
        List<Item> it = Inventory.inventory.getPotions();

        Transform go = items.transform.GetChild(0).Find("ItemContent");

        

        foreach(Item x in it)
        {
            GameObject ob = Instantiate(itemUIPrefab);
            ob.transform.Find("Item").GetComponentInChildren<Text>().text = x.itemName;
            ob.transform.GetComponentInChildren<Button>().onClick.AddListener(delegate { x.use(); });
            ob.transform.SetParent(go);
            ob.transform.localScale = new Vector3(1, 1, 1);
            
        }
    }



    void reloadSkills()
    {
        Transform t = skills.transform.Find("Content");

        List<GameObject> c = new List<GameObject>();

        for(int i=0;i<t.childCount;i++)
        {
            c.Add(t.GetChild(i).gameObject);
        }

        c.ForEach(x => Destroy(x.gameObject));
    }

    void reloadPotions()
    {
        Transform t = items.transform.Find("ItemContent");

        List<GameObject> c = new List<GameObject>();

        for (int i = 0; i < t.childCount; i++)
        {
            c.Add(t.GetChild(i).gameObject);
        }

        c.ForEach(x => Destroy(x.gameObject));
    }

    public BattleState CurrentState
    {
        set
        {
            currentState = value;
        }

        get
        {
            return currentState;
        }

    }

    public int getPchoice()
    {
        return pchoice;
    }

    public Character getMemberOnAction()
    {
        return battleMembers[pchoice];
    }

    public bool ActionRealized
    {
        set
        {
            actionRealized = value;
        }

        get
        {
            return actionRealized;
        }
    }


    private IEnumerator DmgUI(int id, bool enemy, int dmg)
    {
        if(!enemy)
        {
            id = id + 3;
        }

        if (enemyMembers.Count == 1)
            id = 1;
        dmgUI[id].gameObject.SetActive(true);
        dmgUI[id].text = dmg.ToString();
        yield return new WaitForSeconds(1);
        dmgUI[id].gameObject.SetActive(false);
    }
}
