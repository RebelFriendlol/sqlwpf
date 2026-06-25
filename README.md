# sqlwpf - Database Layer / Warstwa Bazy Danych

---

## 🇵🇱 Wersja Polska

### O projekcie
Projekt uniwersytecki realizujący warstwę trwałego przechowywania danych (Persistence Layer) dla aplikacji okienkowej przy użyciu języka SQL oraz technologii WPF/.NET. Odpowiada za zapisywanie utworów, profili użytkowników i konfiguracji playlist w relacyjnej bazie danych.

###  Jak ten projekt łączy się z pozostałymi?
Ten projekt to **Pamięć (Warstwa Danych)** całego systemu odtwarzacza:
* Zapewnia, że utwory zarządzane przez silnik **`csharp-musicplayer`** nie znikają po wyłączeniu programu.
* Pozwala interfejsowi **`CSHARPGUI / AlbertoPlayer`** wczytywać zapisane wcześniej ulubione playlisty użytkownika bezpośrednio z bazy danych SQL.

---

## 🇬🇧 English Version

### About the Project
A university project implementing the data persistence layer for a desktop application using SQL and WPF/.NET. It focuses on storing tracks, user profiles, and playlist configurations within a relational database.

###  How this project connects to the others?
This project acts as the **Memory (Data Layer)** of the entire music player architecture:
* It ensures that tracks managed by the **`csharp-musicplayer`** engine are persistent and not lost when the application closes.
* It allows the **`CSHARPGUI / AlbertoPlayer`** interface to populate and load previously saved user playlists directly from the SQL database tables.
