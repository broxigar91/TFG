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
    private Animator ae1, ae2, ae3;
    public Image c1, c2, c3, portrait1, portrait2, portrait3, e1, e2, e3;
    public Text h1, h2, h3, m1, m2, m3;
    public GameObject actionPanel,skills,skillUIPrefab,selector,items;
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
                currentState = BattleState.WAITING;
                h1.text = battleMembers[0].Unitname;
                portrait1.sprite = Party.instance.getPortrait(battleMembers[0].Unitname);
                break;

            case BattleState.PLAYER_CHOICE:

                if(actionPanel.activeInHierarchy==false)
                {
                    actionPanel.SetActive(true);
                }

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
                        //ia
                    }
                    else if (echoice == 1)
                    {
                        //ia
                    }
                    else
                    {
                        //ia
                    }
                    actionRealized = false;
                    currentState = BattleState.WAITING;
                }

                break;

            case BattleState.DMG_PHASE:

                //inflinge daño el jugador
                if(pchoice!=-1)
                {
                    Unit target;
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
                        dmg= (int)(battleMembers[pchoice].str - target.def);
                        target.hp -= dmg;
                        Debug.Log("he hecho daño fisico de un ataque normal"); 
                    }

                    





                    actionRealized = true;
                    currentState = BattleState.WAITING;
                }
                else // dalo de los enemigos
                {

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
                }

                break;

            case BattleState.WAITING:

                actionPanel.SetActive(false);
                pchoice = -1;
                echoice = -1;

                if (c1.fillAmount!=1.0f)
                {
                    c1.fillAmount += 1.0f / waitTime * Time.deltaTime;
                }
                else
                {
                    pchoice = 0;
                    currentState = BattleState.PLAYER_CHOICE;
                }

                if (c2.fillAmount != 1.0f)
                {
                    c2.fillAmount += 0.8f / waitTime * Time.deltaTime;
                }
                else
                {
                    pchoice = 1;
                    currentState = BattleState.PLAYER_CHOICE;
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
        currentState = BattleState.EXIT;
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

        Transform go = items.transform.Find("Content");

        foreach(Item x in it)
        {
            GameObject ob = Instantiate();
            
        }
    }



    void reloadSkills()
    {
        Transform t = skills.transform.FindChild("Content");

        List<GameObject> c = new List<GameObject>();

        for(int i=0;i<t.childCount;i++)
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
