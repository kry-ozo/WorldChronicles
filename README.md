In English:

World Chronicles is a kind of historical, enhanced Wikipedia, containing events that can be filtered, searched, and commented on. Everything is controlled by an admin who can create and edit the events being inserted.

Import Instructions:

1.  Download the project and open it in your IDE (Visual Studio is preferred).
2.  Before running the project, check the link provided to the database in the file located in the DataObjects folder. However, if you are using XAMPP (which was used to manage the database in the project), everything should be correct.
3.  Update the database. You can do this through the terminal in the file or NuGet Package Console (In VS: Tools -> NuGet Package Manager -> Package Manager Console). If you are using NuGet, type "update-database". However, in a regular terminal, this may not work, so use "dotnet ef database update".
4.  After completing these steps, the program will automatically seed data, such as the admin profile and a few events (Admin Login: "admin@world.com", Password: "P@ssw0rd"). I encourage you to use it as the admin has their own panel.
Feel free to test it out. There are probably some bugs that I haven't found myself, so feel free to report them!

Po Polsku:

World Chronicles to swego rodzaju historyczna, ulepszona wikipedia, zawierająca wydarzenia które można filtrować, wyszukiwać i komentować. Wszystko kontrolowane jest przez admina, który może tworzyć i edytować wstawiane wydarzenia. Sposób importu:

1.  Pobierz projektu i otwórz go w swoim IDE(Preferowane jest Visual Studio)
2.  Zanim uruchomisz projekt, sprawdź link który jest podany do bazy danych w pliku znajdującym się w folderze DataObjects, jednak jeśli używasz XAMPPA(Był używany do zarządzania bazą danych w projekcie) to wszystko powinno się zgadzać.
3.  Zaaktualizuj baze danych, możesz to zrobić przez terminal w pliku lub NuGet Package Console (Na VS: Tools->NuGet Package Manager->Package Manager Console), Jeśli używasz NuGet wpisz „update-database” jednak w zwykłym terminalu może to nie zadziałać, wtedy użyj „dotnet ef database update
4.  Po wykonaniu tych czynności program automatycznie zasieje dane, takie jak profil admina i kilka wydarzeń(Login Admina: „admin@world.com” , Hasło: „P@ssw0rd”, zachęcam do użycia gdyż admin posiada cały własny panel)
Zachęcam do testowania, na pewno są jakieś błędy których sam nie znalazłem, można podsyłać!
