using UnityEngine;

public class Knight : IEnemy
{
    private InputEnemy _myInput;

    // Start is called before the first frame update
    public void Start()
    {
        _myInput = GetComponent<InputEnemy>();
        this.SayName();
    }

    // Update is called once per frame
    public void Update()
    {
        transform.position += (Vector3)_myInput.PlayerDirection * Stats.Speed * Time.deltaTime;
    }
}
