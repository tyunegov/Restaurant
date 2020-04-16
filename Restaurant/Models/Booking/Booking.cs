using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.Models.Book
{
    public class Booking
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Не указано имя")]
        [Display(Name = "Имя")]
        public string Client { get; set; }

        [Display(Name = "Дата")]
        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "Не указана дата бронирования")]
        public DateTime DateTime { get; set; }

        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Количество мест")]
        [Required(ErrorMessage = "Не указано количество мест")]
        [DataType(DataType.Duration)]
        public int Amount { get; set; }

        [Phone]
        [Display(Name = "Номер телефона")]
        [Required(ErrorMessage = "Не указан номер телефона")]
        public string Number { get; set; }

        [Display(Name = "Сообщение")]
        [UIHint("MultilineText")]
        public string Message { get; set; }
        [Display(Name ="Бронирование подтверждено")]
        public bool IsConfirm { get; set; }
    }
}
