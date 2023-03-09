using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   public static GameManager instance;

   private void Awake()
   {
		  instance = this;
   }

   public GameObject player;
   public GameObject player1;
   public ItemContainer inventoryContainer;
   public ItemDragAndDropController dragAndDropController;
   public DayTimeController timeController;
   public DialogueSystem dialogueSystem;
   public PlaceableObjectsReferenceManager placeableObjects;
   public ItemList itemDB;
   public OnScreenMessageSystem messageSystem;
}
