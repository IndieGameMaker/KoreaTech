using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCtrl : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePos;

    private AudioSource audio;
    public AudioClip fireSfx;

    [SerializeField]
    private MeshRenderer muzzleFlash;

    void Start()
    {
        audio = GetComponent<AudioSource>();
        muzzleFlash = firePos.GetComponentInChildren<MeshRenderer>();
        muzzleFlash.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }
    }

    void Fire()
    {
        // 총알 생성 : Instantiate(생성할객체, 위치, 각도)
        Instantiate(bulletPrefab, firePos.position, firePos.rotation);

        // 총소리 발생
        audio.PlayOneShot(fireSfx, 0.8f);
        // 총구화염
        StartCoroutine(ShowMuzzleFlash());
    }

    // 코루틴
    IEnumerator ShowMuzzleFlash()
    {
        // 텍스처의 Offset 변경
        /*
            난수 발생
            Random.Range(최소값, 최대값)

            Random.Range(0, 10)        => 0, ...., 9
            Random.Range(0.0f, 10.0f)  => 0.0f, ... , 10.0f

            (0 , 1) * 0.5f => (0, 0.5f)

            (0, 0)
            (0, 0.5f)
            (0.5f, 0.5f)
            (0.5f, 0)
        */
        Vector2 offset = new Vector2(Random.Range(0, 2), Random.Range(0, 2)) * 0.5f;
        muzzleFlash.material.mainTextureOffset = offset;

        // 스케일 변경
        float scale = Random.Range(1.0f, 2.5f);
        // {컴포넌트}.transform
        muzzleFlash.transform.localScale = Vector3.one * scale; // new Vector3(scale, scale, scale);

        muzzleFlash.enabled = true;
        // Sleep 
        yield return new WaitForSeconds(0.2f);

        muzzleFlash.enabled = false;
    }
}
