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
    public List<Enemy> enemyMembers = new List<Enemy>();
    private BattleState currentState;
    private int enemyType;
    private float waitTime = 10.0f;
    private float cd1;
    private int pchoice,echoice,dmg;
    private bool actionRealized;
    private int zone;
    private string optionSelected;
    public Image c1, c2, c3, portrait1, portrait2, portrait3, e1, e2, e3, ee1, ee2, ee3;
    public Text h1, h2, h3, m1, m2, m3;
    public GameObject actionPanel,skills,skillUIPrefab,selector,items,itemUIPrefab;
    public List<Skill> current_skills;
    private Selector sel;

    // Use this for initialization
	void Start () {
        zone = GameManager.instance.zona_actual;
        battleMembers = Party.instance.characters;
        enemyMembers = EnemyManager.instance.toBattle(zone);
        currentState = BattleState.START;
        actionRealized = false;
        actionPanel.SetActive(false);
        e1.sprite = EnemyManager.instance.getSprite(enemyMembers[0].id);
        e2.sprite = EnemyManager.instance.getSprite(enemyMembers[1].id);
        e3.sprite = EnemyManager.instance.getSprite(enemyMembers[2].id);
        sel = selector.GetComponent<Selector>();

        //current_skills = new List<Skill>();
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

                currentState = BattleState.WAITING;
                h1.text = battleMembers[0].hp +"/"+battleMembers[0].maxHp;
                h2.text = battleMembers[1].hp + "/" + battleMembers[1].maxHp;
                h3.text = battleMembers[2].hp + "/" + battleMembers[2].maxHp;

                portrait1.sprite = Party.instance.getPortrait(battleMembers[0].Unitname);
                break;

            case BattleState.PLAYER_CHOICE:

                if(actionPanel.activeInHierarchy==false)
                {
                    actionPanel.SetActive(true);
                }

                Debug.Log("El delta time es " + Time.deltaTime);

                if(actionRealized==true)
                {
                    if(pchoice==0)
                    {
                        c1.fillAmount = 0.0f;
                    }
                    else if(pchoice == 1)
                    {
                        c2.fillAmount = 0.0f;
                    }
                    else
                    {
                        c3.fillAmount = 0.0f;
                    }
                    actionRealized = false;
                    currentState = BattleState.WAITING;
                }


                break;

            case BattleState.ENEMY_CHOICE:

                if (actionRealized == true)
                {
                    if (echoice == 0)
                    {
                        ee1.fillAmount = 0.0f;
                    }
                    else if (echoice == 1)
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
                else
                {
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
                }
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
                            target.hp += (int)(info.skill.damage + battleMembers[pchoice].intelect * 0.8);
                        }
                        else if (info.skill.sType == Skill.skillType.DAMAGE)
                        {
                            if (info.skill.magicdmg)
                            {
                                Debug.Log("vida inicial: " + enemyMembers[info.target].hp);
                                dmg = (int)(battleMembers[pchoice].intelect / target.mdef * info.skill.damage);
                                target.hp -= dmg;
                                Debug.Log("Daño inflingido: " + dmg);
                                Debug.Log("vida final: " + enemyMembers[info.target].hp);
                            }
                            else
                            {
                                target.hp = (int)(battleMembers[pchoice].str / target.def * info.skill.damage);
                            }

                            //si la vida del enemigo seleccionado llega a 0 desactivamos su imagen
                            if (enemyMembers[info.target].hp == 0)
                            {
                                if (info.target == 0)
                                {
                                    e1.gameObject.SetActive(false);
                                }
                                else if (info.target == 1)
                                {
                                    e2.gameObject.SetActive(false);
                                }
                                else
                                {
                                    e3.gameObject.SetActive(false);
                                }
                            }
                        }
                    }
                    else
                    {
                        Debug.Log("Enemigo:" + info.target);
                        Debug.Log("Vida antes del ataque: " + target.hp);
                        dmg= (int)(battleMembers[pchoice].str - target.def);
                        target.hp -= dmg;
                        Debug.Log("Vida despuess del ataque: " + target.hp);
                        Debug.Log("jeje ok:" + enemyMembers[info.target].hp);
                        Debug.Log("ataque normal");
                    }
                    actionRealized = true;
                    currentState = BattleState.PLAYER_CHOICE;
                }
                else // daño de los enemigos
                {
                    target = battleMembers[info.target];
                    //de momento solo daño fisico
                    dmg = (int)(enemyMembers[echoice].str - target.def);
                    target.hp -= dmg;
                    Debug.Log("EL ENEMIGO ATACO");
                    actionRealized = true;
                    currentState = BattleState.ENEMY_CHOICE;
                }

                if (enemyMembers.FindAll(x => x.hp == 0).Count == 3)
                {
                    currentState = BattleState.WIN;
                }
                if(battleMembers.FindAll(x=>x.hp ==0).Count==3)
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
                pchoice = -1;
                echoice = -1;

                if (c1.fillAmount<1.0f && battleMembers[0].hp!=0)
                {
                    c1.fillAmount += 1.0f / waitTime * Time.deltaTime;
                }
                else
                {
                    pchoice = 0;
                    currentState = BattleState.PLAYER_CHOICE;
                    break;
                }

                if (c2.fillAmount < 1.0f && battleMembers[1].hp != 0)
                {
                    c2.fillAmount += 0.8f / waitTime * Time.deltaTime;
                }
                else
                {
                    pchoice = 1;
                    currentState = BattleState.PLAYER_CHOICE;
                    break;
                }
                
                if (c3.fillAmount < 1.0f && battleMembers[2].hp != 0)
                {
                    c3.fillAmount += 0.85f / waitTime * Time.deltaTime;
                }
                else
                {
                    pchoice = 2;
                    currentState = BattleState.PLAYER_CHOICE;
                    break;
                }

                
                if (ee1.fillAmount<1.0f && enemyMembers[0].hp!=0)
                {
                    ee1.fillAmount += 0.8f / waitTime * Time.deltaTime;
                }
                else
                {
                    echoice = 0;
                    pchoice = -1;
                    currentState = BattleState.ENEMY_CHOICE;
                    break;
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

}
