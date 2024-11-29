using System;
using System.Collections.Generic;

namespace NoteApp.Models
{
    public class Note
    {
        public string Title { get; set; } = string.Empty;  // Название заметки
        public string Text { get; set; } = string.Empty;   // Текст заметки
        public DateTime CreatedDate { get; set; } = DateTime.Now;  // Дата создания заметки
        public List<string> Tags { get; set; } = new List<string>(); // Теги

        // Метод для вывода информации о заметке
        public override string ToString()
        {
            var tags = Tags.Count > 0 ? string.Join(", ", Tags) : "No tags";
            return $"Title: {Title}\nText: {Text}\nCreated: {CreatedDate}\nTags: {tags}";
        }
    }
}
