using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// using EnemySpace;

namespace Tools.UI.Card
{
    //------------------------------------------------------------------------------------------------------------------

    /// <summary>
    ///     Card Hand holds a register of cards.
    /// </summary>
    public class UiCardHand : UiCardPile, IUiCardHand
    {
        //--------------------------------------------------------------------------------------------------------------
        // int maxHp = 50;
        // int nowHp = 50;
        // int nowHp2 = 50;
        // public Image nowHpBar;
        // public Image nowHpBar2;

        // public GameObject prfHpBar;
        // public GameObject prfHpBar2;

        #region Properties

        /// <summary>
        ///      Card currently selected by the player.
        /// </summary>
        public IUiCard SelectedCard { get; private set; }

        private event Action<IUiCard> OnCardSelected = card => { };

        private event Action<IUiCard> OnCardPlayed = card => { };

        /// <summary>
        ///     Event raised when a card is played.
        /// </summary>
        Action<IUiCard> IUiCardHand.OnCardPlayed { get => OnCardPlayed; set => OnCardPlayed = value; }

        /// <summary>
        ///     Event raised when a card is selected.
        /// </summary>
        Action<IUiCard> IUiCardHand.OnCardSelected { get => OnCardSelected; set => OnCardSelected = value; }

        #endregion

        //--------------------------------------------------------------------------------------------------------------

        #region Operations

        /// <summary>
        ///     Select the card in the parameter.
        /// </summary>
        /// <param name="card"></param>
        public void SelectCard(IUiCard card)
        {
            SelectedCard = card ?? throw new ArgumentNullException("Null is not a valid argument.");

            //disable all cards
            DisableCards();
            NotifyCardSelected();
        }

        /// <summary>
        ///     Play the card which is currently selected. Nothing happens if current is null.
        /// </summary>
        /// <param name="card"></param>
        public void PlaySelected()
        {
            if (SelectedCard == null)
                return;

            PlayCard(SelectedCard);
        }

        /// <summary>
        ///     Play the card in the parameter.
        /// </summary>
        /// <param name="card"></param>
        public void PlayCard(IUiCard card)
        {
            if (card == null)
                throw new ArgumentNullException("Null is not a valid argument.");
            SelectedCard = null;
            RemoveCard(card);
            OnCardPlayed?.Invoke(card);
            EnableCards();
            NotifyPileChange();
            // Debug.Log(card.Name);
            string[] words = card.Name.Split('_');
            Debug.Log(UserInfo.MainCharacter.holdingCardInfo[Convert.ToInt32(words[1])]);
            // switch (UserInfo.MainCharacter.holdingCardInfo[Convert.ToInt32(words[1])])
            // {
            //     case 0:
            //         UserInfo.MainCharacter.AttackedByBtn5(1);
            //         break;
            //     case 1:
            //         UserInfo.MainCharacter.AttackedByBtn5(2);
            //         break;
            //     case 2:
            //         UserInfo.MainCharacter.AttackedByBtn5(3);
            //         break;
            //     case 3:
            //         UserInfo.MainCharacter.AttackedByBtn5(4);
            //         break;
            //     default:
            //         UserInfo.MainCharacter.AttackedByBtn5(10);
            //         break;
            // }
            if (!UserInfo.MainCharacter.flag)
            {
                UserInfo.MainCharacter.hitEnemy(getCardDamage(UserInfo.MainCharacter.holdingCardInfo[Convert.ToInt32(words[1])]));
            }
            // EnemySpace.Enemy newEnemy = new EnemySpace.Enemy();
            // newEnemy.AttackedByBtn5();
        }

        int getCardDamage(int idx)
        {
            int dmg = 0;
            int logic = Convert.ToInt32(UserInfo.MainCharacter.flowchart.Variables[1].ToString());
            int intuition = Convert.ToInt32(UserInfo.MainCharacter.flowchart.Variables[2].ToString());
            int application = Convert.ToInt32(UserInfo.MainCharacter.flowchart.Variables[3].ToString());
            int memorizing = Convert.ToInt32(UserInfo.MainCharacter.flowchart.Variables[4].ToString());
            switch (idx)
            {
                case 0://Bohr
                    dmg = 10 * intuition;
                    break;
                case 1://Descartes
                    dmg = 10 * logic;
                    break;
                case 2://DNA
                    dmg = 10 * memorizing;
                    break;
                case 3://Einstein
                    dmg = 5 * logic + 5 * intuition;
                    break;
                case 4://Mendel
                    dmg = 5 * memorizing + 5 * application;
                    break;
                case 5://Mendeleev
                    dmg = 5 * intuition + 5 * memorizing;
                    break;
                case 6://Newton
                    dmg = 10 * application;
                    break;
                case 7://Pythagoras
                    dmg = 5 * logic + 5 * intuition;
                    break;
                case 8://cramming
                    dmg = -(3 * logic + 3 * intuition + 3 * application + 3 * memorizing);
                    break;
                case 9://groupstudy
                    dmg = -(3 * Convert.ToInt32(UserInfo.MainCharacter.flowchart.Variables[8].ToString()));
                    break;
                case 10://lecturenote
                    dmg = -(2 * logic + 2 * intuition);
                    break;
                case 11://memorizing
                    dmg = -(5 * memorizing);
                    break;
                case 12://note
                    dmg = -(5 * intuition);
                    break;
                case 13://practice
                    dmg = -(5 * application);
                    break;
                case 14://previnfo
                    dmg = -(2 * application + 2 * memorizing);
                    break;
                case 15://reading
                    dmg = -(5 * logic);
                    break;
                default:
                    break;
            }
            return dmg;
        }

        /// <summary>
        ///    Unselect the card in the parameter.
        /// </summary>
        /// <param name="card"></param>
        public void UnselectCard(IUiCard card)
        {
            if (card == null)
                return;
            SelectedCard = null;
            card.Unselect();
            NotifyPileChange();
            EnableCards();
        }

        /// <summary>
        ///     Unselect the card which is currently selected. Nothing happens if current is null.
        /// </summary>
        public void Unselect()
        {
            UnselectCard(SelectedCard);
        }

        /// <summary>
        ///     Disables input for all cards.
        /// </summary>
        public void DisableCards()
        {
            foreach (var otherCard in Cards)
                otherCard.Disable();
        }

        /// <summary>
        ///     Enables input for all cards.
        /// </summary>
        public void EnableCards()
        {
            foreach (var otherCard in Cards)
                otherCard.Enable();
        }

        [Button]
        private void NotifyCardSelected()
        {
            OnCardSelected?.Invoke(SelectedCard);
        }

        #endregion

        //--------------------------------------------------------------------------------------------------------------
    }
}