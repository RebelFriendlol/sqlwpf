# AlbertoPlayer (CSHARPGUI) - Graphical User Interface / Interfejs Graficzny

---

## 🇵🇱 Wersja Polska

### O projekcie
Projekt aplikacji okienkowej .NET realizujący graficzny interfejs użytkownika (GUI) dla odtwarzacza muzycznego. Skupia się na dostarczeniu intuicyjnego UI (przyciski Play/Pause, paski postępu, suwaki głośności oraz wizualne listy utworów).

###  Jak ten projekt łączy się z pozostałymi?
Ten projekt to **Twarz (Warstwa Prezentacji)** całego systemu odtwarzacza:
* Każde kliknięcie użytkownika (np. naciśnięcie „Play”) wywołuje funkcje pod spodem z silnika logicznego w repozytorium **`csharp-musicplayer`**.
* Wyświetla playlisty i listy utworów, które zostały pobrane z bazy danych za pośrednictwem projektu **`sqlwpf`**.

---

## 🇬🇧 English Version

### About the Project
A .NET desktop application project focused on delivering the Graphical User Interface (GUI) for the music player. It provides an intuitive UI layout featuring Play/Pause buttons, progress bars, volume sliders, and visual track lists.

###  How this project connects to the others?
This project acts as the **Face (Presentation Layer)** of the entire music player architecture:
* Every user interaction (e.g., clicking "Play") triggers underlying execution routines handled by the core engine in the **`csharp-musicplayer`** repository.
* It renders playlists and song collections that are queried from the database via the **`sqlwpf`** project.
