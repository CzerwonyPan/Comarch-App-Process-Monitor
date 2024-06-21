[PL lang]Witam,
Stworzyłem aplikacje Comarch monitor process app, do monitorowania procesów aplikacji CDNWORK.exe.
Aplikacja monitoruje ilość procesów na podstawie ilości wpisanych komend które to mają uruchomic proces CDNWROK.exe jeśli któryś z autoamtów comarch XL przestanie działać lub wyśle wiadomość wiadomość email o zacięciu procesów.
Jeśli któryś z procesów przestanie odpowiadać (sprawdza 2 razy )zostanie wysłana wiadomość mail. Plik emailsettings.json
Aplikacja napisana w C#. Potrzebuje biblioteki .NET versja 8.0.6
Aplikacja w języku polski w razie potrzeby proszę się ze mną skontaktować w celu przełumaczenia na język angielski.
Aplikacja nie łaczy się do bazy danych. wykonuje tylko polecenia w opraciu o interfejs windows. 
Scenariusz: 
1.Aplikacja monitoruje o dany interwał czasu.
2. aplikacja sprawdza ilość uruchomionych procesów [ilośc wpisanych komend jest np. 3 ] , jeśli ilość procesów nie wynosi 3.
3.aplikacja zamika wszystkie procesy oraz po 10 s uruchamia wszystkie na nowo. 
4.Jeśli proces nie odpowiada aplikacja sprawdzi to 2 raz[jeli za 2 razmem bedzie odpowiadał to aplikacja bedzie działać dalej] po czasie ustawionym w interwale następnie wyśle wiadomość na określony adres mail.
5. apliakcja bedzie wsyłać mail aż do czasu podjęcia akcji przez administratora.
6. Remedium: Zatrzymaj aplikacje [przycisk STOP]-> usuń procesy w Coamrch XL (zakładka procesy) -> uruchom program [przycisk START] 

Lokalizacjia skompilowanej aplikacji -> MonitorApp\bin\Release\net8.0-windows
Do poprawnego działania apliakcji potrzebne są pliki:
-App.config
-MonitorApp.exe
-MonitorApp.dll
-Newtonsoft.Json.dll
-MonitorApp.runtimeconfig.json

pliki : emailSettings.json oraz commands.json nie są wymagane gdyż po interakcji użytkownika z apliakcją zostaną automatycznie utowrzone.
[PL lang]

[Eng lang]
Hello,

I have created the Comarch Monitor Process App, designed to monitor the processes of the application CDNWORK.exe. This application monitors the number of processes based on the number of entered commands that are supposed to start the CDNWORK.exe process if any of the Comarch XL automations stop working or sends an email notification about process hang-ups.

If any process stops responding (checked twice), an email notification will be sent. The email settings are configured in the emailsettings.json file. The application is written in C# and requires the .NET version 8.0.6 library.

The application is in Polish; please contact me if you need an English translation.

The application does not connect to a database; it only executes commands based on the Windows interface.

Scenario:

The application monitors at a given interval.
The application checks the number of running processes (the number of entered commands is, for example, 3). If the number of processes is not 3:
The application closes all processes and restarts them after 10 seconds.
If a process does not respond, the application will check again (if it responds the second time, the application will continue to operate) after the interval time and then send an email to the specified address.
The application will keep sending emails until the administrator takes action.
Remedy: Stop the application (STOP button) -> remove processes in Comarch XL (Processes tab) -> start the program (START button).
Location of the compiled application: MonitorApp\bin\Release\net8.0-windows

Files required for the application to work properly:

App.config
MonitorApp.exe
MonitorApp.dll
Newtonsoft.Json.dll
MonitorApp.runtimeconfig.json
The files emailSettings.json and commands.json are not required as they will be automatically created after user interaction with the application.
[Eng_lang]
