using UnityEngine;
public class Hacker : MonoBehaviour {

    //game state enumeration
    enum Screen {
        MainMenu,
        Password,
        WinScreen
    };

    Screen currentScreen;
    int level;
    string password;
    const string menuHint = "type \"menu\" to go bakc to the menu";

    // Start is called before the first frame update
    void Start( ) {
        ShowMainMenu( );
    }
    void OnUserInput( string message ) {
        if( message == "menu" ) {
            ShowMainMenu( );
        }
        else if( currentScreen == Screen.MainMenu ) {
            RunMainMenu( message );
        }
        else if( currentScreen == Screen.Password ) {
            RunPassword( message );
        }
    }

    void RunPassword( string message ) {
        if( message == this.password ) {
            Terminal.ClearScreen( );
            Terminal.WriteLine( "Permission Granted..." );
            displayWinScreen( );
            Terminal.WriteLine( menuHint );
            currentScreen = Screen.WinScreen;
        }
        else {
            Terminal.WriteLine( "Incorrect Password, try again" );
            Terminal.WriteLine( "hint: " + this.password.Anagram( ) );
            Terminal.WriteLine( menuHint );
        }
    }

    void RunMainMenu( string input ) {
        if( input == "1" || input == "2" || input == "3" ) {
            this.level = int.Parse( input );
            StartGame( );
        }
        else {
            Terminal.WriteLine( "Please Choose a correct option" );
        }
    }
    void ShowMainMenu( ) {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen( );
        Terminal.WriteLine( "------Welcome to Terminal Hacker------" );
        Terminal.WriteLine( "Option 1: Hack the High School" );
        Terminal.WriteLine( "Option 2: Hack the local City Hall" );
        Terminal.WriteLine( "Option 3: Hack the Army HeadQuarters" );
        Terminal.WriteLine( "" );
        Terminal.WriteLine( "Enter your selection: " );
    }
    void StartGame( ) {
        currentScreen = Screen.Password;
        Terminal.ClearScreen( );

        int password = Random.Range( 0, 5 );
        switch( this.level ) {
            case 1:
                LevelOne( password );
                break;
            case 2:
                LevelTwo( password );
                break;
            case 3:
                LevelThree( password );
                break;
            default:
                break;
        }
    }
    void LevelOne( int choice ) {
        string[] passwords = { "teacher", "lunch", "study", "class", "office" };
        Terminal.WriteLine( "Hacking the High School" );
        password = passwords[choice];
        Terminal.WriteLine( "Enter your guess: " + this.password.Anagram( ) );
        
    }
    void LevelTwo( int choice ) {
        string[] passwords = { "Lawyer", "police", "mayor", "volenteer", "department" };
        Terminal.WriteLine( "Hacking City Hall" );
        password = passwords[choice];
        Terminal.WriteLine( "Enter your guess: " + this.password.Anagram( ) );
        
    }
    void LevelThree( int choice ) {
        string[] passwords = { "academy", "barracks", "destroyer", "encampment", "tomohawk" };
        Terminal.WriteLine( "Hacking Army Head Quarters" );
        password = passwords[choice];
        Terminal.WriteLine( "Enter your password, hint: " + this.password.Anagram( ) );
        
    }
    void displayWinScreen( ) {
        switch( this.level ) {
            case 1:
                Terminal.WriteLine( @"
      _ _
 .-. | | |
 |M|_|A|N|
 |A|a|.|.|<\\
 |T|r| | |  \\
 |H|t|M|Z|   \\
 | | !| | |   \\>
" );
                break;
            case 2:
                Terminal.WriteLine( @"
   ,   /\   ,
  / '-'  '-' \
  |  POLICE  |
  |   .--.   |
  |  ( 19 )  |
  \   '--'   /
   '--.  .--'
       \/
" );
                break;
            case 3:
                Terminal.WriteLine( @"
    .--._____,
 .-='=='==-, 
( O_o_o_o_o_O )
");
                break;
            default:
                break;
        }
    }

}