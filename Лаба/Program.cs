
using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Linq.Expressions;
using System;
using System.IO;
using System;
using System.Collections.Generic;

List<string> album = new();
List<string> musics = new();

LoadListFromFile();
LoadListFromFil();
void LoadListFromFile()
{
    string _filePath = "musictracks.txt";
    if (File.Exists(_filePath))
    {
        
        musics = File.ReadAllLines(_filePath).ToList();
        PrintRed("Список загружен из файла");
    }
    
}
void LoadListFromFil()
{
    string _filePath1 = "musiclist.txt";
    if (File.Exists(_filePath1))
    {

        album = File.ReadAllLines(_filePath1).ToList();
       
    }

}
string filePath = "musictracks.txt";
if (!File.Exists(filePath))
{
    File.Create(filePath).Close();
    PrintRed("Файл для хранения музыки создан");
}
string filePath1 = "musiclist.txt";
if (!File.Exists(filePath1))
{
    File.Create(filePath1).Close();
    
}



void SaveListToFile()
{
    string filePath = "musictracks.txt";
    File.WriteAllLines(filePath, musics);
    string filePath1 = "musiclist.txt";
    File.WriteAllLines(filePath1, album);
}

void PrintGreen(string message)
{
    ConsoleColor color = Console.ForegroundColor;
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine(message);
    Console.ForegroundColor = color;
}
void PrintRed(string message)
{
    ConsoleColor color = Console.ForegroundColor;
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine(message);
    Console.ForegroundColor = color;
}
PrintGreen("Привет");
PrintGreen("Вот список команд \n 0)Выход из программы \n 1)Добавление трека \n 2)Удаление трека \n 3)Список всех треков  \n 4)Очистить все записи \n 5)Добавить альбом \n 6)Удалить альбом \n 7)Список альбомов \n 8)Help ");




while (true)
{
    Console.Write("> ");
    string input = Console.ReadLine();
    switch (input)
    {
        case "0":
            Exit();
            break;
        case "1":
            MusicAdd();
            break;
        case "2":
            MussicDelete();
            break;
        case "3":
            MusicsList();
            break;
        case "5":
            AlbumAdd();
            break;
        case "4":
            Clear();
            break;
        case "7":
            AlbumList();
            break;
        case "8":
            Commands();
            break;
        case "6":
            DeleteAlbum();
            break;
        default:
            PrintRed("Неверная команда!");
            break;

    }

}

void MusicAdd()
{
    PrintGreen("Напиши название");
    string track = Console.ReadLine();
    if (track == "")
    {
        PrintRed("Не правильно!");
    }
    else
    {
      
        musics.Add(track);
        SaveListToFile();
        PrintRed("Добавлено");
    }
}
void DeleteAlbum()
{
    if (album.Count == 0)
    {
        PrintRed("Удалять нечего!");
    }
    else
    {
        PrintGreen("Выбери альбом");
        album.ForEach(album => { Console.WriteLine(album); });
        string deleti = Console.ReadLine();
        PrintRed("Для удаления напишите: Выполнить");
        string r = Console.ReadLine();
        if (r == "Выполнить")
        {
            album.Remove(deleti);
            PrintRed("Удалено");
            SaveListToFile();
        }
    }
}
void AlbumAdd()
{
    PrintGreen("Напиши название альбома");
    string list = Console.ReadLine();
    if (list == "")
    {
        PrintRed("Не правильно");

    }
    else 
    {
    album.Add(list);
    SaveListToFile();
        PrintRed("Добавленно");
    
    }
}
void MussicDelete()
{
    if (musics.Count == 0)
    {
        PrintRed("У вас еще нет треков");
    }
    else
    {
        PrintGreen("Выбери трек");
        musics.ForEach(track => Console.WriteLine(track));
        string delete = Console.ReadLine();
        PrintRed("Чтобы удалить введите слово: Удалить");
        if (Console.ReadLine() == "Удалить")
        {
            musics.Remove(delete);

            PrintRed("Выполнено");
            SaveListToFile();
        }
        else
        {
            PrintRed("Операция не выполнена");
        }
    }
}
void MusicsList()
{
    if (musics.Count == 0)
    {
        PrintRed("У вас еще нет треков");
    }
    else 
    {
        PrintGreen("Вот список всех добавленных треков:");
        musics.ForEach((track)=> Console.WriteLine(track.ToString()));
    }


}
void AlbumList()
{
    if (album.Count == 0)
    {
        PrintRed("У вас еще нет альбома");
    }
    else
    {
        PrintGreen("Вот список альбомов:");
        album.ForEach((list) => Console.WriteLine(list.ToString()));
    }
}
void Clear()
{

    PrintRed("Внимание, этот метод удалит все записи, для очистки всех записей напишите: Выполнить");

    if (Console.ReadLine() == "Выполнить")
    {
        album.Clear();
        musics.Clear();
        PrintRed("Удаление всех списков завершенно");
        SaveListToFile();
    }
    else if (Console.ReadLine() != "Выполнить")
    {
        PrintRed("Операция не выполнена");

    }
}
void Commands()
{
    PrintGreen("\n 0)Выход из программы \n 1)Добавление трека \n 2)Удаление трека \n 3)Список всех треков  \n 4)Очистить все записи \n 5)Добавить альбом \n 6)Удалить альбом \n 7)Список альбомов \n 8)Help ");
    
}

void Exit()
{
    PrintGreen("Пока(");
    SaveListToFile();
    Environment.Exit(0);
}




