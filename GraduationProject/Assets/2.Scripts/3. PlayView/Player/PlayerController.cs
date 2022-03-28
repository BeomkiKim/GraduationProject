using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Transform cameraTransform;
    private Movement movement;
    private PlayerAnimator playerAnimator;
    private PlayerState state;

    SkillBtn skill;
    public GameObject qSkillObj;
    public GameObject fSkillObj;
    public GameObject rInCollider;

    public Transform player;
    public Transform spawnPoint;

    bool isInfo;
    bool isInven;
    public bool isClear;
    bool isOpen;
    public bool attacking;

    public float smoothness = 10f;
    [Header("SkillR")]
    public EffectInfo[] Effects;
    int effectNumber = 0;

    [System.Serializable]
    public class EffectInfo
    {
        public GameObject Effect;
        public Transform StartPositionRotation;
        public float DestroyAfter = 10;
        public bool UseLocalPosition = true;
    }

    PlayerState playerState;


    private void Awake()
    {

        Cursor.visible = false; //마우스 커서를 보이지 않게
        Cursor.lockState = CursorLockMode.Locked; //마우스 커서 위치 고정
        
        isClear = false;


        movement = GetComponent<Movement>();
        playerAnimator = GetComponentInChildren<PlayerAnimator>();
        skill = FindObjectOfType<SkillBtn>();
        playerState = GetComponent<PlayerState>();
        state = GetComponent<PlayerState>();
    }

    void Update()
    {
        if (!attacking)
        {
            //방향키를 눌러 이동
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            playerAnimator.onMovement(x, z);

            //이동속도 설정(앞으로 이동할때만 7, 나머지는 4)
            movement.MoveSpeed = z > 0 ? 5.0f : 3.0f;
            //이동함수 호출(카메라가 보고있는 방향을 기준으로 방향키에 따라 이동
            movement.MoveTo(cameraTransform.rotation * new Vector3(x, 0, z));


        }
        //회전 설정(항상 앞만 보도록 캐릭터의 회전은 카메라와 같은 회전 값을 설정)
        transform.rotation = Quaternion.Euler(0, cameraTransform.eulerAngles.y, 0);

        if (Input.GetButtonDown("Fire1") && !EventSystem.current.IsPointerOverGameObject() && Time.timeScale != 0)
        {
           playerAnimator.onWeaponAttack();
        }




        if (Input.GetKeyDown(KeyCode.P) && !isInven)
        {
            isInfo = true;
            Manager.instance.soundManager.GetComponent<AudioSource>().PlayOneShot(Manager.instance.soundManager.button);

            Manager.instance.invenManager.playerInfoFrame.SetActive(true);
            //Manager.instance.invenManager.bagFrame.SetActive(true);

            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

            Time.timeScale = 0;


        }
        if(isClear && !isOpen)
        {
            isOpen = true;
            Manager.instance.soundManager.GetComponent<AudioSource>().PlayOneShot(Manager.instance.soundManager.button);
            Manager.instance.settingManager.settingFrame.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0;

        }
        if (Input.GetKeyDown(KeyCode.Q) && skill.isQCool == false && playerState.mpCur>=skill.qCost && playerState.lev >= 2)
        {

            skill.UseSkillQ();
            playerAnimator.onSkillAttackQ();
            qSkillObj.transform.position = player.position + new Vector3(0, 2, -2);
            qSkillObj.transform.rotation = Quaternion.Euler(0, cameraTransform.eulerAngles.y, 0);

            qSkillObj.SetActive(true);
            skill.isQCool = true;
            playerState.mpCur -= skill.qCost;
            
        }
        if (Input.GetKeyDown(KeyCode.E) && skill.isFCool == false && playerState.mpCur >= skill.fCost && playerState.lev >= 3)
        {

            skill.UseSkillF();
            playerAnimator.onSkillAttackF();
            fSkillObj.transform.position = spawnPoint.position;
            fSkillObj.transform.rotation = spawnPoint.rotation;
            fSkillObj.SetActive(true);

            skill.isFCool = true;
            playerState.mpCur -= skill.fCost;

        }

        if (Input.GetKeyDown(KeyCode.R) && skill.isRCool == false && playerState.mpCur >= skill.rCost && playerState.lev >= 4)
        {
            //0,1
            rInCollider.gameObject.SetActive(true);


            effectNumber = 0;
            skill.UseSkillR();
            StartCoroutine("SkillR");
            playerAnimator.onSkillAttackR();
            skill.isRCool = true;
            playerState.mpCur -= skill.rCost;

        }
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("StartScene", LoadSceneMode.Single);
        }

        if(playerState.isDie)
        {
            movement.moveSpeed = 0;
        }


    }


    public void ClikExit()
    {
        Manager.instance.soundManager.GetComponent<AudioSource>().PlayOneShot(Manager.instance.soundManager.button);
        Manager.instance.invenManager.playerInfoFrame.gameObject.SetActive(false);

        //Manager.instance.questManager.questFrame.gameObject.SetActive(false);
        //Manager.instance.questManager.bagFrame.gameObject.SetActive(false);
        //Manager.instance.questManager.slotBox.gameObject.SetActive(false);

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        isInfo = false;
        isInven = false;

        Time.timeScale = 1;
    }

    void InstantiateEffect(int EffectNumber)
    {
        if (Effects == null || Effects.Length <= EffectNumber)
        {
            Debug.LogError("Incorrect effect number or effect is null");
        }

        var instance = Instantiate(Effects[EffectNumber].Effect, Effects[EffectNumber].StartPositionRotation.position, Effects[EffectNumber].StartPositionRotation.rotation);

        if (Effects[EffectNumber].UseLocalPosition)
        {
            instance.transform.parent = Effects[EffectNumber].StartPositionRotation.transform;
            instance.transform.localPosition = Vector3.zero;
            instance.transform.localRotation = new Quaternion();
        }
        Destroy(instance, Effects[EffectNumber].DestroyAfter);
    }

    IEnumerator SkillR()
    {
        effectNumber = 0;
        InstantiateEffect(effectNumber);
        effectNumber++;
        yield return new WaitForSeconds(1f);
        InstantiateEffect(effectNumber);
        
    }
}
