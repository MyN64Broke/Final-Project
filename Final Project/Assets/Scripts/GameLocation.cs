using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLocation : MonoBehaviour
{
    private static bool playerTurn;
    private static bool gameWon;
    private static char winnerCharacter;
    public bool locationTaken;
    public char locationValue;
    private GameObject[] locations;
    public GameObject playerPiece;
    public GameObject AIPiece;
    public GameObject youWinText;
    public GameObject youLoseText;
    public bool isMasterScript;
    public int locationNumber;
    void Start(){
        playerTurn = true;
        locationTaken = false;
        locationValue = 'N';
        if(isMasterScript){
            locations = GameObject.FindGameObjectsWithTag("Location");
        }
    }

    void Update(){
        if(!playerTurn && !gameWon && isMasterScript){
            checkWin();
            if(!gameWon){
                playerTurn = true;
                aiMove();
                checkWin();
            }
        }
    }

    void OnMouseDown(){
        if(playerTurn && !gameWon && !locationTaken){
            Instantiate(playerPiece, transform.position, Quaternion.identity);
            locationTaken = true;
            locationValue = 'X';
            playerTurn = false;
        }
    }

    void aiMove(){
        int numberOfLoops = 0;
        while(numberOfLoops < 20){
            int index = Random.Range(0, locations.Length);
            GameObject currentLocation = locations[index];
            GameLocation currentLocationScript = currentLocation.GetComponent<GameLocation>();
            if(!currentLocationScript.locationTaken){
                Instantiate(AIPiece, currentLocation.transform.position, Quaternion.identity);
                currentLocationScript.locationTaken = true;
                currentLocationScript.locationValue = 'O';
                return;
            }
            numberOfLoops++;
        }
    }

    void checkWin(){
        List<GameObject> row1 = new List<GameObject>();
        List<GameObject> row2 = new List<GameObject>();
        List<GameObject> row3 = new List<GameObject>();
        List<GameObject> column1 = new List<GameObject>();
        List<GameObject> column2 = new List<GameObject>();
        List<GameObject> column3 = new List<GameObject>();
        List<GameObject> diagonal1 = new List<GameObject>();
        List<GameObject> diagonal2 = new List<GameObject>();
        foreach(GameObject location in locations){
            GameLocation currentLocationScript = location.GetComponent<GameLocation>();
            if(currentLocationScript.locationNumber == 1){
                row1.Add(location);
                column1.Add(location);
                diagonal1.Add(location);
            }else if(currentLocationScript.locationNumber == 2){
                row1.Add(location);
                column2.Add(location);
            }else if(currentLocationScript.locationNumber == 3){
                row1.Add(location);
                column3.Add(location);
                diagonal2.Add(location);
            }else if(currentLocationScript.locationNumber == 4){
                row2.Add(location);
                column1.Add(location);
            }else if(currentLocationScript.locationNumber == 5){
                row2.Add(location);
                column2.Add(location);
                diagonal1.Add(location);
                diagonal2.Add(location);
            }else if(currentLocationScript.locationNumber == 6){
                row2.Add(location);
                column3.Add(location);
            }else if(currentLocationScript.locationNumber == 7){
                row3.Add(location);
                column1.Add(location);
                diagonal2.Add(location);
            }else if(currentLocationScript.locationNumber == 8){
                row3.Add(location);
                column2.Add(location);
            }else if(currentLocationScript.locationNumber == 9){
                row3.Add(location);
                column3.Add(location);
                diagonal1.Add(location);
            }
        }
        if(checkList(row1)){
            if(winnerCharacter == 'X'){
                Instantiate(youWinText);
            }else{
                Instantiate(youLoseText);
            }
        }else if(checkList(row2)){
            if(winnerCharacter == 'X'){
                Instantiate(youWinText);
            }else{
                Instantiate(youLoseText);
            }
        }else if(checkList(row3)){
            if(winnerCharacter == 'X'){
                Instantiate(youWinText);
            }else{
                Instantiate(youLoseText);
            }
        }else if(checkList(column1)){
            if(winnerCharacter == 'X'){
                Instantiate(youWinText);
            }else{
                Instantiate(youLoseText);
            }
        }else if(checkList(column2)){
            if(winnerCharacter == 'X'){
                Instantiate(youWinText);
            }else{
                Instantiate(youLoseText);
            }
        }else if(checkList(column3)){
            if(winnerCharacter == 'X'){
                Instantiate(youWinText);
            }else{
                Instantiate(youLoseText);
            }
        }else if(checkList(diagonal1)){
            if(winnerCharacter == 'X'){
                Instantiate(youWinText);
            }else{
                Instantiate(youLoseText);
            }
        }else if(checkList(diagonal2)){
            if(winnerCharacter == 'X'){
                Instantiate(youWinText);
            }else{
                Instantiate(youLoseText);
            }
        }
    }

    bool checkList(List<GameObject> locationList){
        GameObject currentLocation = locationList[0];
        GameLocation currentLocationScript = currentLocation.GetComponent<GameLocation>();
        char listValue = currentLocationScript.locationValue;
        if(listValue != 'N'){
            foreach(GameObject location in locationList){
                GameLocation locationScript = location.GetComponent<GameLocation>();
                if(locationScript.locationValue != listValue){
                    return false;
                }
            }
            gameWon = true;
            winnerCharacter = listValue;
            return true;
        }else{
            return false;
        }
    }
}
