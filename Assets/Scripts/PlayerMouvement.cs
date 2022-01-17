﻿using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMouvement : MonoBehaviour
{
    /// <summary>
    /// Représente la direction actuelle du joueur
    /// </summary>
    [SerializeField]
    private Vector2 _direction = Vector2.zero;

    /// <summary>
    /// Représente la vitesse actuelle du joueur
    /// Limité entre 0 et 6 m/s
    /// </summary>
    [SerializeField]
    [Range(0, 400)]
    private float _vitesse = 60f;

    /// <summary>
    /// Force du saut du joueur
    /// </summary>
    [SerializeField]
    private float _forceSaut = 300f;

    /// <summary>
    /// Trigger pour savoir si le personnage saute
    /// </summary>
    private bool _vaSaute = false;

    /// <summary>
    /// Référence vers le Rigidbody du GO
    /// </summary>
    private Rigidbody2D _rb;

    /// <summary>
    /// Détermine si le personne est au sol
    /// </summary>
    private bool _estAuSol;

    void Start()
    {
        // Lie _rb au ridigbody
        _rb = this.gameObject.GetComponent<Rigidbody2D>();
        // Initialise _estAuSol
        _estAuSol = false;
    }

    void Update()
    {
        this.transform.Translate(_direction * _vitesse * Time.deltaTime);
    }

    void FixedUpdate()
    {
        // Saut de l'utilisateur
        if (_vaSaute && _estAuSol)
        {
            _rb.AddForce(transform.up * _forceSaut, ForceMode2D.Impulse);
            _vaSaute = false;
            _estAuSol = false;
        }
    }

    /// <summary>
    /// Méthode exécuté lorsque la personne utilisateur réalise l'InputAction Horizontal
    /// </summary>
    /// <param name="value">Valeur de l'input (ex. appuyer ou non)</param>
    public void OnHorizontal(InputValue value)
    {
        _direction.x = value.Get<float>();
    }

    /// <summary>
    /// Permet de connaître le saut du personnage
    /// </summary>
    public void OnJump()
    {
        _vaSaute = true;
    }

    /// <summary>
    /// Appelé lorsque le personnage entre en collision
    /// </summary>
    /// <param name="collision">Collider de l'autre GO</param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        _estAuSol = collision.gameObject.tag.Equals("Tilemap");
    }
}