using Microsoft.AspNetCore.Mvc;
using NoteApp.Models;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace NoteApp.Controllers
{
    public class NoteController : Controller
    {
        // Список для хранения заметок
        private static List<Note> notes = new List<Note>();

        // Отображение списка всех заметок
        public IActionResult Index()
        {
            return View(notes);  // Передаем список заметок в представление
        }

        // Страница для создания новой заметки
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // Обработка формы создания новой заметки
        [HttpPost]
        public IActionResult Create(Note note)
        {
            note.CreatedDate = DateTime.Now;  // Устанавливаем текущую дату создания
            notes.Add(note);  // Добавляем заметку в список

            return RedirectToAction("Index");  // Перенаправляем на страницу с заметками
        }

        // Сохранение заметок в файл (JSON формат)
        // Сохранение заметок в файл с корректной кодировкой UTF-8
        public IActionResult SaveToFile()
        {
            string filePath = "notes.json";

            // Настроим сериализацию с параметром WriteIndented для красивого вывода
            var options = new JsonSerializerOptions
            {
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping, // Разрешаем "не безопасное" экранирование (т.е. не экранировать символы Unicode)
                WriteIndented = true // Для красивого форматирования JSON
            };

            var jsonContent = JsonSerializer.Serialize(notes, options);
            System.IO.File.WriteAllText(filePath, jsonContent, Encoding.UTF8);  // Записываем в файл с кодировкой UTF-8

            return Content($"Notes have been saved to {filePath}.");
        }


        // Загрузка заметок из файла
        public IActionResult LoadFromFile()
        {
            string filePath = "notes.json";

            if (System.IO.File.Exists(filePath))
            {
                var jsonContent = System.IO.File.ReadAllText(filePath);
                notes = System.Text.Json.JsonSerializer.Deserialize<List<Note>>(jsonContent) ?? new List<Note>();
            }

            return RedirectToAction("Index");
        }
    }
}
