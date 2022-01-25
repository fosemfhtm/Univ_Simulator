using System.Linq;
using Extensions;
using UnityEngine;

namespace Tools.UI.Card
{
    /// <summary>
    ///     Picks a Texture randomly when it Awakes.
    /// </summary>
    public class UiTexturePicker : MonoBehaviour
    {
        [SerializeField] private Sprite[] Sprites;
        [SerializeField] private SpriteRenderer MyRenderer { get; set; }

        private void Awake()
        {
            MyRenderer = GetComponent<SpriteRenderer>();
            int cardNum = -1;

            if (Sprites.Length > 0)
                while (true)
                {
                    MyRenderer.sprite = Sprites.ToList().RandomItem();
                    if (MyRenderer.sprite.name.Equals("Bohr"))
                    {
                        cardNum = 0;
                    }
                    else if (MyRenderer.sprite.name.Equals("Descartes"))
                    {
                        cardNum = 1;
                    }
                    else if (MyRenderer.sprite.name.Equals("DNA"))
                    {
                        cardNum = 2;
                    }
                    else if (MyRenderer.sprite.name.Equals("Einstein"))
                    {
                        cardNum = 3;
                    }
                    else if (MyRenderer.sprite.name.Equals("Mendel"))
                    {
                        cardNum = 4;
                    }
                    else if (MyRenderer.sprite.name.Equals("Mendeleev"))
                    {
                        cardNum = 5;
                    }
                    else if (MyRenderer.sprite.name.Equals("Newton"))
                    {
                        cardNum = 6;
                    }
                    else if (MyRenderer.sprite.name.Equals("Pythagoras"))
                    {
                        cardNum = 7;
                    }
                    else if (MyRenderer.sprite.name.Equals("cramming"))
                    {
                        cardNum = 8;
                    }
                    else if (MyRenderer.sprite.name.Equals("groupstudy"))
                    {
                        cardNum = 9;
                    }
                    else if (MyRenderer.sprite.name.Equals("lecturenote"))
                    {
                        cardNum = 10;
                    }
                    else if (MyRenderer.sprite.name.Equals("memorizing"))
                    {
                        cardNum = 11;
                    }
                    else if (MyRenderer.sprite.name.Equals("note"))
                    {
                        cardNum = 12;
                    }
                    else if (MyRenderer.sprite.name.Equals("practice"))
                    {
                        cardNum = 13;
                    }
                    else if (MyRenderer.sprite.name.Equals("previnfo"))
                    {
                        cardNum = 14;
                    }
                    else
                    {
                        cardNum = 15;
                    }
                    if (GameManager.instance.activatedCards[cardNum] == 1)
                    {
                        break;
                    }
                }
            UserInfo.MainCharacter.holdingCardInfo.Add(cardNum);
        }
    }
}