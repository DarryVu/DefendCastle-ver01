using UnityEngine;

public class Health : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] private float startingHealth;
    [SerializeField] private AudioClip collectionAudio;
    private float currenHealth;
    public float CurrenHealth { get => currenHealth; }
    public float StartingHealth { get => startingHealth; }


    bool Dead;
    private Animator anim;
    private UIManager _uiManager;

    private void Awake()
    {
        currenHealth = startingHealth;
        anim = GetComponent<Animator>();
        _uiManager = FindObjectOfType<UIManager>();


    }
    private void Update()
    {
        
    }
    public void TakeDamage(float _damage)
    {
        
        currenHealth = Mathf.Clamp(currenHealth - _damage, 0, startingHealth);
        if (currenHealth > 0)
        {
                anim.SetTrigger("Hurt");
        }
        else
        {
            if (!Dead)
            {
                anim.SetTrigger("Die");
                
                Dead = true;               
            }
            Time.timeScale = 0;
            _uiManager.GameOver();
        }
    }
    public void AddHealth(float _value)
    { 
      //1
        currenHealth += _value;
        if (currenHealth > startingHealth) currenHealth = startingHealth;
        SoundManager.instance.PlaySound(collectionAudio);
      //2
      //  currenHealth = Mathf.Clamp(currenHealth + _value, 0, startingHealth);
    }


}
