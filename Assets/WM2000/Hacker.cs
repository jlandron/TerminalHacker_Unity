public class Hacker : MonoBehaviour {

    //game state enumeration
    enum Screen {
        MainMenu,
        Password,
        WinScreen
    };

    Screen currentScreen;
    int level;

    // Start is called before the first frame update
    void Start( ) {

        ShowMainMenu( );
    }
    void OnUserInput( string message ) {
        if( message == "menu" ) {
            ShowMainMenu( );
        }
        if( currentScreen == Screen.MainMenu ) {
            RunMainMenu( message );
        }
    }
    void RunMainMenu( string input ) {
        if( input == "1" ) {
            StartGame( 1 );
        }
        else if( input == "2" ) {
            StartGame( 2 );
        }
        else if( input == "3" ) {
            StartGame( 3 );
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
    void StartGame( int level ) {
        currentScreen = Screen.Password;
        Terminal.ClearScreen( );
        switch( level ) {
            case 1:
                Terminal.WriteLine( "Hacking the High School" );
                break;
            case 2:
                Terminal.WriteLine( "Hacking City Hall" );
                break;
            case 3:
                Terminal.WriteLine( "Hacking Army Head Quarters" );
                break;
            default:
                break;
        }
    }
}