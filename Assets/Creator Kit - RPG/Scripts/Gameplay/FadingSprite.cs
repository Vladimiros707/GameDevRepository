using System;
using System.Collections;
using RPGM.Core;
using Unity.VisualScripting;
using UnityEngine;

namespace RPGM.Gameplay
{
    /// <summary>
    /// Marks a sprite that should fade away when the player character enters it's trigger.
    /// </summary>
    /// <typeparam name="FadingSprite"></typeparam>
    [RequireComponent(typeof(SpriteRenderer), typeof(Collider2D))]
    public class FadingSprite : InstanceTracker<FadingSprite>
    {
        
        
        public SpriteRenderer spriteRenderer1;

        public void TestMethod()
        {
            spriteRenderer1.flipX = true;
            spriteRenderer1.color = new Color(0f, 0f, 1f, 1f);
        }
        
        
        internal SpriteRenderer spriteRenderer;

        internal float alpha = 1, velocity, targetAlpha = 1;

        private void Start()
        {
            Debug.Log("Start");
        }

        void Awake()
        {
            Debug.Log("AWAKE");
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void OnEnable()
        {
            Debug.Log("OnEnable");
        }

     
        void OnTriggerEnter2D(Collider2D other)
        {
            Debug.Log("Entered");
            Debug.Log(other.gameObject.name);

            
            var characterSpriteRenderer = other.gameObject.GetComponent<SpriteRenderer>();
            if (characterSpriteRenderer != null)
                characterSpriteRenderer.color = new Color(0f, 0f, 0f, 1f);
            //Console.WriteLine("Here");
            targetAlpha = 0.5f;
        }

        void OnTriggerExit2D(Collider2D other)
        {
            targetAlpha = 1f;
        }
    }
}