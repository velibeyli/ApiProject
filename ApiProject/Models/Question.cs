﻿using System.Text.Json.Serialization;

namespace ApiProject.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string FirstAnswer { get; set; }
        public string SecondAnswer { get; set; }
        public string ThirdAnswer { get; set; }
        public string FourthAnswer { get; set; }
        public int AnswerId { get; set; }
        public int CategoryId { get; set; }
        [JsonIgnore]
        public QuestionAnswer? Answer { get; set; }
        [JsonIgnore]
        public Category? Category { get; set; }
    }
}
