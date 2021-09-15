using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace AdvancedProgramming_Lesson4.Hubs
{
    public class ChatMessage
    {
        public int Id { get; set; }
        [Display(Name = "Użytkownicy")]
        public string UserName { get; set; }
        [Display(Name = "Wiadomości")]
        public string Message { get; set; }
        [Display(Name = "Autoryzacja")]
        public bool Authorizated { get; set; }
    }
}